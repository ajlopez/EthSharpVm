namespace EthSharp.Vm.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Integer256
    {
        internal const int size = 8;
        private UInt32[] values;

        public Integer256()
        {
            this.values = new UInt32[size];
        }

        internal Integer256(UInt32[] values)
        {
            this.values = values;
        }

        public Integer256 Negate()
        {
            var newvalues = new UInt32[size];

            for (int k = 0; k < size; k++)
                newvalues[k] = ~this.values[k];

            Add(newvalues, 1);

            return new Integer256(newvalues);
        }

        public Integer256 Add(uint value)
        {
            var newvalues = new UInt32[size];
            Array.Copy(this.values, newvalues, size);

            Add(newvalues, value, 0);

            return new Integer256(newvalues);
        }

        public Integer256 Add(Integer256 value)
        {
            var newvalues = new UInt32[size];
            Array.Copy(this.values, newvalues, size);

            for (int k = 0; k < size; k++)
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

            for (int k = 0; k < size; k++)
                hash = hash * 7 + this.values[k].GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Integer256))
                return false;

            if (obj == this)
                return true;

            var value = (Integer256)obj;

            for (int k = 0; k < size; k++)
                if (this.values[k] != value.values[k])
                    return false;

            return true;
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

        private static void Add(UInt32[] values, uint value, int offset = 0)
        {
            if (offset >= size)
                return;

            UInt64 newvalue = (UInt64)values[offset] + value;
            values[offset] = (UInt32)newvalue;

            if (newvalue >> 32 != 0)
                Add(values, 1, offset + 1);
        }
    }
}
