namespace Tibia.Server.Core.Packets.Server
{
    public class TextMessagePacket : Packet
    {
        public static void Add(NetworkMessage message, TextMessageType type, string text)
        {
            message.AddByte((byte)ServerPacketType.TextMessage);
            message.AddByte((byte)type);
            message.AddString(text);
        }
    }
}
