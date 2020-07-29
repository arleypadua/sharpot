namespace Tibia.Server.Core.Packets.Server
{
    public class VipStatePacket:Packet
    {
        public static void Add(NetworkMessage message, uint id, string name, byte loggedIn)
        {
            message.AddByte((byte)ServerPacketType.VipState);
            message.AddUInt32(id);
            message.AddString(name);
            message.AddByte(loggedIn);
        }
    }
}
