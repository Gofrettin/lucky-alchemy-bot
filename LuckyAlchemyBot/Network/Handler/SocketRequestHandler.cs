using RSBot.Core.Network;

namespace LuckyAlchemyBot.Network.Handler
{
    internal class SocketRequestHandler : IPacketHandler
    {
        #region Properties

        public ushort Opcode => 0x716A;

        public PacketDestination Destination => PacketDestination.Server;

        #endregion

        #region Methods

        public void Invoke(Packet packet)
        {
            FuseRequestHelper.Invoke(packet);
        }

        #endregion
    }
}
