using System;

namespace laba2
{
    class Program
    {
        static void Main()
        {
            TextField test = new TextField("Hello world", "Ho1a");
            test.ShowText();
            test.ClearText();
            test.ShowText();
            test.AddText("Hello world", "Ho1a", "Здраво", "Hallo");
            test.ShowText();
            test.DelString();
            test.ShowText();
            test.MaxLength();
            Console.WriteLine($"The total number of characters: {test.LenText()}");
            Console.WriteLine($"Percent of numbers in text: {test.DigitProcentInText()}%.");
        }
    }
}
