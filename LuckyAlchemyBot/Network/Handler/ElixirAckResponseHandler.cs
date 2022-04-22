using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Objects;

namespace LuckyAlchemyBot.Network.Handler
{
    internal class ElixirAckResponseHandler : IPacketHandler
    {
        #region Properties

        public ushort Opcode => 0xB150;

        public PacketDestination Destination => PacketDestination.Client;

        #endregion Properties

        public void Invoke(Packet packet)
        {
            EventManager.FireEvent("OnElixirAlchemy");

            var result = packet.ReadByte();

            if (result == 2)
            {
                EventManager.FireEvent("OnElixirAlchemyCanceled");

                Log.Error($"[LuckyAlchemyBot] Enhancement error: 0x{packet.ReadByte():FF}");

                return;
            }

            var action = packet.ReadByte();
            if (action == 1)
            {
                EventManager.FireEvent("OnElixirAlchemyCanceled");

                return;
            }

            var isSuccess = packet.ReadBool();
            var slot = packet.ReadByte();

            if (!isSuccess)
            {
                var isDestroyed = packet.ReadBool();

                if (isDestroyed)
                    EventManager.FireEvent("OnElixirAlchemyDestroyed", slot);
                else
                    EventManager.FireEvent("OnElixirAlchemyFailed", InventoryItem.FromPacket(packet, slot));

                return;
            }

            EventManager.FireEvent("OnElixirAlchemySuccess", InventoryItem.FromPacket(packet, slot));
        }
    }
}