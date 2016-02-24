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

                switch (bytecode) 
                {
                    case (byte)Bytecodes.Push1:
                        this.stack.Push(Integer256.FromBytes(bytecodes, pc++, 1));
                        break;
                    case (byte)Bytecodes.Push2:
                        this.stack.Push(Integer256.FromBytes(bytecodes, pc, 2));
                        pc += 2;
                        break;
                    case (byte)Bytecodes.Push3:
                        this.stack.Push(Integer256.FromBytes(bytecodes, pc, 3));
                        pc += 3;
                        break;
                    case (byte)Bytecodes.Dup1:
                    case (byte)Bytecodes.Dup2:
                    case (byte)Bytecodes.Dup3:
                    case (byte)Bytecodes.Dup4:
                    case (byte)Bytecodes.Dup5:
                    case (byte)Bytecodes.Dup6:
                    case (byte)Bytecodes.Dup7:
                    case (byte)Bytecodes.Dup8:
                    case (byte)Bytecodes.Dup9:
                    case (byte)Bytecodes.Dup10:
                    case (byte)Bytecodes.Dup11:
                    case (byte)Bytecodes.Dup12:
                    case (byte)Bytecodes.Dup13:
                    case (byte)Bytecodes.Dup14:
                    case (byte)Bytecodes.Dup15:
                    case (byte)Bytecodes.Dup16:
                        this.stack.Push(this.stack.ElementAt(bytecode - (byte)Bytecodes.Dup1));
                        break;
                }
            }
        }
    }
}
