using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System;

namespace LuckyAlchemyBot.Subscriber
{
    internal static class AlchemySubscriber
    {
        public static void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnElixirAlchemyDestroyed", new Action<byte>(OnAlchemyDestroyed));
            EventManager.SubscribeEvent("OnElixirAlchemySuccess", new Action<InventoryItem>(OnAlchemySuccess));
            EventManager.SubscribeEvent("OnElixirAlchemyFailed", new Action<InventoryItem>(OnAlchemyFailed));

            EventManager.SubscribeEvent("OnStoneAlchemyDestroyed", new Action<byte>(OnAlchemyDestroyed));
            EventManager.SubscribeEvent("OnStoneAlchemySuccess", new Action<InventoryItem>(OnAlchemySuccess));
            EventManager.SubscribeEvent("OnStoneAlchemyFailed", new Action<InventoryItem>(OnAlchemyFailed));
        }

        private static void OnAlchemySuccess(InventoryItem newItem)
        {
            Game.Player.Inventory.RemoveItemAt(newItem.Slot);
            Game.Player.Inventory.Items.Add(newItem);
        }

        private static void OnAlchemyDestroyed(byte slot)
        {
            Game.Player.Inventory.RemoveItemAt(slot);
        }

        private static void OnAlchemyFailed(InventoryItem newItem)
        {
            Game.Player.Inventory.RemoveItemAt(newItem.Slot);
            Game.Player.Inventory.Items.Add(newItem);
        }
    }
}
