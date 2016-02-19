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

        [TestMethod]
        public void ElementAt()
        {
            var stack = new Stack();

            stack.Push(Integer256.Zero);
            stack.Push(Integer256.One);
            stack.Push(Integer256.Two);
            stack.Push(Integer256.Three);

            Assert.AreEqual(Integer256.Zero, stack.ElementAt(3));
            Assert.AreEqual(Integer256.One, stack.ElementAt(2));
            Assert.AreEqual(Integer256.Two, stack.ElementAt(1));
            Assert.AreEqual(Integer256.Three, stack.ElementAt(0));
        }
    }
}
