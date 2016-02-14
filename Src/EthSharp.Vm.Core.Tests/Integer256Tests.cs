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
    }
}
