using System;
using System.Collections.Generic;
using System.Text;

namespace laba3
{
    class Table
    {
        Line[] lines;
        public Table()
        {
            lines = new Line[0];
        }
        public Line this[int index]
        {
            get => lines[index];
        }
        public void AddStudent(string name, string surname, string lastname)
        {
            Array.Resize(ref lines, lines.Length + 1);
            lines[lines.Length - 1] = new Line(name, surname, lastname);
        }
        public string SurnamesAmount(string surname)
        {
            int counter = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i]["surname"] == surname)
                {
                    ++counter;
                }
            }
            return $"Amount of students with surname {surname}: {counter}";
        }
    }
}
