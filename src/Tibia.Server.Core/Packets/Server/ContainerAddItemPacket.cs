using Tibia.Server.Core.Items;

namespace Tibia.Server.Core.Packets.Server
{
    public class ContainerAddItemPacket : Packet
    {
        public static void Add
        (
            NetworkMessage message,
            byte containerIndex,
            Item item
        )
        {
            message.AddByte((byte)ServerPacketType.ContainerAddItem);

            message.AddByte(containerIndex);
            message.AddItem(item);
        }
    }
}
