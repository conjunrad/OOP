using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace laba5_2
{
    class Trapeze: Figure
    {
        private int[,] _coords;
        private double _ab = 0;
        private double _bc = 0;
        private double _cd = 0;
        private double _ad = 0;
        private double _height = 0;
        public Trapeze(int[,] data) : base()
        {
            _coords = data;
            _ab = CalcSides(new int[] { data[0, 0], data[0, 1] }, new int[] { data[1, 0], data[1, 1] });
            _bc = CalcSides(new int[] { data[1, 0], data[1, 1] }, new int[] { data[2, 0], data[2, 1] });
            _cd = CalcSides(new int[] { data[2, 0], data[2, 1] }, new int[] { data[3, 0], data[3, 1] });
            _ad = CalcSides(new int[] { data[0, 0], data[0, 1] }, new int[] { data[3, 0], data[3, 1] });
            _height = CalcHeight(_ab, _bc, _cd, _ad);
        }
        public override double Area()
        {
            return ((_bc + _ad) / 2 * _height);
        }
        public override double Perimeter()
        {
            return _ab + _bc + _cd + _ad;
        }
        private double CalcSides(int[] a, int[] b)
        {
            return Math.Sqrt(Math.Pow((b[0]-a[0]),2)+ Math.Pow((b[1] - a[1]), 2));
        }
        private double CalcHeight(double ab, double bc, double cd, double ad)
        {
            return Math.Sqrt(Math.Pow(ab, 2) - Math.Pow(((Math.Pow(ad - bc, 2) + Math.Pow(ab, 2) - Math.Pow(cd, 2)) / (2 * (ad - bc))),2));
        }
    }
}
