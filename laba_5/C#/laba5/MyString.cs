using System;
using System.Collections.Generic;
using System.Text;

namespace laba5_1
{
    class MyString
    {
        protected char[] text;
        public MyString(string str)
        {
            text = str.ToCharArray();
        }
        public int Lenght() => text.Length;
        public char[] GetText()
        {
            return text;
        }
    }
}
