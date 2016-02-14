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
    }
}
