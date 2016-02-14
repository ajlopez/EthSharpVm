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

            Assert.IsNotNull(result);
            Assert.AreEqual(32, result.Length);

            Assert.IsTrue(result.All(b => b == 0x00));
        }

        [TestMethod]
        public void OneToBytes()
        {
            Integer256 value = new Integer256();

            var newvalue = value.Add(1);
            var result = newvalue.ToBytes();

            Assert.IsNotNull(result);
            Assert.AreEqual(32, result.Length);

            for (int k = 0; k < 31; k++)
                Assert.AreEqual(0x00, result[k]);

            Assert.AreEqual(0x01, result[31]);
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
    }
}
