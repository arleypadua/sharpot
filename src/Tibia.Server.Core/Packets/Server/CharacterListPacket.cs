﻿using System.Collections.Generic;
using System.Linq;

namespace Tibia.Server.Core.Packets.Server
{
    public class CharacterListPacket : Packet
    {
        public static void Add(NetworkMessage message, IEnumerable<CharacterListItem> characters, ushort premiumDaysLeft)
        {
            message.AddByte((byte)ServerPacketType.CharacterList);

            message.AddByte((byte)characters.Count());

            foreach (CharacterListItem character in characters)
            {
                message.AddString(character.Name);
                message.AddString(character.World);
                message.AddBytes(character.Ip);
                message.AddUInt16(character.Port);
            }

            message.AddUInt16(premiumDaysLeft);
        }

        public CharacterListPacket Parse(NetworkMessage message)
        {
            return new CharacterListPacket();
        }
    }
}
