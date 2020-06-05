using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using System.Text;
using System.Transactions;

namespace laba8
{
    class List
    {
        public delegate void ClearHandler(string message);
        public event ClearHandler Cleared = null;

        public string[] list;

        public List() 
        {
            list = new string[1];
        }
        public List(string[] list)
        {
            this.list = list;
        }
        public string this[int index]
        {
            get
            {
                if(index<list.Length && index>=0)
                {
                    return list[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range!");
                }
            }
            set
            {
                if (index >= 0)
                {
                    if (index >= list.Length)
                    {
                        int n = index + 1;
                        string[] new_list = new string[n];
                        for (int i = 0; i < list.Length; i++)
                        {
                            new_list[i] = list[i];
                        }
                        list = new_list;
                    }
                    list[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range!");
                }
            }
        }
        public string Pop(int index)
        {
            if (index >= list.Length || index < 0)
            {
                throw new IndexOutOfRangeException("Index is out of range!");
            }
            else
            {
                string[] new_list = new string[list.Length - 1];
                int counter = index + 1;
                string value = list[index];
                for (int i = 0; i < index; i++)
                {
                    new_list[i] = list[i];
                }
                if (index != list.Length - 1)
                {
                    for (int i = index; i < new_list.Length; i++)
                    {
                        new_list[i] = list[counter];
                    }
                }
                list = new_list;
                Cleared?.Invoke($"Value {value} successfully deleted!");
                return value;
            }
        }
        public void Clear()
        {
            list = new string[1];
            Cleared?.Invoke($"List cleared successfully!");
        }
    }
}
