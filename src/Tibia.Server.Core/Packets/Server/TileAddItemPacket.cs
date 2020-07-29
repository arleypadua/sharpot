using Tibia.Server.Core.Items;

namespace Tibia.Server.Core.Packets.Server
{
    public class TileAddItemPacket : Packet
    {
        public static void Add
        (
            NetworkMessage message,
            Location location,
            byte stackPosition,
            Item item
        )
        {
            message.AddByte((byte)ServerPacketType.TileAddThing);

            message.AddLocation(location);
            message.AddByte(stackPosition);
            message.AddItem(item);
        }
    }
}
