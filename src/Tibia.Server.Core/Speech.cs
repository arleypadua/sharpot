namespace Tibia.Server.Core
{
    public class Speech
    {
        public SpeechType Type { get; set; }
        public string Receiver { get; set; }
        public string Message { get; set; }
        public ChatChannel ChannelId { get; set; }
    }
}
