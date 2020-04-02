using System;
using System.Collections.Generic;
using System.Text;

namespace laba3
{
    class Line
    {
        Student student = new Student();
        public Line(string name, string surname, string lastname)
        {
            student["name"] = name;
            student["surname"] = surname;
            student["lastname"] = lastname;
            student["fullname"] = surname + " " + name + " " + lastname;
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
                    default: return null;
                }
            }
        }
    }
}
