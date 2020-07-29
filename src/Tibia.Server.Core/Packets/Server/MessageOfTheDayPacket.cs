namespace Tibia.Server.Core.Packets.Server
{
    public class MessageOfTheDayPacket : Packet
    {
        public static void Add(NetworkMessage message, string messageOfTheDay)
        {
            message.AddByte((byte)ServerPacketType.MessageOfTheDay);
            message.AddString("1\n" + messageOfTheDay);
        }

        public MessageOfTheDayPacket Parse(NetworkMessage message)
        {
            return new MessageOfTheDayPacket();
        }
    }
}
