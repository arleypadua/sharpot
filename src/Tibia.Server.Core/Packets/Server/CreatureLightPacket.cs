namespace Tibia.Server.Core.Packets.Server
{
    public class CreatureLightPacket : Packet
    {
        public static void Add(NetworkMessage message, uint creatureId, byte lightLevel, byte lightColor)
        {
            message.AddByte((byte)ServerPacketType.CreatureLight);
            message.AddUInt32(creatureId);
            message.AddByte(lightLevel);
            message.AddByte(lightColor);
        }
    }
}
