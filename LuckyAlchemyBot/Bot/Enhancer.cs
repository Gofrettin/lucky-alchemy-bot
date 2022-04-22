using LuckyAlchemyBot.Client.ReferenceObjects;
using LuckyAlchemyBot.Helper;
using LuckyAlchemyBot.Network.Handler;
using LuckyAlchemyBot.Objects;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Objects;
using System;
using System.Linq;

namespace LuckyAlchemyBot.Bot
{
    internal class Enhancer
    {
        #region Members

        private bool _shouldRun = false;

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
            EventManager.SubscribeEvent("OnElixirAlchemyCanceled", OnElixirAlchemyCanceled);
            EventManager.SubscribeEvent("OnElixirAlchemyDestroyed", new Action<byte>(OnElixirAlchemyDestroyed));
            EventManager.SubscribeEvent("OnElixirAlchemySuccess", new Action<InventoryItem>(OnElixirAlchemySuccess));
            EventManager.SubscribeEvent("OnElixirAlchemy", OnElixirAlchemy);
            EventManager.SubscribeEvent("OnElixirAlchemyFailed", new Action<InventoryItem>(OnElixirAlchemyFailed));
            EventManager.SubscribeEvent("OnElixirAlchemyError", new Action<ushort>(OnElixirAlchemyError));
            EventManager.SubscribeEvent("OnFuseRequest", new Action<Enums.AlchemyAction, Enums.AlchemyType>(OnFuseRequest));
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
            if (!_shouldRun || config == null || Globals.Botbase.Engine != Engine.Enhancement || config.Item == null || config.Elixir == null) return;

            _config = config;
            _luckyPowder = AlchemyItemHelper.GetLuckyPowder(config.Item);

            //Bot should stop without lucky powder?
            if ((_luckyPowder == null || _luckyPowder.Amount == 0) && config.StopIfLuckyPowderEmpty)
            {
                Log.Warn("[LuckyAlchemyBot] No lucky powder left, stopping alchemy now!");

                Kernel.Bot.Stop();

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

                if (steadyStone != null && steadyStone.Amount > 0 && !AlchemyItemHelper.HasMagicOption(config.Item, MagicOption.MaterialSteady))
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

                if (luckyStone != null && luckyStone.Amount > 0 && !AlchemyItemHelper.HasMagicOption(config.Item, MagicOption.MaterialLuck))
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

                if (immortalStone != null && immortalStone.Amount > 0 && !AlchemyItemHelper.HasMagicOption(config.Item, MagicOption.MaterialImmortal))
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

                if (astralStone != null && astralStone.Amount > 0 && !AlchemyItemHelper.HasMagicOption(config.Item, MagicOption.MaterialAstral))
                {
                    //Is immortal high enough?
                    var magicOption =
                        Globals.ReferenceManager.GetMagicOption(MagicOption.MaterialImmortal, (byte)config.Item.Record.Degree);

                    //Can not fuse if immortal is not available (or not high enough)
                    var magicOptionInfo = config.Item.MagicOptions?.FirstOrDefault(m => m.Id == magicOption.Id);
                    if (magicOptionInfo == null)
                    {
                        Log.Notify($"[LuckyAlchemyBot] Could not fuse {astralStone.Record.GetRealName()} because the immortal is not high enough");

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
            packet.WriteByte(Enums.AlchemyAction.Fuse); //fuse
            packet.WriteByte(Enums.AlchemyType.Elixir); //type (Elixir)

            packet.WriteByte(hasLuckyPowder ? (byte)3 : (byte)2);

            packet.WriteByte(_config.Item.Slot);
            packet.WriteByte(_config.Elixir.Slot);

            if (hasLuckyPowder)
                packet.WriteByte(_luckyPowder.Slot);

            packet.Lock();

            Kernel.Proxy.Server.Send(packet);

            FuseRequestHelper.Invoke(packet);
        }

        #endregion Methods

        #region Events

        /// <summary>
        /// Will be triggered if the magic stone fusing action got an error
        /// </summary>
        /// <param name="errorCode"></param>
        private void OnElixirAlchemyError(ushort errorCode)
        {
            Log.Warn($"[LuckyAlchemyBot] Enhancing error: {errorCode:X}");

            Kernel.Bot.Stop();
        }

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

        private void OnElixirAlchemySuccess(InventoryItem newItem)
        {
            var message = Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_SUCCESS").JoymaxFormat(newItem.OptLevel);

            Log.Notify(message);
            Globals.View.AddLog(newItem.Record.GetRealName(), true, message);

            if (_config != null)
                _config.Item = newItem;
        }

        /// <summary>
        /// Will be triggered if any elixir alchemy operation was canceled
        /// </summary>
        private void OnElixirAlchemyCanceled()
        {
            Log.Notify(Game.ReferenceManager.GetTranslation("UIIT_MSG_ENCHANT_CANCEL"));

            _shouldRun = false;
        }

        /// <summary>
        /// Will be triggered if the selected item was destroyed. Logs a message and stops the bot
        /// </summary>
        /// <param name="slot">The slot at which the item was destroyed</param>
        private void OnElixirAlchemyDestroyed(byte slot)
        {
            Globals.Botbase.EnhancementConfig = null;
            var message = Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_BREAKDOWN");
            Log.Warn(message);

            if (Globals.AlchemyItems == null || Globals.AlchemyItems.Count == 0) return;

            var oldItem = Globals.AlchemyItems.First().Value;
            Globals.View.AddLog(oldItem.Record.GetRealName(), false, message);

            if (_config == null) return;

            _shouldRun = false;
            Globals.View.SelectedItem = null;

            Kernel.Bot.Stop();
        }

        /// <summary>
        /// Will be triggered if any elixir alchemy operation has failed. Logs a message and resets the current item
        /// </summary>
        /// <param name="newItem">The new item after the action has failed</param>
        private void OnElixirAlchemyFailed(InventoryItem newItem)
        {
            var message = Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_FAIL");
            Log.Warn(message);
            Globals.View.AddLog(newItem.Record.GetRealName(), false, message);
            var oldItem = Globals.AlchemyItems.First().Value;

            if (oldItem == null) return;

            message = string.Empty;
            if (newItem.Durability < oldItem.Durability)
                message = Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_FAILDOWN_DURABILITY").JoymaxFormat(newItem.Durability);

            if (oldItem.OptLevel > 0 && newItem.OptLevel == 0)
                message = Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_FAIL_RESULT_OPTLV_ZERO");

            if (oldItem.OptLevel > 0 && oldItem.OptLevel < newItem.OptLevel)
                message = Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_FAIL_RESULT_OPTLV_DOWN").JoymaxFormat(newItem.OptLevel, _config.Item.OptLevel - newItem.OptLevel);

            //Additional message
            if (message != string.Empty)
            {
                Log.Debug(message);
                Globals.View.AddLog(newItem.Record.GetRealName(), false, message);
            }

            if (_config != null)
                _config.Item = newItem;
        }

        /// <summary>
        /// Will be triggered if any fuse request (either elixir or magic stone..) was sent to the server. Adds a log message.
        /// </summary>
        /// <param name="action">The alchemy action</param>
        /// <param name="type">The type of alchemy</param>
        private void OnFuseRequest(Enums.AlchemyAction action, Enums.AlchemyType type)
        {
            _shouldRun = false;

            var elixir = Globals.AlchemyItems.ElementAtOrDefault(1);
            var item = Globals.AlchemyItems.ElementAtOrDefault(0);

            if (elixir.Value == null || item.Value == null) return;

            switch (type)
            {
                case Enums.AlchemyType.Elixir:
                    Globals.View.AddLog(item.Value.Record.GetRealName(), true, $"Fusing elixir [{elixir.Value.Record.GetRealName()}");
                    break;

                case Enums.AlchemyType.MagicStone:
                    Globals.View.AddLog(item.Value.Record.GetRealName(), true, $"Fusing magic stone [{elixir.Value.Record.GetRealName()}");
                    break;

                case Enums.AlchemyType.AttributeStone:
                    Globals.View.AddLog(item.Value.Record.GetRealName(), true, $"Fusing attribute stone [{elixir.Value.Record.GetRealName()}");
                    break;

                default:
                    Globals.View.AddLog(item.Value.Record.GetRealName(), true, $"Fusing [{elixir.Value.Record.GetRealName()}");
                    break;
            }
        }

        #endregion Events
    }
}