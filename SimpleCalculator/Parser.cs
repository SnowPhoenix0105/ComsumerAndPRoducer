using System;
using System.Text;
using System.Collections.Generic;

namespace SimpleCalculator
{
    public class Parser
    {
        public static IItem Parse(string exp)
        {
            return new Parser(exp).Produce();
        }   

        private char[] exp; 
        private int index = 0;
        private char ch;
        private bool reachEnd;
            
        private Stack<IItem> itemStack = new Stack<IItem>();
            
        private Stack<char> opStack = new Stack<char>();

        private bool ReachEnd { get => reachEnd; }

        private Parser(string exp)
        {
            this.exp = exp.ToCharArray();
            NextChar();
        }

        private void NextChar()
        {
            do
            {
                if (index == exp.Length)
                {
                    ch = default(char);
                    reachEnd = true;
                    return;
                }
                ch = exp[index++];
            } while (Char.IsWhiteSpace(ch));
        }

        private IntegerItem NextInteger()
        {
            if (!Char.IsDigit(ch))
            {
                throw new SyntaxException(index, ch);
            }
            var buf = new StringBuilder();
            while (Char.IsDigit(ch))
            {
                buf.Append(ch);
                NextChar();
                if (ReachEnd)
                {
                    break;
                }
            }
            return new IntegerItem(int.Parse(buf.ToString()));
        }

        private void CombineStackTop()
        {
            var op = opStack.Pop();
            var right = itemStack.Pop();
            var left = itemStack.Pop();
            IItem item = op == '+' ? new AddItem(left, right) : new SubItem(left, right);
            itemStack.Push(item);
        }

        private IItem Produce()
        {
            itemStack.Push(NextInteger());
            while (!ReachEnd)
            {
                switch (ch)
                {
                case '+':
                case '-':
                    if (opStack.Count != 0)
                    {
                        CombineStackTop();
                        break;
                    }
                    opStack.Push(ch);
                    NextChar();
                    if (ReachEnd)
                    {
                        throw new SyntaxException(index, ch);
                    }
                    itemStack.Push(NextInteger());
                    break;
                case '*':
                    NextChar();
                    if (ReachEnd)
                    {
                        throw new SyntaxException(index, ch);
                    }
                    var mul = new MulItem(itemStack.Pop(), NextInteger());
                    itemStack.Push(mul);
                    break;
                default:
                    throw new SyntaxException(index, ch);
                }    
            }
            while (opStack.Count != 0)
            {
                CombineStackTop();
            }
            return itemStack.Pop();
        }
    }
    
}