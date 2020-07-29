namespace Tibia.Server.Core.Packets.Server
{
    public class TileAddCreaturePacket : Packet
    {
        public static void Add
        (
            NetworkMessage message,
            Location location,
            byte stackPosition,
            Creature creature,
            bool known,
            uint removeKnown
        )
        {
            message.AddByte((byte)ServerPacketType.TileAddThing);

            message.AddLocation(location);
            message.AddByte(stackPosition);
            message.AddCreature(creature, known, removeKnown);
        }
    }
}
