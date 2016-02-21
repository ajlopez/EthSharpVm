﻿namespace EthSharp.Vm.Core.Tests
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

            Assert.AreEqual(machine.Stack.Pop(), Integer256.One);
            Assert.AreEqual(0, machine.Stack.Size);
        }

        [TestMethod]
        public void PushAndDup()
        {
            Machine machine = new Machine();

            machine.Execute(new byte[] { (byte)Bytecodes.Push1, 0x01, (byte)Bytecodes.Dup1 });

            Assert.AreEqual(machine.Stack.Pop(), Integer256.One);
            Assert.AreEqual(machine.Stack.Pop(), Integer256.One);
            Assert.AreEqual(0, machine.Stack.Size);
        }

        [TestMethod]
        public void PushTwiceAndDup()
        {
            Machine machine = new Machine();

            machine.Execute(new byte[] { (byte)Bytecodes.Push1, 0x01, (byte)Bytecodes.Push1, 0x02, (byte)Bytecodes.Dup2 });

            Assert.AreEqual(machine.Stack.Pop(), Integer256.One);
            Assert.AreEqual(machine.Stack.Pop(), Integer256.Two);
            Assert.AreEqual(machine.Stack.Pop(), Integer256.One);
            Assert.AreEqual(0, machine.Stack.Size);
        }

        [TestMethod]
        public void PushThreeValuesAndDup()
        {
            Machine machine = new Machine();

            machine.Execute(new byte[] { (byte)Bytecodes.Push1, 0x00, (byte)Bytecodes.Push1, 0x01, (byte)Bytecodes.Push1, 0x02, (byte)Bytecodes.Dup3 });

            Assert.AreEqual(machine.Stack.Pop(), Integer256.Zero);
            Assert.AreEqual(machine.Stack.Pop(), Integer256.Two);
            Assert.AreEqual(machine.Stack.Pop(), Integer256.One);
            Assert.AreEqual(machine.Stack.Pop(), Integer256.Zero);
            Assert.AreEqual(0, machine.Stack.Size);
        }

        [TestMethod]
        public void PushByteTwice()
        {
            Machine machine = new Machine();

            machine.Execute(new byte[] { (byte)Bytecodes.Push1, 0x01, (byte)Bytecodes.Push1, 0x02 });

            Assert.AreEqual(machine.Stack.Pop(), Integer256.Two);
            Assert.AreEqual(machine.Stack.Pop(), Integer256.One);
            Assert.AreEqual(0, machine.Stack.Size);
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
            Assert.AreEqual(0, machine.Stack.Size);
        }
    }
}
