using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Objects;

namespace LuckyAlchemyBot.Network.Handler
{
    internal class StoneAckResponseHandler : IPacketHandler
    {
        #region Properties

        public ushort Opcode => 0xB151;

        public PacketDestination Destination => PacketDestination.Client;

        #endregion Properties

        public void Invoke(Packet packet)
        {
            EventManager.FireEvent("OnStoneAlchemy");
            
            var result = packet.ReadByte();

            if (result == 2) //Error
            {
                EventManager.FireEvent("OnStoneAlchemyCanceled");

                Log.Error($"[LuckyAlchemyBot] Stone fuse error: 0x{packet.ReadByte():FF}");

                return;
            }

            var action = packet.ReadByte();
            if (action == 1)
            {
                EventManager.FireEvent("OnStoneAlchemyCanceled");

                return;
            }

            var isSuccess = packet.ReadBool();
            var slot = packet.ReadByte();

            if (!isSuccess)
            {
                var isDestroyed = packet.ReadBool();

                if (isDestroyed)
                    EventManager.FireEvent("OnStoneAlchemyDestroyed");
                else
                    EventManager.FireEvent("OnStoneAlchemyFailed", InventoryItem.FromPacket(packet, slot));

                return;
            }
            
            EventManager.FireEvent("OnStoneAlchemySuccess", InventoryItem.FromPacket(packet, slot));
        }
    }
}