﻿namespace Tibia.Server.Core.Packets.Client
{
    public class ClientChannelOpenPacket : Packet
    {
        public ChatChannel Channel { get; set; }

        public static ClientChannelOpenPacket Parse(NetworkMessage message)
        {
            ClientChannelOpenPacket p = new ClientChannelOpenPacket();
            p.Channel = (ChatChannel)message.GetUInt16();
            return p;
        }
    }
}