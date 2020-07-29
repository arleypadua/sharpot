namespace Tibia.Server.Core.Packets.Client
{
    public class VipRemovePacket
    {
        public uint Id { get; set; }

        public static VipRemovePacket Parse(NetworkMessage message)
        {
            VipRemovePacket p = new VipRemovePacket();
            p.Id = message.GetUInt32();
            return p;
        }
    }
}
