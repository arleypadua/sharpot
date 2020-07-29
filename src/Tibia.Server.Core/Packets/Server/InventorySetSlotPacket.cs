using Tibia.Server.Core.Items;

namespace Tibia.Server.Core.Packets.Server
{
    public class InventorySetSlotPacket : Packet
    {
        public static void Add(NetworkMessage message, SlotType slot, Item item)
        {
            message.AddByte((byte)ServerPacketType.InventorySetSlot);
            message.AddByte((byte)slot);
            message.AddItem(item);
        }
    }
}
