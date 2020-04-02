using System;

namespace laba3
{
    class Program
    {
        static void Main(string[] args)
        {
            Table table = new Table();
            table.AddStudent("Bob", "Marshall", "Ivanovich");
            table.AddStudent("Jack", "Marshall", "Harrison");
            Console.WriteLine(table.SurnamesAmount("Marshall"));


        }
    }
}
