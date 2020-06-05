using System;

namespace laba8
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            list.Cleared += DisplayMessage;
            list[0] = "a";
            list[1] = "b";
            list.Pop(1);

            Symbol str = new Symbol("abc123");
            str.Symbols();

            Symbol.Delegate1 del = Symbol.Symbols;
            del?.Invoke("abc123");
        }
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
