using System;

namespace laba6
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new Expression[3]
            {
                new Expression(-4,5,9,0), new Expression(10,12,8,6), new Expression(1,2,1,1)
            };
            foreach(var i in array)
            {
                Console.WriteLine($"Result: {i.Calc()}");
            }
        }
    }
}
