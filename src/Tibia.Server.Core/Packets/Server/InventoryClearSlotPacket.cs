namespace Tibia.Server.Core.Packets.Server
{
    public class InventoryClearSlotPacket : Packet
    {
        public static void Add(NetworkMessage message, SlotType slot)
        {
            message.AddByte((byte)ServerPacketType.InventoryClearSlot);
            message.AddByte((byte)slot);
        }
    }
}
