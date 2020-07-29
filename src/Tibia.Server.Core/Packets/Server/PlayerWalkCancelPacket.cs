namespace Tibia.Server.Core.Packets.Server
{
    public class PlayerWalkCancelPacket : Packet
    {
        public static void Add(NetworkMessage message, Direction direction)
        {
            message.AddByte((byte)ServerPacketType.PlayerWalkCancel);
            message.AddByte((byte)direction);
        }
    }
}
