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
            Machine machine = new Machine();

            machine.Execute(new byte[] { (byte)Bytecodes.Push1, 0x01 });

            Assert.AreEqual(machine.Stack.Pop(), new Integer256().Add(1));
        }

        [TestMethod]
        public void PushByteTwice()
        {
            Machine machine = new Machine();

            machine.Execute(new byte[] { (byte)Bytecodes.Push1, 0x01, (byte)Bytecodes.Push1, 0x02 });

            Assert.AreEqual(machine.Stack.Pop(), new Integer256(2));
            Assert.AreEqual(machine.Stack.Pop(), new Integer256(1));
        }

        [TestMethod]
        public void PushTwoBytesTwice()
        {
            Machine machine = new Machine();

            machine.Execute(new byte[] { (byte)Bytecodes.Push2, 0x01, 0x02, (byte)Bytecodes.Push2, 0x03, 0x04 });

            Assert.AreEqual(machine.Stack.Pop(), new Integer256(256 * 3 + 4));
            Assert.AreEqual(machine.Stack.Pop(), new Integer256(256 + 2));
        }

        [TestMethod]
        public void PushThreeBytesTwice()
        {
            Machine machine = new Machine();

            machine.Execute(new byte[] { (byte)Bytecodes.Push3, 0x01, 0x02, 0x03, (byte)Bytecodes.Push3, 0x04, 0x05, 0x06 });

            Assert.AreEqual(machine.Stack.Pop(), new Integer256(256 * 256 * 4 + 256 * 5 + 6));
            Assert.AreEqual(machine.Stack.Pop(), new Integer256(256 * 256 * 1 + 256 * 2 + 3));
        }
    }
}
