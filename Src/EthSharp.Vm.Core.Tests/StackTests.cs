namespace EthSharp.Vm.Core.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void PushByteAndPopInteger256()
        {
            var stack = new Stack();

            stack.Push(0x01);

            var result = stack.Pop();

            Assert.IsNotNull(result);
            Assert.AreEqual(new Integer256().Add(1), result);
        }
    }
}
