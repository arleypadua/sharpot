namespace Tibia.Server.Core.Packets.Server
{
    public class ChannelOpenPacket : Packet
    {
        public static void Add(NetworkMessage message, ushort channelId, string channelName)
        {
            message.AddByte((byte)ServerPacketType.ChannelOpen);
            message.AddUInt16(channelId);
            message.AddString(channelName);
        }
    }
}