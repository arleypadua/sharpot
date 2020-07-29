namespace Tibia.Server.Core.Packets.Client
{
    public class PrivateChannelOpenPacket : Packet
    {
        public string Receiver { get; set; }

        public static PrivateChannelOpenPacket Parse(NetworkMessage message)
        {
            PrivateChannelOpenPacket p = new PrivateChannelOpenPacket();
            p.Receiver = message.GetString();
            return p;   
        }
    }
}