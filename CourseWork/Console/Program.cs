using System;
using System.Collections.Generic;
using System.Xml;

namespace Coursework
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Student_Database student_bd = new Student_Database();
            student_bd.AddStudent("Тарасенко", "Роман", "Юрійович", "FIOT", "IS92", "test1@gmail.com", "+380951111111");
            student_bd.AddStudent("Оношенко", "Владислав", "Володимирович", "FIOT", "IS92", "test2@gmail.com", "+380965489014");
            student_bd.AddStudent("Мельницька", "Віталія", "Богданівна", "FIOT", "IS91", "test3@gmail.com", "+380679756412");
            student_bd.AddStudent("Кабанець", "Вікторія", "Вадимівна", "FIOT", "Is93", "test4@gmail.com", "+380668756985");

            ScheduleDatabase schedule_bd = new ScheduleDatabase();
            schedule_bd.AddSubject("IS92", "практика", "Укр. мова", "Завадська В.В.", "Mondey", "2", 310);
            schedule_bd.AddSubject("IS92", "практика", "Вища математика", "Жук В.А.", "Tuesday", "1", 310);
            schedule_bd.AddSubject("IS91", "лекція", "Вища математика", "Жук В.А.", "Thursday", "3", 310);
            schedule_bd.AddSubject("IS92", "лекція", "Вища математика", "Жук В.А.", "Thursday", "3", 310);
            schedule_bd.AddSubject("IS93", "лекція", "Вища математика", "Жук В.А.", "Thursday", "3", 310);
            schedule_bd.AddSubject("IS92", "практика", "Вища математика", "Пелехата О.Б.", "Thursday", "4", 310);

            ShowMainMenu(student_bd, schedule_bd);
        }
        public static void ShowMainMenu(Student_Database student_bd, ScheduleDatabase schedule_bd)
        {
            Console.WriteLine($"======================== Menu ========================\n" +
                $"1. Show schedule\n" +
                $"2. Add subject to schedule\n" +
                $"3. Show list of students\n" +
                $"4. Add student to database\n" +
                $"5. Find student in database\n" +
                $"6. Exit\n" +
                $"======================================================");
            int item = Convert.ToInt32(Console.ReadLine());
            if(item >6 && item <1) { ShowMainMenu(student_bd, schedule_bd); }
            switch (item)
            {
                case 1:
                    Console.WriteLine($"1. Teacher's schedule\n" +
                        $"2. Group's schedule");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(choice);
                    if(choice !=1 && choice != 2) { ShowMainMenu(student_bd, schedule_bd); }
                    switch(choice)
                    {
                        case 1:
                            Console.WriteLine($"1. Pair of teacher passing now\n" +
                                $"2. Week schedule");
                            int choice_type_teacher = Convert.ToInt32(Console.ReadLine());
                            if(choice_type_teacher != 1 && choice_type_teacher != 2) { ShowMainMenu(student_bd, schedule_bd); }
                            switch (choice_type_teacher)
                            {
                                case 1:
                                    Console.Write("Enter the name of the teacher: "); string choice_teacher1 = Console.ReadLine();
                                    if(String.IsNullOrWhiteSpace(choice_teacher1) || CheckForDigits(choice_teacher1)) { ShowMainMenu(student_bd, schedule_bd); }
                                    Console.WriteLine("====================================");
                                    schedule_bd.Check("teacher", choice_teacher1);
                                    ShowMainMenu(student_bd, schedule_bd);
                                    break;
                                case 2:
                                    Console.Write("Enter the name of the teacher: "); string choice_teacher2 = Console.ReadLine();
                                    if (String.IsNullOrWhiteSpace(choice_teacher2) || CheckForDigits(choice_teacher2)) { ShowMainMenu(student_bd, schedule_bd); }
                                    Console.WriteLine("====================================");
                                    schedule_bd.Check("week_teacher", choice_teacher2);
                                    ShowMainMenu(student_bd, schedule_bd);
                                    break;
                                default: ShowMainMenu(student_bd, schedule_bd); break;
                            }
                            break;
                        case 2:
                            Console.WriteLine($"1. Pair of group passing now\n" +
                                            $"2. Week schedule");
                            int choice_type_group = Convert.ToInt32(Console.ReadLine());
                            if(choice_type_group != 1 && choice_type_group !=2) { ShowMainMenu(student_bd, schedule_bd); }
                            switch (choice_type_group)
                            {
                                case 1:
                                    Console.Write("Enter the name of the teacher: "); string choice_group1 = Console.ReadLine();
                                    if (String.IsNullOrWhiteSpace(choice_group1)) { ShowMainMenu(student_bd, schedule_bd); }
                                    Console.WriteLine("====================================");
                                    schedule_bd.Check("group", choice_group1);
                                    ShowMainMenu(student_bd, schedule_bd);
                                    break;
                                case 2:
                                    Console.Write("Enter the name of the group: "); string choice_group2 = Console.ReadLine();
                                    if (String.IsNullOrWhiteSpace(choice_group2)) { ShowMainMenu(student_bd, schedule_bd); }
                                    Console.WriteLine("====================================");
                                    schedule_bd.Check("week_group", choice_group2);
                                    ShowMainMenu(student_bd, schedule_bd);
                                    break;
                                default: ShowMainMenu(student_bd, schedule_bd); break;
                            }
                            break;
                        default: Console.WriteLine("Input error!"); ShowMainMenu(student_bd, schedule_bd); break;
                    }
                    break;
                case 2:
                    Console.Write("Enter the group: "); string group = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(group)) { ShowMainMenu(student_bd, schedule_bd); }
                    Console.WriteLine("Enter type of lesson: ");
                    for (int i = 0; i < schedule_bd.myLists[1].Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {schedule_bd.myLists[1][i]}");
                    }
                    string type = Console.ReadLine();
                    while(type != "1" && type != "2")
                    {
                        type = Console.ReadLine();
                    }
                    switch(type)
                    {
                        case "1":
                            type = "лекція";
                            break;
                        case "2":
                            type = "практика";
                            break;
                    }
                    Console.Write("Enter the name of subject: "); string name = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(name) || CheckForDigits(name)) { ShowMainMenu(student_bd, schedule_bd); }
                    Console.Write("Enter the name of teacher (format: Жук В.А.): "); string teacher = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(teacher) || CheckForDigits(teacher)) { ShowMainMenu(student_bd, schedule_bd); }
                    Console.Write("Enter the day of week: "); string dayofweek = Console.ReadLine();
                    if (!schedule_bd.myLists[6].Contains(dayofweek)) { ShowMainMenu(student_bd, schedule_bd); }
                    Console.WriteLine("Enter the pair in whict the lesson will pass (1-4): "); string num_lesson = Console.ReadLine();
                    if (Convert.ToInt32(num_lesson)>4 || Convert.ToInt32(num_lesson) <1) { ShowMainMenu(student_bd, schedule_bd); }
                    Console.Write("Enter the audience in whict the lesson will pass: "); int audience = Convert.ToInt32(Console.ReadLine());
                    if(audience<0 || audience >600) { ShowMainMenu(student_bd, schedule_bd); }
                    schedule_bd.AddSubject(group, type, name, teacher, dayofweek, num_lesson, audience);
                    ShowMainMenu(student_bd, schedule_bd);
                    break;
                case 3:
                    Console.WriteLine("\n\n");
                    Console.WriteLine($"1. Show short info (just initials)\n" +
                        $"2. Full info");
                    int choice4 = Convert.ToInt32(Console.ReadLine());
                    if(choice4 != 1 && choice4 != 2) { ShowMainMenu(student_bd, schedule_bd); }
                    switch (choice4)
                    {
                        case 1:
                            Console.WriteLine("====================================");
                            student_bd.Check("short");
                            Console.WriteLine("====================================");
                            ShowMainMenu(student_bd, schedule_bd);
                            break;
                        case 2:
                            Console.WriteLine("====================================");
                            student_bd.Check("full");
                            Console.WriteLine("====================================");
                            ShowMainMenu(student_bd, schedule_bd);
                            break;
                        default: Console.WriteLine("Input error!"); break;
                    }
                    break;
                case 4:
                    Console.Write("Enter the name of student: "); string student_name = Console.ReadLine();
                    if(String.IsNullOrWhiteSpace(student_name) || CheckForDigits(student_name)) { ShowMainMenu(student_bd, schedule_bd); }
                    Console.Write("Enter the surname of student: "); string student_surname = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(student_surname) || CheckForDigits(student_surname)) { ShowMainMenu(student_bd, schedule_bd); }
                    Console.Write("Enter the lastname of student: "); string student_lastname = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(student_lastname) || CheckForDigits(student_lastname)) { ShowMainMenu(student_bd, schedule_bd); }
                    Console.Write("Enter the group of student: "); string student_group = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(student_group)) { ShowMainMenu(student_bd, schedule_bd); }
                    Console.Write("Enter the email of student: "); string student_email = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(student_name) || !student_email.Contains("@")) { ShowMainMenu(student_bd, schedule_bd); }
                    Console.Write("Enter the phone of student: "); string student_phone = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(student_phone) || student_phone.Contains("+380") || student_phone.Length != 13) { ShowMainMenu(student_bd, schedule_bd); }
                    student_bd.AddStudent(student_name, student_surname, student_lastname, "FIOT", student_group, student_email, student_phone);
                    ShowMainMenu(student_bd, schedule_bd);
                    break;
                case 5:
                    Console.Write("Enter one of the parameters (name/surname/lastname)"); string choice5 = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(choice5) || CheckForDigits(choice5)) { ShowMainMenu(student_bd, schedule_bd); }
                    student_bd.FindStudent(choice5);
                    break;
                case 6:
                    break;
                default: Console.WriteLine("Input error!"); break;
            }
        }
        private static bool CheckForDigits(string line)
        {
            for (int i = 0; i<line.Length; i++)
            {
                if (Char.IsDigit(line[i])) { return true; }
            }
            return false;
        }
    }
}
