namespace Tibia.Server.Core.Packets.Client
{
    public class ChannelClosePacket : Packet
    {
        public ChatChannel Channel { get; set; }

        public static ChannelClosePacket Parse(NetworkMessage message)
        {
            ChannelClosePacket p = new ChannelClosePacket();
            p.Channel = (ChatChannel)message.GetUInt16();
            return p;
        }
    }
}