namespace Tibia.Server.Core.Packets.Client
{
    public class ItemMovePacket : Packet
    {
        public Location FromLocation { get; set; }
        public ushort SpriteId { get; set; }
        public byte FromStackPosition { get; set; }
        public Location ToLocation { get; set; }
        public byte Count { get; set; }

        public static ItemMovePacket Parse(NetworkMessage message)
        {
            ItemMovePacket packet = new ItemMovePacket();

            packet.FromLocation = message.GetLocation();
            packet.SpriteId = message.GetUInt16();
            packet.FromStackPosition = message.GetByte();
            packet.ToLocation = message.GetLocation();
            packet.Count = message.GetByte();

            return packet;
        }
    }
}
