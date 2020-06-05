using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Coursework
{
    public class Student_Database
    {
        Line[] student;
        public Student_Database()
        {
            student = new Line[0];
        }
        public Line this[int index]
        {
            get => student[index];
        }
        public void AddStudent(string name, string surname, string lastname, string faculty, string group, string email, string phone)
        {
            Array.Resize(ref student, student.Length + 1);
            student[student.Length - 1] = new Line(name, surname, lastname, faculty, group, email, phone);
        }
        public int FindStudent(string value)
        {
            if(value.Contains(" "))
            {
                throw new IOException("Input error! You need to enter name/surname/lastname.");
            }
            else
            {
                for (int i = 0; i< student.Length;i++)
                {
                    if(student[i]["name"] == value || student[i]["surname"] == value || student[i]["lastname"] == value)
                    {
                        Console.WriteLine($"Шуканий студент знаходиться в {i} рядку!");
                        Console.WriteLine(student[i]["info"]);
                        return i;
                    }
                }
                Console.WriteLine("Input error! No such student was found.");
            }
            return -1;
        }
        public void Check(string propname)
        {
            Line[] temp = new Line[student.Length];
            temp = student;
            for (int i = 0; i< student.Length-1; i++)
            {
                for (int j = 0; j < student.Length-i-1; j++)
                {
                    if (String.Compare(temp[j]["surname"], temp[j+1]["surname"]) == 1)
                    {
                        Line s_temp = temp[j];
                        temp[j] = temp[j + 1];
                        temp[j + 1] = s_temp;
                    }
                }
            }
            switch(propname)
            {
                case "short":
                    for(int i = 0; i<temp.Length; i++)
                    {
                        Console.WriteLine($"{i}. {temp[i]["fullname"]}");
                    }
                    break;
                case "full":
                    for (int i = 0; i < temp.Length; i++)
                    {
                        Console.WriteLine($"{i}. {temp[i]["info"]}");
                    }
                    break;
            }
        }
    }
}
