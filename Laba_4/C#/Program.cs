using System;

namespace laba_4
{
    class Program
    {
        static void Main(string[] args)
        {
            StringLine CS1 = new StringLine();
            StringLine CS2 = new StringLine("Hell0 world! ");
            StringLine CS3 = new StringLine(CS2);
            CS3 -= '0';
            CS3.Print();
            CS1 = CS2 + CS3;
            CS1.Print();
        }
    }
}
