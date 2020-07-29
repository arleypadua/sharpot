namespace Tibia.Server.Core
{
    public class Channel
    {
        public ushort Id { get; set; }
        public string Name { get; set; }
        public uint CooldownTime { get; set; }
        
        public Channel(ushort id, string name, uint cooldownTime)
        {
            Id = id;
            Name = name;
            CooldownTime = cooldownTime;
        }
    }
}
