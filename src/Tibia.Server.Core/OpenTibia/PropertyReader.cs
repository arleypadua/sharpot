using System.IO;
using System.Text;

namespace Tibia.Server.Core.OpenTibia
{
    public class PropertyReader : BinaryReader
    {
        public PropertyReader(Stream stream)
            : base(stream) { }

        public string GetString()
        {
            ushort len = ReadUInt16();
            return Encoding.Default.GetString(ReadBytes(len));
        }
    }
}
