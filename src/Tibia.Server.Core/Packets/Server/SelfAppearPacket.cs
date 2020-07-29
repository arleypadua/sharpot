﻿using System;

namespace Tibia.Server.Core.Packets.Server
{
    public class SelfAppearPacket : Packet
    {
        public static void Add(NetworkMessage message, uint playerId, bool canReportBugs)
        {
            message.AddByte((byte)ServerPacketType.SelfAppear);
            message.AddUInt32(playerId);
            message.AddByte(0x32);
            message.AddByte(0);
            message.AddByte(Convert.ToByte(canReportBugs));
        }
    }
}
