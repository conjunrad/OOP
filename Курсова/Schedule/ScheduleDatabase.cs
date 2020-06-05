using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Coursework
{
    public class ScheduleDatabase
    {
        ScheduleLine[] subjects;

        public List<List<string>> myLists = new List<List<string>> {new List<string>() { "IS91", "IS92", "IS93" },
                                                                    new List<string> { "лекція", "практика"},
                                                                    new List<string> { "Вища математика", "Укр. Мова"},
                                                                    new List<string>() { "Завадська В.В.", "Жук В.А.", "Пелехата О.Б."},
                                                                    new List<string>() { "Понеділок", "Вівторок", "Середа", "Четвер", "П'ятниця", "Субота", },
                                                                    new List<string>() { "1", "2", "3", "4"},
                                                                    new List<string>() { "Mondey", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", },};
        public ScheduleDatabase()
        {
             subjects = new ScheduleLine[0];
        }
       public void AddSubject(string group, string type, string name, string teacher, string dayofweek, string num_lesson, int audience)
        {
            bool checker_teacher = false;
            bool checker_group = false;
            bool checker_type = false;
            bool checker_name = false;
            bool checker_dayofweek = false;
            bool checker_num_lesson = false;
            bool subject_availability = false;

            for (int i = 0; i<subjects.Length; i++)
            {
                if (subjects[i]["num_lesson"] == num_lesson && subjects[i]["dayofweek"] == dayofweek)
                {
                    subjects[i]["type"] = type;
                    subjects[i]["name"] = name;
                    subjects[i]["teacher"] = teacher;
                    subjects[i]["dayofweek"] = dayofweek;
                    subjects[i]["num_lesson"] = num_lesson;
                    subjects[i]["group"] = group;
                    subjects[i]["audience"] = audience.ToString();
                    subject_availability = true;
                    break;
                }
            }

            foreach (var i in myLists[0])
            {
                if (group == i)
                {
                    checker_group = true;
                    break;
                }
            }
            foreach (var i in myLists[1])
            {
                if (type == i)
                {
                    checker_type = true;
                    break;
                }
            }
            foreach (var i in myLists[2])
            {
                if (name == i)
                {
                    checker_name = true;
                    break;
                }
            }
            foreach (var i in myLists[3])
            {
                if(teacher == i)
                {
                    checker_teacher = true;
                    break;
                }
            }
            foreach (var i in myLists[4])
            {
                if (dayofweek == i)
                {
                    checker_dayofweek = true;
                    break;
                }
            }
            foreach (var i in myLists[5])
            {
                if (num_lesson == i)
                {
                    checker_num_lesson = true;
                    break;
                }
            }

            if (!checker_group)
            {
                myLists[0].Add(group);
            }
            if (!checker_type)
            {
                myLists[1].Add(type);
            }
            if (!checker_name)
            {
                myLists[2].Add(name);
            }
            if (!checker_teacher)
            {
                myLists[3].Add(teacher);
            }
            if (!checker_dayofweek)
            {
                myLists[4].Add(dayofweek);
            }
            if (!checker_num_lesson)
            {
                myLists[5].Add(num_lesson);
            }

            if(!subject_availability)
            {
                Array.Resize(ref subjects, subjects.Length + 1);
                subjects[subjects.Length - 1] = new ScheduleLine();
                subjects[subjects.Length - 1].Add(type, name, teacher, dayofweek, num_lesson, group, audience);
            }
        }
        public void Check(string propname, string value)
        {
            switch(propname)
            {
                case "group":
                    int correctGroup = 0;
                    int correctTimeGroup = 0;
                    foreach (var i in subjects)
                    {
                        if(i["group"] == value)
                        {
                            ++correctGroup;
                            if (i["dayofweek"] == DateTime.Now.DayOfWeek.ToString())
                            {
                                if (String.Compare(DateTime.Now.ToShortTimeString(), GetTimeOfTheLesson(i["num_lesson"])[0]) == 1 && String.Compare(DateTime.Now.ToShortTimeString(), GetTimeOfTheLesson(i["num_lesson"])[1]) == -1)
                                {
                                    ++correctTimeGroup;
                                    Console.WriteLine(i["info"]);
                                }
                            }
                        }
                    }
                    if (correctGroup == 0) { Console.WriteLine("No pairs of this group were found!"); }
                    if (correctTimeGroup == 0) { Console.WriteLine("At the moment, this group has no pairs!"); }
                    break;
                case "teacher":
                    int correctTeacher = 0;
                    int correctTimeTeacher = 0;
                    foreach (var i in subjects)
                    {
                        if (i["teacher"] == value)
                        {
                            ++correctTeacher;
                            if (i["dayofweek"] == DateTime.Now.DayOfWeek.ToString())
                            {
                                if (String.Compare(DateTime.Now.ToShortTimeString(), GetTimeOfTheLesson(i["num_lesson"])[0]) == 1 && String.Compare(DateTime.Now.ToShortTimeString(), GetTimeOfTheLesson(i["num_lesson"])[1]) == -1)
                                {
                                    ++correctTimeTeacher;
                                    Console.WriteLine(i["info"]);
                                    break;
                                }
                            }
                        }
                    }
                    if (correctTeacher == 0) { Console.WriteLine("The specified teacher was not found!"); }
                    else  if (correctTimeTeacher == 0) { Console.WriteLine("At the moment, this teacher has no pairs!"); }
                    break;
                case "week_group":
                    List<List<int>> week_group = new List<List<int>>();
                    for(int i = 0; i<4; i++)
                    {
                        week_group.Add(new List<int>());
                    }
                    Sort("num_lesson");
                    for (int i = 0; i < subjects.Length; i++)
                    {
                        if (subjects[i]["group"] == value)
                        {
                            switch (subjects[i]["dayofweek"])
                            {
                                case "Mondey":
                                    week_group[0].Add(i);
                                    break;
                                case "Tuesday":
                                    week_group[1].Add(i);
                                    break;
                                case "Wednesday":
                                    week_group[2].Add(i);
                                    break;
                                case "Thursday":
                                    week_group[3].Add(i);
                                    break;
                                case "Friday":
                                    week_group[4].Add(i);
                                    break;
                                case "Saturday":
                                    week_group[5].Add(i);
                                    break;
                                default: break;
                            }
                        }
                    }
                   for(int i = 0; i< week_group.Count; i++)
                    {
                        if(week_group[i].Count>0)
                        {
                            Console.WriteLine($"\t{myLists[4][i]}:");
                        }
                        for (int j = 0; j < week_group[i].Count; j++)
                        {
                            Console.WriteLine($"{subjects[week_group[i][j]]["num_lesson"]}. {subjects[week_group[i][j]]["info"]}");
                        }
                    }
                    break;
                case "week_teacher":
                    List<List<int>> a = new List<List<int>>();
                    for (int i = 0; i < 4; i++)
                    {
                        a.Add(new List<int>());
                    }
                    for (int i = 0; i < subjects.Length; i++)
                    {
                        if (subjects[i]["teacher"] == value)
                        {
                            switch (subjects[i]["dayofweek"])
                            {
                                case "Mondey":
                                    a[0].Add(i);
                                    break;
                                case "Tuesday":
                                    a[1].Add(i);
                                    break;
                                case "Wednesday":
                                    a[2].Add(i);
                                    break;
                                case "Thursday":
                                    a[3].Add(i);
                                    break;
                                case "Friday":
                                    a[4].Add(i);
                                    break;
                                case "Saturday":
                                    a[5].Add(i);
                                    break;
                                default: break;
                            }
                        }
                    }
                    for (int i = 0; i < a.Count; i++)
                    {
                        if (a[i].Count > 0)
                        {
                            Console.WriteLine($"\t{myLists[4][i]}:");
                        }
                        for (int j = 0; j < a[i].Count; j++)
                        {
                            Console.WriteLine($"{subjects[a[i][j]]["num_lesson"]}. {subjects[a[i][j]]["group"]} | {subjects[a[i][j]]["info"]}");
                        }
                        if (a[i].Count > 0)
                        {
                            Console.WriteLine();
                        }
                    }
                    break;
                default: break;
            }
        }
        private string[] GetTimeOfTheLesson(string num_lesson)
        {
            string[] time = new string[2];
            switch(num_lesson)
            {
                case "1":
                    time[0] = "8:30";
                    time[1] = "10:05";
                    return time;
                case "2":
                    time[0] = "10:25";
                    time[1] = "12:00";
                    return time;
                case "3":
                    time[0] = "12:20";
                    time[1] = "13:55";
                    return time;
                case "4":
                    time[0] = "14:15";
                    time[1] = "15:50";
                    return time;
                default: throw new IOException("Number of lesson is incorrect!");
            }
        }
        public void Sort(string arg)
        {
            switch(arg)
            {
                case "num_lesson":
                    for (int i = 0; i < subjects.Length - 1; i++)
                    {
                        for (int j = 0; j < subjects.Length - i - 1; j++)
                        {
                            if (String.Compare(subjects[j]["num_lesson"], subjects[j + 1]["num_lesson"]) == 1)
                            {
                                ScheduleLine s_temp = subjects[j];
                                subjects[j] = subjects[j + 1];
                                subjects[j + 1] = s_temp;
                            }
                        }
                    }
                    break;

            }
        }
    }
}