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
    }
}
