using System;
using System.Collections.Generic;
using System.Text;

namespace Coursework
{
    public class Student
    {
        string name;
        string surname;
        string lastname;
        string fullname;
        string faculty;
        string group;
        string email;
        string phone;
        public string this[string propname]
        {
            get
            {
                switch(propname)
                {
                    case "name": return name;
                    case "surname": return surname;
                    case "lastname": return lastname;
                    case "fullname": return fullname;
                    case "faculty": return faculty;
                    case "group": return group;
                    case "email": return email;
                    case "phone": return phone;
                    default: return null;
                }
            }
            set
            {
                switch (propname)
                {
                    case "name":
                        name = value;
                        break;
                    case "surname":
                        surname = value;
                        break;
                    case "lastname":
                        lastname = value;
                        break;
                    case "fullname":
                        fullname = value;
                        break;
                    case "faculty":
                        faculty = value;
                        break;
                    case "group":
                        group = value;
                        break;
                    case "email":
                        email = value;
                        break;
                    case "phone":
                        phone = value;
                        break;
                }
            }
        }
    }
}
