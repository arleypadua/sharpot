namespace Tibia.Server.Core.Packets.Server
{
    public class DeathPacket : Packet
    {
        public static void Add(NetworkMessage message)
        {
            message.AddByte((byte)ServerPacketType.Death);
        }
    }
}
