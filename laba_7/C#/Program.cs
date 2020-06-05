using System;
using System.Xml;

namespace laba7
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List();
            list.AddLast('a');
            list.AddLast('*');
            list.AddLast('#');
            list.AddLast('*');
            list.AddLast('5');
            list.Print();
            Console.WriteLine($"Number of * in list: {list.CountAsterisk()}");
            list.Remove();
            list.Print();
        }
    }
}
