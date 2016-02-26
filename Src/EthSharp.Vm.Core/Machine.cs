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
                    case (byte)Bytecodes.Push2:
                    case (byte)Bytecodes.Push3:
                    case (byte)Bytecodes.Push4:
                    case (byte)Bytecodes.Push5:
                    case (byte)Bytecodes.Push6:
                    case (byte)Bytecodes.Push7:
                    case (byte)Bytecodes.Push8:
                    case (byte)Bytecodes.Push9:
                    case (byte)Bytecodes.Push10:
                    case (byte)Bytecodes.Push11:
                    case (byte)Bytecodes.Push12:
                    case (byte)Bytecodes.Push13:
                    case (byte)Bytecodes.Push14:
                    case (byte)Bytecodes.Push15:
                    case (byte)Bytecodes.Push16:
                    case (byte)Bytecodes.Push17:
                    case (byte)Bytecodes.Push18:
                    case (byte)Bytecodes.Push19:
                    case (byte)Bytecodes.Push20:
                    case (byte)Bytecodes.Push21:
                    case (byte)Bytecodes.Push22:
                    case (byte)Bytecodes.Push23:
                    case (byte)Bytecodes.Push24:
                    case (byte)Bytecodes.Push25:
                    case (byte)Bytecodes.Push26:
                    case (byte)Bytecodes.Push27:
                    case (byte)Bytecodes.Push28:
                    case (byte)Bytecodes.Push29:
                    case (byte)Bytecodes.Push30:
                    case (byte)Bytecodes.Push31:
                    case (byte)Bytecodes.Push32:
                        int size = bytecode - (byte)Bytecodes.Push1 + 1;
                        this.stack.Push(Integer256.FromBytes(bytecodes, pc, size));
                        pc += size;
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
