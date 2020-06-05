using System;
using System.Collections.Generic;
using System.Text;

namespace Coursework
{
    class Subject
    {
        string type;
        string name;
        string teacher;
        string dayofweek;
        string group;
        string num_lesson;
        int audience;
        public string this[string propname]
        {
            get
            {
                switch(propname)
                {
                    case "type": return type;
                    case "name": return name;
                    case "teacher": return teacher;
                    case "dayofweek": return dayofweek;
                    case "num_lesson": return num_lesson;
                    case "group": return group;
                    case "audience": return audience.ToString();
                    default: return null;
                }
            }
            set
            {
                switch (propname)
                {
                    case "type":
                        type = value;
                        break;
                    case "name":
                        name = value;
                        break;
                    case "teacher":
                        teacher = value;
                        break;
                    case "dayofweek":
                        dayofweek = value;
                        break;
                    case "num_lesson":
                        num_lesson = value;
                        break;
                    case "group":
                        group = value;
                        break;
                    case "audience":
                        audience = Convert.ToInt32(value);
                        break;
                }
            }
        }
    }
}