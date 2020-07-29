namespace Tibia.Server.Core.Packets.Server
{
    public class WorldLightPacket : Packet
    {
        public static void Add(NetworkMessage message, byte lightLevel, byte lightColor)
        {
            message.AddByte((byte)ServerPacketType.WorldLight);
            message.AddByte(lightLevel);
            message.AddByte(lightColor);
        }
    }
}
