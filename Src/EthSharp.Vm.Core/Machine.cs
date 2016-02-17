namespace EthSharp.Vm.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Machine
    {
        private Stack stack;

        public Machine()
        {
            this.stack = new Stack();
        }

        public Stack Stack { get { return this.stack; } }

        public void Execute(byte[] bytecodes)
        {
            int pc = 0;
            int pl = bytecodes.Length;

            while (pc < pl)
            {
                byte bytecode = bytecodes[pc++];

                if (bytecode == (byte)Bytecodes.Push1)
                    this.stack.Push(Integer256.FromBytes(bytecodes, pc++, 1));
            }
        }
    }
}
