using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laba5_1
{
    class DigitalString: MyString
    {
        internal DigitalString(string str): base(str)
        {
            foreach(var i in str)
            {
                if(!char.IsDigit(i))
                {
                    throw new ArgumentException("Error! Your arguments must contain only digits!");
                }
            }
        }
        public void DelChar()
        {
            Console.Write("Enter the digit you want to delete: "); char symbol = (char)Console.Read();
            char[] new_text = new char[text.Length-1];
            int counter = -1;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == symbol)
                {
                    counter = i;
                    break;
                }
                if(i != text.Length-1)
                {
                    new_text[i] = text[i];
                }
            }
            if (counter >= 0)
            {
                for (int i = counter + 1; i < text.Length; i++)
                {
                    new_text[counter] = text[i];
                    ++counter;
                }
                text = new_text;
            }
            else Console.WriteLine($"Digit {symbol} is not found!");
        }
    }
}
