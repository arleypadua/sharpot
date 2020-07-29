namespace Tibia.Server.Core.Packets.Server
{
    public class AnimatedTextPacket : Packet
    {
        public static void Add(NetworkMessage message, Location location, TextColor color, string text)
        {
            message.AddByte((byte)ServerPacketType.AnimatedText);
            message.AddLocation(location);
            message.AddByte((byte)color);
            message.AddString(text);
        }
    }
}
