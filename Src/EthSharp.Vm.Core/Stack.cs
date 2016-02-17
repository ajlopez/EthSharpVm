﻿namespace EthSharp.Vm.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Stack
    {
        private Stack<Integer256> stack = new Stack<Integer256>();

        public void Push(byte bt)
        {
            uint[] values = new uint[Integer256.Size];

            values[0] = bt;

            this.stack.Push(new Integer256(values));
        }

        public void Push(ushort value)
        {
            uint[] values = new uint[Integer256.Size];

            values[0] = value;

            this.stack.Push(new Integer256(values));
        }

        public void Push(Integer256 value)
        {
            this.stack.Push(value);
        }

        public Integer256 Pop()
        {
            return this.stack.Pop();
        }
    }
}
