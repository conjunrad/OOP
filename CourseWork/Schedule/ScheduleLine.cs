using Coursework;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Coursework
{
    class ScheduleLine
    {
        private Subject subjects;
        public ScheduleLine()
        {
            subjects = new Subject();
        }
        public void Add(string type, string name, string teacher, string dayofweek, string num_lesson, string group, int audience)
        {
            subjects["type"] = type;
            subjects["name"] = name;
            subjects["teacher"] = teacher;
            subjects["dayofweek"] = dayofweek;
            subjects["num_lesson"] = num_lesson;
            subjects["group"] = group;
            subjects["audience"] = audience.ToString();
        }
        public string this[string propname]
        {
            get
            {
                switch(propname)
                {
                    case "group": return subjects["group"];
                    case "dayofweek": return subjects["dayofweek"];
                    case "teacher": return subjects["teacher"];
                    case "num_lesson": return subjects["num_lesson"];
                    case "info": return $"Тип: {subjects["type"]} | Предмет: {subjects["name"]} | Викладач: {subjects["teacher"]} | Аудиторія: {subjects["audience"]}";
                    default: return null;
                }
            }
            set
            {
                switch(propname)
                {
                    case "type":
                        subjects["type"] = value;
                        break;
                    case "name":
                        subjects["name"] = value;
                        break;
                    case "teacher":
                        subjects["teacher"] = value;
                        break;
                    case "dayofweek":
                        subjects["dayofweek"] = value;
                        break;
                    case "num_lesson":
                        subjects["num_lesson"] = value;
                        break;
                    case "group":
                        subjects["group"] = value;
                        break;
                    case "audience":
                        subjects["audience"] = value;
                        break;
                }
            }
        }
    }
}
