namespace EthSharp.Vm.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Integer256
    {
        private const int size = 8;
        private UInt32[] values;

        public Integer256()
        {
            this.values = new UInt32[size];
        }

        private Integer256(UInt32[] values)
        {
            this.values = values;
        }

        public Integer256 Add(uint value)
        {
            var newvalues = new UInt32[8];

            newvalues[0] = values[0] + value;

            return new Integer256(newvalues);
        }

        public byte[] ToBytes()
        {
            var bytes = new byte[32];
            int offset = 32;

            for (int k = 0; k < size; k++)
            {
                UInt32 value = values[k];
                offset -= 4;

                bytes[offset + 3] = (byte)(value & 0x00ff);
                value >>= 8;
                bytes[offset + 2] = (byte)(value & 0x00ff);
                value >>= 8;
                bytes[offset + 1] = (byte)(value & 0x00ff);
                value >>= 8;
                bytes[offset] = (byte)(value & 0x00ff);
            }

            return bytes;
        }
    }
}
