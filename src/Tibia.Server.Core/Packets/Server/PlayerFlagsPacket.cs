namespace Tibia.Server.Core.Packets.Server
{
    public class PlayerFlagsPacket : Packet
    {
        public static void Add(NetworkMessage message, int flags)
        {
            message.AddByte((byte)ServerPacketType.PlayerFlags);
            message.AddUInt16((ushort)flags);
        }
    }
}
