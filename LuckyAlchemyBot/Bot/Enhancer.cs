﻿using LuckyAlchemyBot.Helper;
using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Objects;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LuckyAlchemyBot.Bot
{
    internal class Enhancer
    {
        #region Members

        private bool _shouldRun;

        private InventoryItem _luckyPowder;

        #endregion Members

        private EnhancementConfig _config;

        #region Constructor

        /// <summary>
        /// Subscribes events
        /// </summary>
        public Enhancer()
        {
            SubscribeEvents();

            _shouldRun = true;
        }

        #endregion Constructor

        #region Methods

        public void Stop()
        {
            _shouldRun = false;
            _config = null;

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
        /// Subscribes all required events
        /// </summary>
        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnAlchemyCanceled", new Action<AlchemyType>(OnElixirAlchemyCanceled));
            EventManager.SubscribeEvent("OnAlchemyDestroyed",
                new Action<InventoryItem, AlchemyType>(OnElixirAlchemyDestroyed));
            EventManager.SubscribeEvent("OnAlchemySuccess",
                new Action<InventoryItem, InventoryItem, AlchemyType>(OnElixirAlchemySuccess));
            EventManager.SubscribeEvent("OnAlchemy", OnElixirAlchemy);
            EventManager.SubscribeEvent("OnAlchemyFailed",
                new Action<InventoryItem, InventoryItem, AlchemyType>(OnElixirAlchemyFailed));
            EventManager.SubscribeEvent("OnFuseRequest", new Action<AlchemyAction, AlchemyType>(OnFuseRequest));
        }

        /// <summary>
        /// Runs a new tick of this manager
        /// </summary>
        /// <param name="config"></param>
        public void Run(EnhancementConfig config)
        {
            if (config?.Item == null)
                Kernel.Bot.Stop();

            //Config incomplete?
            if (!_shouldRun || config == null || Globals.Botbase.Engine != Engine.Enhancement || config.Item == null ||
                config.Elixir == null) return;

            _config = config;
            _luckyPowder = AlchemyItemHelper.GetLuckyPowder(config.Item);

            //Bot should stop without lucky powder?
            if ((_luckyPowder == null || _luckyPowder.Amount == 0) && config.StopIfLuckyPowderEmpty)
            {
           
                Log.Warn("[LuckyAlchemyBot] No lucky powder left, stopping alchemy now!");

                Kernel.Bot.Stop();
                MessageBox.Show("No more lucky powder left in the inventory.", "Lucky powder", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            //Max opt level reached?
            if (config.Item.OptLevel >= config.MaxOptLevel)
            {
                Log.Warn($"[LuckyAlchemyBot] Item is already +{config.Item.OptLevel}");

                Kernel.Bot.Stop();

                return;
            }

            //Use steady stone?
            if (_config.UseSteadyStones && _config.Item.OptLevel >= 5)
            {
                var steadyStone = AlchemyItemHelper.GetSteadyStone(config.Item);

                if (steadyStone != null && steadyStone.Amount > 0 &&
                    !AlchemyItemHelper.HasMagicOption(config.Item, RefMagicOpt.MaterialSteady))
                {
                    RequestHelper.SendMagicStoneRequest(_config.Item, steadyStone);

                    _shouldRun = false;

                    return;
                }
            }

            //Use lucky stone?
            if (_config.UseLuckyStones && _config.Item.OptLevel >= 5)
            {
                var luckyStone = AlchemyItemHelper.GetLuckyStone(config.Item);

                if (luckyStone != null && luckyStone.Amount > 0 &&
                    !AlchemyItemHelper.HasMagicOption(config.Item, RefMagicOpt.MaterialLuck))
                {
                    RequestHelper.SendMagicStoneRequest(_config.Item, luckyStone);

                    _shouldRun = false;

                    return;
                }
            }

            //Use immortal stone?
            if (_config.UseImmortalStones && _config.Item.OptLevel >= 5)
            {
                var immortalStone = AlchemyItemHelper.GetImmortalStone(config.Item);

                if (immortalStone != null && immortalStone.Amount > 0 &&
                    !AlchemyItemHelper.HasMagicOption(config.Item, RefMagicOpt.MaterialImmortal))
                {
                    RequestHelper.SendMagicStoneRequest(_config.Item, immortalStone);

                    _shouldRun = false;

                    return;
                }
            }

            //Use astral stone?
            if (_config.UseAstralStones && _config.Item.OptLevel >= 5)
            {
                var astralStone = AlchemyItemHelper.GetAstralStone(config.Item);

                if (astralStone != null && astralStone.Amount > 0 &&
                    !AlchemyItemHelper.HasMagicOption(config.Item, RefMagicOpt.MaterialAstral))
                {
                    //Is immortal high enough?
                    var magicOption =
                        Game.ReferenceManager.GetMagicOption(RefMagicOpt.MaterialImmortal,
                            (byte)config.Item.Record.Degree);

                    //Can not fuse if immortal is not available (or not high enough)
                    var magicOptionInfo = config.Item.MagicOptions?.FirstOrDefault(m => m.Id == magicOption.Id);
                    if (magicOptionInfo == null)
                    {
                        Log.Notify(
                            $"[LuckyAlchemyBot] Could not fuse {astralStone.Record.GetRealName()} because the immortal is not high enough");

                        _config.UseAstralStones = false;
                        return;
                    }

                    RequestHelper.SendMagicStoneRequest(_config.Item, astralStone);

                    _shouldRun = false;

                    return;
                }
            }

            var nextPlusValue = config.Item.OptLevel + 1;

            Log.Notify($"[LuckyAlchemyBot] Attempting +{nextPlusValue}...");

            SendFusePacket();

            _shouldRun = false;
        }

        /// <summary>
        /// Sends the fuse packet to the server
        /// </summary>
        private void SendFusePacket()
        {
            if (_config == null || !_shouldRun) return;

            var hasLuckyPowder = _luckyPowder != null && _luckyPowder.Amount > 0;

            var packet = new Packet(0x7150);
            packet.WriteByte(AlchemyAction.Fuse); //fuse
            packet.WriteByte(AlchemyType.Elixir); //type (Elixir)

            packet.WriteByte(hasLuckyPowder ? (byte)3 : (byte)2);

            packet.WriteByte(_config.Item.Slot);
            packet.WriteByte(_config.Elixir.Slot);

            if (hasLuckyPowder)
                packet.WriteByte(_luckyPowder.Slot);

            packet.Lock();

            Kernel.Proxy.Server.Send(packet);

            RequestHelper.ManuallyHandleFuseRequest(packet);
        }

        #endregion Methods

        #region Events

        /// <summary>
        /// Will be triggered if any elixir alchemy operation was completed
        /// </summary>
        private void OnElixirAlchemy()
        {
            _shouldRun = true;
        }

        /// <summary>
        /// Will be triggered if any elixir alchemy operation was successful
        /// </summary>
        /// <param name="newItem"></param>

        private void OnElixirAlchemySuccess(InventoryItem oldItem, InventoryItem newItem, AlchemyType type)
        {
            if (type != AlchemyType.Elixir) return;

            var message = Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_SUCCESS")
                .JoymaxFormat(newItem.OptLevel);

            Log.Notify(message);
            Globals.View.AddLog(newItem.Record.GetRealName(), true, message);

            if (_config != null)
                _config.Item = newItem;

            _shouldRun = true;
        }

        /// <summary>
        /// Will be triggered if any elixir alchemy operation was canceled
        /// </summary>
        ///
        private void OnElixirAlchemyCanceled(AlchemyType type)
        {
            if (type != AlchemyType.Elixir) return;

            Log.Notify(Game.ReferenceManager.GetTranslation("UIIT_MSG_ENCHANT_CANCEL"));

            _shouldRun = false;
        }

        /// <summary>
        /// Will be triggered if the selected item was destroyed. Logs a message and stops the bot
        /// </summary>
        /// <param name="oldItem">The the item that has been destroyed</param>
        /// <param name="type">The type of alchemy that was triggered</param>
        private void OnElixirAlchemyDestroyed(InventoryItem oldItem, AlchemyType type)
        {
            _shouldRun = false;
        }

        /// <summary>
        /// Will be triggered if any elixir alchemy operation has failed. Logs a message and resets the current item
        /// </summary>
        /// <param name="newItem">The new item after the action has failed</param>
        /// <param name="type">The type of alchemy that was triggered</param>
        private void OnElixirAlchemyFailed(InventoryItem oldItem, InventoryItem newItem, AlchemyType type)
        {
            if (type != AlchemyType.Elixir) return;

            _shouldRun = true;
            var message = Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_FAIL");
            Log.Warn(message);
            Globals.View.AddLog(newItem.Record.GetRealName(), false, message);

            if (oldItem == null) return;

            message = string.Empty;
            if (newItem.Durability < oldItem.Durability)
                message = Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_FAILDOWN_DURABILITY")
                    .JoymaxFormat(newItem.Durability);

            if (oldItem.OptLevel > 0 && newItem.OptLevel == 0)
                message = Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_FAIL_RESULT_OPTLV_ZERO");

            if (oldItem.OptLevel > 0 && oldItem.OptLevel < newItem.OptLevel)
                message = Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_FAIL_RESULT_OPTLV_DOWN")
                    .JoymaxFormat(newItem.OptLevel, _config.Item.OptLevel - newItem.OptLevel);

            //Additional message
            if (message != string.Empty)
            {
                Log.Debug(message);
                Globals.View.AddLog(newItem.Record.GetRealName(), false, message);
            }

            if (_config != null)
                _config.Item = newItem;
        }

        private void OnFuseRequest(AlchemyAction action, AlchemyType type)
        {
            _shouldRun = false;
        }

        #endregion Events
    }
}