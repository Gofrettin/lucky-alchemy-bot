using LuckyAlchemyBot.Client.ReferenceObjects;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Objects;
using System;

namespace LuckyAlchemyBot.Bot
{
    internal class Enhancer
    {
        #region Fields

        private bool _shouldRun = false;

        private InventoryItem _luckyPowder;

        #endregion Fields

        private EnhancementConfig _config;

        #region Constructor

        public Enhancer()
        {
            SubscribeEvents();

            _shouldRun = true;
        }

        #endregion Constructor

        #region Events

        private void OnElixirAlchemy()
        {
            _shouldRun = true;
        }

        private void OnElixirAlchemySuccess(InventoryItem newItem)
        {
            if (_config == null) return;
            var message = Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_SUCCESS").FormatJoymaxTranslation(newItem.OptLevel);
            Log.Notify(message);
            Globals.View.AddLog(newItem.Record.GetRealName(), true, message);

            _config.Item = newItem;
        }

        private void OnElixirAlchemyCanceled()
        {
            Log.Notify("[LuckyAlchemyBot] Alchemy operation cancelled!");
        }

        private void OnElixirAlchemyDestroyed()
        {

            if (_config == null) return;
            var message = $"{Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_BREAKDOWN")}";
            Log.Warn(message);
            Globals.View.AddLog(_config.Item.Record.GetRealName(), false, message);

            _shouldRun = false;
            Globals.View.SelectedItem = null;

            Kernel.Bot.Stop();
        }

        private void OnElixirAlchemyFailed(InventoryItem newItem)
        {
            if (_config == null) return;
            var message = $"{Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_FAIL")}";
            Log.Warn(message);
            Globals.View.AddLog(newItem.Record.GetRealName(), false, message);

            message = string.Empty;
            if (newItem.Durability < _config.Item.Durability)
                message = Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_FAILDOWN_DURABILITY").FormatJoymaxTranslation(newItem.Durability);

            if (_config.Item.OptLevel > 0 && newItem.OptLevel == 0)
                message = Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_FAIL_RESULT_OPTLV_ZERO");

            if (_config.Item.OptLevel > 0 && _config.Item.OptLevel < newItem.OptLevel)
                message = Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_FAIL_RESULT_OPTLV_DOWN").FormatJoymaxTranslation(newItem.OptLevel, _config.Item.OptLevel - newItem.OptLevel);
        
            //Additional message
            if (message != string.Empty)
            {
                Log.Debug(message);
                Globals.View.AddLog(newItem.Record.GetRealName(), false, message);
            }

            _config.Item = newItem;
        }

        #endregion Events

        #region Methods

        public void Stop()
        {
            _shouldRun = false;
            _config = null;

            SendCancelPacket();
        }

        public void Start()
        {
            _shouldRun = true;
        }

        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnElixirAlchemyCanceled", OnElixirAlchemyCanceled);
            EventManager.SubscribeEvent("OnElixirAlchemyDestroyed", OnElixirAlchemyDestroyed);
            EventManager.SubscribeEvent("OnElixirAlchemySuccess", new Action<InventoryItem>(OnElixirAlchemySuccess));
            EventManager.SubscribeEvent("OnElixirAlchemy", OnElixirAlchemy);
            EventManager.SubscribeEvent("OnElixirAlchemyFailed", new Action<InventoryItem>(OnElixirAlchemyFailed));
        }

        public void Run(EnhancementConfig config)
        {
            if (!_shouldRun || config == null || Globals.Botbase.Engine != Engine.Enhancement) return;

            _config = config;
            _luckyPowder = Helper.AlchemyItemHelper.GetLuckyPowder(config.Item);

            if ((_luckyPowder == null || _luckyPowder.Amount < 0) && config.StopIfLuckyPowderEmpty)
            {
                Log.Warn("[LuckyAlchemyBot] No lucky powder left, stopping alchemy now!");

                Kernel.Bot.Stop();

                return;
            }

            if (config.Item.OptLevel >= config.MaxOptLevel)
            {
                Log.Warn($"[LuckyAlchemyBot] Item is already +{config.Item.OptLevel}");

                Kernel.Bot.Stop();

                return;
            }

            var steadyStone = Helper.AlchemyItemHelper.GetSteadyStone(config.Item);
            var luckyStone = Helper.AlchemyItemHelper.GetLuckyStone(config.Item);

            if (_config.UseImmortalStones && _config.Item.OptLevel >= 5)
            {
                var immortalStone = Helper.AlchemyItemHelper.GetImmortalStone(config.Item);

                if (immortalStone != null && immortalStone.Amount > 0 && !Helper.AlchemyItemHelper.HasMagicOption(config.Item, MagicOption.MaterialImmortal))
                {
                    SendMagicStoneRequest(immortalStone);

                    _shouldRun = false;

                    return;
                }
            }

            if (_config.UseAstralStones && _config.Item.OptLevel >= 5)
            {
                var astralStone = Helper.AlchemyItemHelper.GetAstralStone(config.Item);

                if (astralStone != null && astralStone.Amount > 0 && !Helper.AlchemyItemHelper.HasMagicOption(config.Item, MagicOption.MaterialAstral))
                {
                    SendMagicStoneRequest(astralStone);

                    _shouldRun = false;
                    
                    return;
                }
            }



            var nextPlusValue = config.Item.OptLevel + 1;

            Log.Notify($"[LuckyAlchemyBot] Attempting +{nextPlusValue}...");

            SendFusePacket();

            _shouldRun = false;
        }

        private void SendFusePacket()
        {
            if (_config == null || !_shouldRun) return;

            var hasLuckyPowder = _luckyPowder != null && _luckyPowder.Amount > 0;

            var packet = new Packet(0x7150);
            packet.WriteByte(2); //fuse
            packet.WriteByte(3); //type (Elixir)

            if (hasLuckyPowder)
                packet.WriteByte(3); //3 slots
            else
                packet.WriteByte(2); //2 slots

            packet.WriteByte(_config.Item.Slot);
            packet.WriteByte(_config.Elixir.Slot);

            if (hasLuckyPowder)
                packet.WriteByte(_luckyPowder.Slot);

            packet.Lock();

            Kernel.Proxy.Server.Send(packet);
        }

        private void SendCancelPacket()
        {
            System.Threading.Thread.Sleep(500);

            var packet = new Packet(0x7150);
            packet.WriteByte(0x01);

            packet.Lock();
            Kernel.Proxy.Server.Send(packet);
        }

        private void SendMagicStoneRequest(InventoryItem magicStone)
        {
            Log.Notify($"[LuckyAlchemyBot] Fusing {magicStone.Record.GetRealName()}...");
            var packet = new Packet(0x7151);

            packet.WriteByte(2); //Fuse
            packet.WriteByte(4); //MagicStone
            packet.WriteByte(2); //Slot count

            packet.WriteByte(_config.Item.Slot);
            packet.WriteByte(magicStone.Slot);

            packet.Lock();
            Kernel.Proxy.Server.Send(packet);
        }

        #endregion Methods
    }
}