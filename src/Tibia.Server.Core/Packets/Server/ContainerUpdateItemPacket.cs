using Tibia.Server.Core.Items;

namespace Tibia.Server.Core.Packets.Server
{
    public class ContainerUpdateItemPacket : Packet
    {
        public static void Add
        (
            NetworkMessage message,
            byte containerIndex,
            byte containerPosition,
            Item item
        )
        {
            message.AddByte((byte)ServerPacketType.ContainerUpdateItem);

            message.AddByte(containerIndex);
            message.AddByte(containerPosition);
            message.AddItem(item);
        }
    }
}
