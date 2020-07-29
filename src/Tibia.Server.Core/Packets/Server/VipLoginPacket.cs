namespace Tibia.Server.Core.Packets.Server
{
    public class VipLoginPacket : Packet
    {
        public static void Add(NetworkMessage message,uint id)
        {
            message.AddByte((byte)ServerPacketType.VipLogin);
            message.AddUInt32(id);
        }
    }
}

