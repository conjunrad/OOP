using System;
using System.Collections.Generic;
using System.Text;

namespace laba2
{
    class StringLine
    {
        private char[] text;
        
        public StringLine(string str)
        {
            text = str.ToCharArray();
        }
        
        public char[] GetText()
        {
            return text;
        }

        public int Length()
        {
            return text.Length;
        }
    }
}
