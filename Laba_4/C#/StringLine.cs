using System;
using System.Collections.Generic;
using System.Text;

namespace laba_4
{
    class StringLine
    {
        private char[] text { get; set; }
        public StringLine()
        {
            text = null;
        }
        public StringLine(string str)
        {
            text = str.ToCharArray();
        }
        public StringLine(StringLine str)
        {
            text = str.text;
        }
        public int Lenght()
        {
            return text.Length;
        }
        public void Print()
        {
            Console.WriteLine(text);
        }
        public static StringLine operator +(StringLine str_1, StringLine str_2)
        {
            var general_length = str_1.Lenght() + str_2.Lenght();
            StringLine new_str = new StringLine();
            new_str.text = new char[general_length];
            for (int i = 0; i<str_1.Lenght(); i++)
            {
                new_str.text[i] = str_1.text[i];
            }
            int j = 0;
            for (int i = str_1.Lenght(); i < general_length; i++)
            {
                new_str.text[i] = str_2.text[j];
                ++j;
            }
            return new_str;
        }
        public static StringLine operator -(StringLine str_1, char str_2)
        {
            StringLine new_str = new StringLine();
            new_str.text = new char[str_1.Lenght() - 1];
            int counter = -1;
            for (int i = 0; i<str_1.Lenght()-1; i++)
            {
                if (str_1.text[i] == str_2)
                {
                    counter = i;
                    break;
                }
                new_str.text[i] = str_1.text[i];
            }
            if (counter >= 0)
            {
                for (int i = counter+1; i<str_1.Lenght()-1; i++)
                {
                    new_str.text[counter] = str_1.text[i];
                    ++counter;
                }
            }
            return new_str;
        }
    }
}
