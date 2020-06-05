using System;
using System.Collections.Generic;
using System.Text;

namespace laba5_2
{
    class Figure
    {
        private int[] data;
        public Figure(params int[] data) { }
        public virtual double Area() { return 0; }
        public virtual double Perimeter() { return 0; }
    }
}
