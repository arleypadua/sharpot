namespace Tibia.Server.Core.Packets.Server
{
    public class ContainerRemoveItemPacket : Packet
    {
        public static void Add
        (
            NetworkMessage message,
            byte containerIndex,
            byte containerPosition
        )
        {
            message.AddByte((byte)ServerPacketType.ContainerRemoveItem);

            message.AddByte(containerIndex);
            message.AddByte(containerPosition);
        }
    }
}
