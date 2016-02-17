namespace EthSharp.Vm.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Integer256
    {
        internal const int Size = 8;
        private uint[] values;

        public static Integer256 FromBytes(byte[] bytes)
        {
            return FromBytes(bytes, 0, bytes.Length);
        }

        public static Integer256 FromBytes(byte[] bytes, int boffset, int lbytes)
        {
            uint[] values = new uint[Size];

            for (int k = 0; k < lbytes; k++)
            {
                byte val = bytes[boffset + lbytes - k - 1];
                int offset = k % 4;
                int position = k / 4;
                values[position] |= ((uint)val) << (offset * 8);
            }

            return new Integer256(values);
        }

        public Integer256()
        {
            this.values = new uint[Size];
        }

        public Integer256(uint value)
        {
            this.values = new uint[Size];
            this.values[0] = value;
        }

        internal Integer256(uint[] values)
        {
            this.values = values;
        }

        public Integer256 Negate()
        {
            var newvalues = new uint[Size];

            for (int k = 0; k < Size; k++)
                newvalues[k] = ~this.values[k];

            Add(newvalues, 1);

            return new Integer256(newvalues);
        }

        public Integer256 Add(uint value)
        {
            var newvalues = new uint[Size];
            Array.Copy(this.values, newvalues, Size);

            Add(newvalues, value, 0);

            return new Integer256(newvalues);
        }

        public Integer256 Add(Integer256 value)
        {
            var newvalues = new uint[Size];
            Array.Copy(this.values, newvalues, Size);

            for (int k = 0; k < Size; k++)
                Add(newvalues, value.values[k], k);

            return new Integer256(newvalues);
        }

        public Integer256 Subtract(Integer256 value)
        {
            return this.Add(value.Negate());
        }

        public override int GetHashCode()
        {
            int hash = 0;

            for (int k = 0; k < Size; k++)
                hash = (hash * 7) + this.values[k].GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Integer256))
                return false;

            if (obj == this)
                return true;

            var value = (Integer256)obj;

            for (int k = 0; k < Size; k++)
                if (this.values[k] != value.values[k])
                    return false;

            return true;
        }

        public byte[] ToBytes()
        {
            var bytes = new byte[32];
            int offset = 32;

            for (int k = 0; k < Size; k++)
            {
                uint value = this.values[k];
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

        private static void Add(uint[] values, uint value, int offset = 0)
        {
            if (offset >= Size)
                return;

            ulong newvalue = (ulong)values[offset] + value;
            values[offset] = (uint)newvalue;

            if (newvalue >> 32 != 0)
                Add(values, 1, offset + 1);
        }
    }
}
