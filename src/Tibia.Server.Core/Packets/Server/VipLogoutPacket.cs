namespace Tibia.Server.Core.Packets.Server
{
    public class VipLogoutPacket:Packet
    {
        public static void Add(NetworkMessage message,uint id)
        {
            message.AddByte((byte)ServerPacketType.VipLogout);
            message.AddUInt32(id);
        }
    }
}
