namespace Tibia.Server.Core.Packets.Client
{
    public class VipAddPacket
    {
        public string Name { get; set; }

        public static VipAddPacket Parse(NetworkMessage message)
        {
            VipAddPacket p = new VipAddPacket();

            p.Name = message.GetString();

            return p;
        }
    }
}
