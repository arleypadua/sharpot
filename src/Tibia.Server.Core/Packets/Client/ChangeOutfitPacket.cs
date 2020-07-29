namespace Tibia.Server.Core.Packets.Client
{
    public class ChangeOutfitPacket : Packet
    {
        public Outfit Outfit { get; set; }

        public static ChangeOutfitPacket Parse(NetworkMessage message)
        {
            ChangeOutfitPacket packet = new ChangeOutfitPacket();

            packet.Outfit = message.GetOutfit();

            return packet;
        }
    }
}
