namespace EthSharp.Vm.Core.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MachineTests
    {
        [TestMethod]
        public void PushByte()
        {
            Stack stack = new Stack();
            Machine machine = new Machine(stack);

            machine.Execute(new byte[] { (byte)Bytecodes.Push1, 0x01 });

            Assert.AreEqual(stack.Pop(), new Integer256().Add(1));
        }
    }
}
