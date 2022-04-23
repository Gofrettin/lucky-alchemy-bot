using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System;
using System.Linq;
using LuckyAlchemyBot.Client.ReferenceObjects;

namespace LuckyAlchemyBot.Subscriber
{
    internal class AlchemyEventsSubscriber
    {
        public static void Subscribe()
        {
            EventManager.SubscribeEvent("OnAlchemyError", new Action<ushort, AlchemyType>(OnAlchemyError));
            EventManager.SubscribeEvent("OnAlchemyDestroyed", new Action<InventoryItem, AlchemyType>(OnAlchemyDestroyed));
            EventManager.SubscribeEvent("OnFuseRequest", new Action<AlchemyAction, AlchemyType>(OnFuseRequest));
            EventManager.SubscribeEvent("OnMagicOptionGranted", new Action<byte, string>(OnMagicOptionGranted));
            EventManager.SubscribeEvent("OnMagicOptionUpdated", new Action<InventoryItem, InventoryItem>(OnMagicOptionUpdated));
        }

        private static void OnMagicOptionGranted(byte slot, string group)
        {
            var item = Game.Player.Inventory.GetItemAt(slot);
            var option = Game.ReferenceManager.GetMagicOption(group, (byte) item.Record.Degree);

            Game.ReferenceManager.GetTranslation("UIIT_MSG_ALCHEMY_APPEND_ATTR").JoymaxFormat(option.GetGroupTranslation(), item.Record.GetRealName());
        }

        private static void OnMagicOptionUpdated(InventoryItem oldItem, InventoryItem newItem)
        {
            var oldMagicOptions = oldItem.MagicOptions;
            var newItemMagicOptions = newItem.MagicOptions;


        }

        private static void OnAlchemyDestroyed(InventoryItem oldItem, AlchemyType type)
        {
            if (!LuckyAlchemyBot.IsActive)
                return;

            Globals.Botbase.EnhancementConfig = null;
            Globals.Botbase.MagicOptionsConfig = null;

            Globals.View.SelectedItem = null;
            Globals.View.AddLog(oldItem.Record.GetRealName(), false, Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_BREAKDOWN"));
            Log.Warn($"[LuckyAlchemyBot] The item has been destroyed, stopping now...");

            Kernel.Bot?.Stop();
        }

        private static void OnAlchemyError(ushort errorCode, AlchemyType type)
        {
            if (errorCode == 0x5423)
            {
                return;
            }
            if (!LuckyAlchemyBot.IsActive)
                return;

            Kernel.Bot?.Stop();
            Log.Warn($"[LuckyAlchemyBot] Alchemy fusion error: {errorCode:X}");
        }

        /// <summary>
        /// Will be triggered if any fuse request (either elixir or magic stone..) was sent to the server. Adds a log message.
        /// </summary>
        /// <param name="action">The alchemy action</param>
        /// <param name="type">The type of alchemy</param>
        private static void OnFuseRequest(AlchemyAction action, AlchemyType type)
        {
            var elixir = Game.Player.ActiveAlchemyItems.ElementAtOrDefault(1);
            var item = Game.Player.ActiveAlchemyItems.ElementAtOrDefault(0);

            if (elixir.Value == null || item.Value == null) return;
            switch (type)
            {
                case AlchemyType.Elixir:
                    Globals.View.AddLog(item.Value.Record.GetRealName(), true, $"Fusing elixir [{elixir.Value.Record.GetRealName()}");
                    break;

                case AlchemyType.MagicStone:
                    Globals.View.AddLog(item.Value.Record.GetRealName(), true, $"Fusing magic stone [{elixir.Value.Record.GetRealName()}");
                    break;

                case AlchemyType.AttributeStone:
                    Globals.View.AddLog(item.Value.Record.GetRealName(), true, $"Fusing attribute stone [{elixir.Value.Record.GetRealName()}");
                    break;

                default:
                    Globals.View.AddLog(item.Value.Record.GetRealName(), true, $"Fusing [{elixir.Value.Record.GetRealName()}");
                    break;
            }
        }
    }
}