using System;
using System.Collections.Generic;
using System.Text;

namespace Coursework
{
    public class Line
    {
        Student student = new Student();
        public Line(string surname, string name, string lastname, string faculty, string group, string email, string phone)
        {
            student["name"] = name;
            student["lastname"] = lastname;
            student["surname"] = surname;
            student["faculty"] = faculty;
            student["group"] = group;
            student["fullname"] = surname + " " + name + " " + lastname;
            student["email"] = email;
            student["phone"] = phone;
        }
        public string this[string propname]
        {
            get
            {
                switch (propname)
                {
                    case "name": return student["name"];
                    case "surname": return student["surname"];
                    case "lastname": return student["lastname"];
                    case "fullname": return student["fullname"];
                    case "faculty": return student["faculty"];
                    case "group": return student["group"];
                    case "email": return student["email"];
                    case "phone": return student["phone"];
                    case "info": return $"\n#########################################################\n" +
                            $"ПІБ:{student["fullname"]}\n" +
                            $"Факультет: {student["faculty"]}\n" +
                            $"Група: {student["group"]}\n" +
                            $"Email: {student["email"]}" +
                            $"Телефон: {student["phone"]}\n" +
                            $"#########################################################";
                    default: return null;
                }
            }
            set
            {
                switch (propname)
                {
                    case "surname":
                        student["surname"] = value;
                        break;
                }
            }
        }
    }
}
