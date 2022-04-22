using LuckyAlchemyBot.Network.Handler;
using LuckyAlchemyBot.Objects;
using RSBot.Core;
using RSBot.Core.Network;
using RSBot.Core.Objects;

namespace LuckyAlchemyBot.Helper
{
    internal class RequestHelper
    {
        #region Methods

        public static void SendCancelPacket()
        {
            var packet = new Packet(0x7150);
            packet.WriteByte(0x01);

            packet.Lock();
            Kernel.Proxy.Server.Send(packet);
        }

        public static void SendMagicStoneRequest(InventoryItem item, InventoryItem magicStone)
        {
            Log.Notify($"[LuckyAlchemyBot] Fusing {magicStone.Record.GetRealName()}...");

            var packet = new Packet(0x7151);

            packet.WriteByte(Enums.AlchemyAction.Fuse); //Fuse
            packet.WriteByte(Enums.AlchemyType.MagicStone); //MagicStone
            packet.WriteByte(2); //Slot count

            packet.WriteByte(item.Slot);
            packet.WriteByte(magicStone.Slot);
     
            packet.Lock();
            Kernel.Proxy.Server.Send(packet);

            FuseRequestHelper.Invoke(packet);
        }

        #endregion Methods
    }
}