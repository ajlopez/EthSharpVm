namespace EthSharp.Vm.Core.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Integer256Tests
    {
        [TestMethod]
        public void ZeroToBytes()
        {
            Integer256 value = new Integer256();

            var result = value.ToBytes();

            AreEqual(result, new byte[] {});
        }

        [TestMethod]
        public void OneToBytes()
        {
            Integer256 value = new Integer256();

            var newvalue = value.Add(1);
            var result = newvalue.ToBytes();

            AreEqual(result, new byte[] { 0x01 });
        }

        [TestMethod]
        public void MaxUInt32ToBytes()
        {
            Integer256 value = new Integer256();

            var newvalue = value.Add(UInt32.MaxValue);
            var result = newvalue.ToBytes();

            Assert.IsNotNull(result);
            Assert.AreEqual(32, result.Length);

            for (int k = 0; k < 28; k++)
                Assert.AreEqual(0x00, result[k]);

            Assert.AreEqual(0xff, result[28]);
            Assert.AreEqual(0xff, result[29]);
            Assert.AreEqual(0xff, result[30]);
            Assert.AreEqual(0xff, result[31]);
        }

        [TestMethod]
        public void MaxUInt32PlusOneToBytes()
        {
            Integer256 value = new Integer256();

            var newvalue = value.Add(UInt32.MaxValue).Add(1);
            var result = newvalue.ToBytes();

            Assert.IsNotNull(result);
            Assert.AreEqual(32, result.Length);

            for (int k = 0; k < 32; k++)
                if (k != 27)
                    Assert.AreEqual(0x00, result[k]);
                else
                    Assert.AreEqual(0x01, result[k]);
        }

        private static void AreEqual(byte[] values, byte[] expected)
        {
            Assert.IsNotNull(values);

            var vl = values.Length;

            Assert.AreEqual(32, vl);

            var el = expected.Length;

            for (int k = 0; k < vl - el; k++)
                Assert.AreEqual(0x00, values[k]);

            for (int k = 0; k < el; k++)
                Assert.AreEqual(values[vl - el + k], expected[k]);
        }
    }
}
