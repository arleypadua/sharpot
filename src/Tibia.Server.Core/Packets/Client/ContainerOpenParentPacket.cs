namespace Tibia.Server.Core.Packets.Client
{
    public class ContainerOpenParentPacket : Packet
    {
        public byte ContainerIndex { get; set; }

        public static ContainerOpenParentPacket Parse(NetworkMessage message)
        {
            ContainerOpenParentPacket p = new ContainerOpenParentPacket();
            p.ContainerIndex = message.GetByte();
            return p;
        }
    }
}