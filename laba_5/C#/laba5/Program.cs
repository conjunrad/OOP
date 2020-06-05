using System;

namespace laba5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString test = new MyString("Hello world!");
            Console.WriteLine(test.GetText());
            Console.WriteLine(test.Lenght());
        }
    }
}
