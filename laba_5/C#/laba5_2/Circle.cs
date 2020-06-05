using System;
using System.Collections.Generic;
using System.Text;

namespace laba5_2
{
    class Circle: Figure
    {
        private int _radius;
        public Circle(int r) : base()
        {
            _radius = r;
        }
        public override double Area()
        {
            return Math.PI*Math.Pow(_radius, 2);
        }
        public override double Perimeter()
        {
            return 2*Math.PI*_radius;
        }
    }
}
