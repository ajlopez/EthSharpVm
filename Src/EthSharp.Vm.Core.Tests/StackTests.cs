namespace EthSharp.Vm.Core.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void PushByteAndPopInteger256()
        {
            var stack = new Stack();

            stack.Push(Integer256.FromBytes(new byte[] { 0x01 }));

            var result = stack.Pop();

            Assert.IsNotNull(result);
            Assert.AreEqual(new Integer256().Add(1), result);
        }

        [TestMethod]
        public void PushTwoBytesAndPopInteger256()
        {
            var stack = new Stack();

            stack.Push(Integer256.FromBytes(new byte[] { 0x01, 0x00 }));

            var result = stack.Pop();

            Assert.IsNotNull(result);
            Assert.AreEqual(new Integer256().Add(256), result);
        }
    }
}
