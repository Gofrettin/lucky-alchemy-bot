﻿using LuckyAlchemyBot.Client.ReferenceObjects;
using LuckyAlchemyBot.Helper;
using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Item;
using System;
using System.Linq;

namespace LuckyAlchemyBot.Bot
{
    internal class MagicOptionGranter
    {
        #region Constructor

        public MagicOptionGranter()
        {
            SubscribeEvents();
        }

        #endregion Constructor

        #region Member

        private bool _shouldRun = true;

        #endregion Member

        #region Methods

        /// <summary>
        /// Subscribes the events
        /// </summary>
        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnAlchemySuccess", new Action<InventoryItem, InventoryItem, AlchemyType>(OnStoneAlchemySuccess));
            EventManager.SubscribeEvent("OnAlchemyFailed", new Action<InventoryItem, InventoryItem, AlchemyType>(OnStoneAlchemyFailed));
            EventManager.SubscribeEvent("OnAlchemyError", new Action<ushort, AlchemyType>(OnStoneAlchemyError));
            EventManager.SubscribeEvent("OnAlchemy", new Action<AlchemyType>(OnStoneAlchemy));
            EventManager.SubscribeEvent("OnFuseRequest", new Action<AlchemyAction, AlchemyType>(OnFuseRequest));
        }

        /// <summary>
        /// Stops this manager
        /// </summary>
        public void Stop()
        {
            _shouldRun = false;

            RequestHelper.SendCancelPacket();
        }

        /// <summary>
        /// Starts this manager
        /// </summary>
        public void Start()
        {
            _shouldRun = true;
        }

        /// <summary>
        /// Returns the translation name for an error code
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        private string GetErrorTranslationName(ushort errorCode)
        {
            switch (errorCode)
            {
                case 21536:
                    return "UIIT_MSG_STRGERR_ASTRAL";

                case 21537:
                    return "UIIT_MSG_ENCHANT_EQUIPCLASS_MISMATCH";

                case 21538:
                    return "UIIT_MSG_STRGERR_MAGICSTONE2_MAX";

                case 21540:
                    return "UIIT_MSG_STRGERR_ASTRAL";

                case 21541:
                    return "UIIT_MSG_TC_ERROR_ENCHANT_HONOR_ITEM";

                case 21542:
                    return "UIIT_MSG_REINFORCERR_ALREADY_DONE";

                case 21543:
                    return "UIIT_MSG_STRGERR_ASTRAL";

                case 21539:
                default:
                    return "UIIT_MSG_ENCHANT_FAILED";
            }
        }

        /// <summary>
        /// Runs a tick of this manager
        /// </summary>
        /// <param name="config">The configuration for this manager</param>
        public void Run(MagicOptionsConfig config)
        {
            if (config?.MagicStones?.Count == 0)
                Kernel.Bot.Stop();

            if (config == null || _shouldRun is false || config.Item == null || config.MagicStones == null || config.MagicStones?.Count == 0)
                return;

            //Loops over every stone that should be fused
            foreach (var stone in config.MagicStones)
            {
                //Wait for the next tick
                if (_shouldRun == false) break;
                if (stone.Value == null) continue;

                //Gets the current magic option info from the selected item if available
                var current = config.Item.MagicOptions.FirstOrDefault(m => m.Id == stone.Value.Id);

                //Enough immortal?
                if (stone.Value.Group == RefMagicOpt.MaterialAstral)
                {
                    var immortalInfo = config.Item.MagicOptions.FirstOrDefault(m =>
                        Game.ReferenceManager.GetMagicOption(m.Id).Group == RefMagicOpt.MaterialImmortal);

                    //Not enough immortal attribute -> Need to skip astral
                    if (immortalInfo?.Value <= current?.Value)
                        continue;
                }

                //Max value reached?
                var max = stone.Value.GetMaxValue();
                if (current == null || current.Value < max)
                {
                    RequestHelper.SendMagicStoneRequest(config.Item, stone.Key);

                    _shouldRun = false;
                }

            }

            if (_shouldRun)
            {
                Log.Notify("[LuckyAlchemyBot] Magic stone fusing finished!");

                Kernel.Bot.Stop();
            }
        }

        #endregion Methods

        #region Events

        /// <summary>
        /// Will be triggered if any fuse request was sent to the server
        /// </summary>
        /// <param name="action"></param>
        /// <param name="type"></param>
        private void OnFuseRequest(AlchemyAction action, AlchemyType type)
        {
            _shouldRun = false;
        }

        /// <summary>
        /// Will be triggered if any stone alchemy action response was sent from the server
        /// </summary>
        private void OnStoneAlchemy(AlchemyType type)
        {
            _shouldRun = true;
        }

        /// <summary>
        /// Will be triggered if a stone alchemy operation was successful
        /// </summary>
        /// <param name="newItem">The new item after the successful action</param>
        private void OnStoneAlchemySuccess(InventoryItem oldItem, InventoryItem newItem, AlchemyType type)
        {
            if (type != AlchemyType.MagicStone) return;
            if (oldItem == null) return;

            MagicOptionInfo changedOption = null;

            //Get the changed option of the item
            var isNew = false;
            foreach (var newMagicOption in newItem.MagicOptions)
            {
                var oldMagicOption = oldItem.MagicOptions.FirstOrDefault(m => m.Id == newMagicOption.Id);

                changedOption = newMagicOption;

                if (oldMagicOption == null)
                {
                    isNew = true;
                    changedOption = newMagicOption;

                    break;
                }

                if (oldMagicOption.Value == newMagicOption.Value) continue;
                
                changedOption = newMagicOption;

                break;
            }

            if (changedOption == null) return;

            //Print the messages
            var record = Game.ReferenceManager.GetMagicOption(changedOption.Id);

            var message = !isNew
                    ? Game.ReferenceManager.GetTranslation("UIIT_MSG_ALCHEMY_CHANGE_CATTR").JoymaxFormat(newItem.Record.GetRealName(), record.GetGroupTranslation(), $"{oldItem.MagicOptions.FirstOrDefault(m => m.Id == changedOption.Id).Value} -> {changedOption.Value}")
                    : Game.ReferenceManager.GetTranslation("UIIT_MSG_ALCHEMY_APPEND_ATTR").JoymaxFormat(record.GetGroupTranslation(), newItem.Record.GetRealName());

            Globals.View.AddLog(newItem.Record.GetRealName(), true, message);
        }

        /// <summary>
        /// Will be triggered if a stone alchemy action failed
        /// </summary>
        /// <param name="newItem">The new item after the operation failed</param>
        private void OnStoneAlchemyFailed(InventoryItem oldItem, InventoryItem newItem, AlchemyType type)
        {
            if (type != AlchemyType.MagicStone) return;

            Globals.View.AddLog(newItem.Record.GetRealName(), false, Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_FAIL"));

            _shouldRun = true;
        }

        /// <summary>
        /// Will be triggered if an stone alchemy error
        /// </summary>
        /// <param name="errorCode">The error code</param>
        private void OnStoneAlchemyError(ushort errorCode, AlchemyType type)
        {
            if (type != AlchemyType.MagicStone) return;

            var translationName = GetErrorTranslationName(errorCode);

            Globals.View.AddLog(Game.Player.ActiveAlchemyItems?.Count > 0 ? Game.Player.ActiveAlchemyItems.First().Value.Record.GetRealName() : "", false, Game.ReferenceManager.GetTranslation(translationName));
        }

        #endregion Events
    }
}