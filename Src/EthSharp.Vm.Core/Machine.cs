namespace EthSharp.Vm.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Machine
    {
        private Stack stack;

        public Machine(Stack stack)
        {
            this.stack = stack;
        }

        public void Execute(byte[] bytecodes)
        {
            int pc = 0;
            int pl = bytecodes.Length;

            while (pc < pl)
            {
                byte bytecode = bytecodes[pc++];

                if (bytecode == (byte)Bytecodes.Push1)
                    this.stack.Push(bytecodes[pc++]);
            }
        }
    }
}
