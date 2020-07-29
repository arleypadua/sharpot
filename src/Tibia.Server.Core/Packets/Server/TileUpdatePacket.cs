namespace Tibia.Server.Core.Packets.Server
{
    public class TileUpdatePacket : Packet
    {
        public static void Add
        (
            Connection connection,
            NetworkMessage message,
            Tile tile
        )
        {
            message.AddByte((byte)ServerPacketType.TileUpdate);

            message.AddLocation(tile.Location);
            MapPacket.AddTileDescription(connection, message, tile);
        }
    }
}
