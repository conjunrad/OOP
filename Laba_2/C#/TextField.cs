using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laba2
{
    class TextField
    {
        private StringLine[] strings;
        private int number_of_lines;

        public TextField(params string[] txt)
        {
            number_of_lines = txt.Length;
            strings = new StringLine[txt.Length];
            int counter = 0;
            foreach (var i in txt)
            {
                strings[counter] = new StringLine(i);
                counter++;
            }
            
        }
        public void ShowText()
        {
            if (strings.Length != 0)
            {
                foreach (var i in strings)
                {
                    Console.WriteLine(i.GetText());
                }
            }
            else
            {
                Console.WriteLine("Text field is empty.");
            }
            Console.WriteLine();
        }
        public void AddText(params string[] txt)
        {
            number_of_lines += txt.Length;
            int counter = 0;
            int counter_general = strings.Length + txt.Length;
            StringLine[] new_strings = new StringLine[counter_general];
            for(int i = 0; i<strings.Length; i++)
            {
                new_strings[counter] = strings[counter];
                counter++;
            }
            foreach (var i in txt)
            {
                new_strings[counter] = new StringLine(i);
                counter++;
            }
            strings = new_strings;
        }
        public void DelString()
        {
            Console.Write("Enter the line number you want to delete: ");
            int number = int.Parse(Console.ReadLine());
            if (number > strings.Length && strings.Length > 0)
            {
                Console.WriteLine("Error. The line number is greater than the number of lines");
            }
            else if (strings.Length == 0)
            {
                Console.WriteLine("Text field is empty.");
            }
            else {
                int counter = 0;
                number_of_lines -= 1;
                number -= 1;
                StringLine[] new_strings = new StringLine[number_of_lines];
                for(int i = 0; i<number; i++)
                {
                    new_strings[counter] = strings[i];
                    ++counter;
                }
                for (int i = number + 1; i < strings.Length; i++)
                {
                    new_strings[counter] = strings[i];
                    ++counter;
                }
                strings = new_strings;
            }
        }
        public void ClearText()
        {
            strings = new StringLine[0];
            number_of_lines = 0;
        }
        public void MaxLength()
        {
            int maxValue_index = 0;
            for(int i = 0; i<strings.Length; i++)
            {
                if(strings[i].Length() < maxValue_index)
                {
                    maxValue_index = i;
                }
            }
            Console.Write($"The longest line is {maxValue_index}: '"); Console.Write(strings[maxValue_index].GetText()); Console.WriteLine("'");
        }
        public int LenText()
        {
            int counter = 0;
            for (int i = 0; i<strings.Length; i++)
            {
                counter += strings[i].Length();
            }
            return counter;
        }
        public int GetAmountOfDigits()
        {
            int digit_amount = 0;
            for (int i = 0; i < strings.Length; i++)
            {
                for (int j = 0; j < strings[i].Length(); j++)
                {
                    if (char.IsDigit(strings[i].GetText()[j]) == true)
                    {
                        digit_amount += 1;
                    }
                }
            }
            return digit_amount;
        }
        public double DigitProcentInText()
        {
            int digit_amount = GetAmountOfDigits();
            int len_text = LenText();
            double percent = 100.0 * digit_amount/len_text;
            return percent;
        }
    }
}
