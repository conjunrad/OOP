using System;
using System.Collections.Generic;
using System.Text;

namespace laba6
{
    class Expression
    {
        private int _a;
        private int _b;
        private int _c;
        private int _d;
        public Expression(int a, int b, int c, int d)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
        }
        public double Calc()
        {
            if (_b <= 1)
            {
                throw new ArithmeticException("Incorrect logarithmic argument!");
            }
            if (_a*2+_b/_c == 0 || _c == 0)
            {
                throw new DivideByZeroException("Denominator shouldn't be equal 0.");
            }
            return (8*Math.Log10(_b-1)-_c)/(_a*2+_b/_c);
        }
    }
}
