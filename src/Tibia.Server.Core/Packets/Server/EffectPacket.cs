namespace Tibia.Server.Core.Packets.Server
{
    public class EffectPacket : Packet
    {
        public static void Add(NetworkMessage message, Location location, Effect effect)
        {
            message.AddByte((byte)ServerPacketType.Effect);
            message.AddLocation(location);
            message.AddByte((byte)effect);
        }
    }
}
