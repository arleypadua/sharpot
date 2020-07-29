namespace Tibia.Server.Core.Packets.Server
{
    public class ChannelOpenPrivatePacket : Packet
    {
        public static void Add(NetworkMessage message,string Name)
        {
            message.AddByte((byte)ServerPacketType.ChannelOpenPrivate);
            message.AddString(Name);
        }

    }
}