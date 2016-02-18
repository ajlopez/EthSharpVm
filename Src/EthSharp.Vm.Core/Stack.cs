namespace EthSharp.Vm.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Stack
    {
        private Stack<Integer256> stack = new Stack<Integer256>();

        public int Size { get { return this.stack.Count; } }

        public void Push(Integer256 value)
        {
            this.stack.Push(value);
        }

        public Integer256 Top()
        {
            return this.stack.Peek();
        }

        public Integer256 Pop()
        {
            return this.stack.Pop();
        }
    }
}
