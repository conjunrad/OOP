using System;
using System.Collections.Generic;
using System.Text;

namespace laba3
{
    class Student
    {
        string name;
        string surname;
        string lastname;
        string fullname;

        public string this[string propname]
        {
            get
            {
                switch (propname)
                {
                    case "name": return name;
                    case "surname": return surname;
                    case "lastname": return lastname;
                    case "fullname": return fullname;
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
                }
            }
        }
    }
}
