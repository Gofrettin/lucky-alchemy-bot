using LuckyAlchemyBot.Objects;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Objects;
using System.Collections.Generic;

namespace LuckyAlchemyBot.Network.Handler
{
    internal static class FuseRequestHelper
    {
        #region Methods

        /// <summary>
        /// Updates the current alchemy items
        /// </summary>
        /// <param name="packet"></param>
        public static void Invoke(Packet packet)
        {
            var action = (Enums.AlchemyAction)packet.ReadByte();

            if (action != Enums.AlchemyAction.Fuse) return;

            var type = (Enums.AlchemyType)packet.ReadByte();
            if (type == Enums.AlchemyType.SocketInsert)
            {
                var item = Game.Player.Inventory.GetItemAt(packet.ReadByte()); //Target item
                var socketItem = Game.Player.Inventory.GetItemAt(packet.ReadByte()); //Target item

                if (item != null && socketItem != null)
                    Globals.AlchemyItems = new Dictionary<byte, InventoryItem>
                    {
                        { item.Slot, item },
                        { socketItem.Slot, item }
                    };

                return;
            }

            var slots = packet.ReadByteArray(packet.ReadByte());

            Globals.AlchemyItems = new Dictionary<byte, InventoryItem>(slots.Length);

            for (var i = 0; i < slots.Length; i++)
            {
                var item = Game.Player.Inventory.GetItemAt(slots[i]);

                if (item != null)
                    Globals.AlchemyItems.Add(item.Slot, item);
            }

            EventManager.FireEvent("OnFuseRequest", action, type);
        }

        #endregion Methods
    }
}