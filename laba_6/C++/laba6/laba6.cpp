#include <iostream>
#include <math.h>
#include <vector>

using namespace std;

class Expression
{
private:
    int _a;
    int _b;
    int _c;
    int _d;
public:
    Expression(int a, int b, int c, int d)
    {
        _a = a;
        _b = b;
        _c = c;
        _d = d;
    }
    double Calc()
    {
        if (_b <= 1)
        {
            throw "Incorrect logarithmic argument!";
        }
        if (_a * 2 + _b / _c == 0 || _c == 0)
        {
            throw "Denominator/C value shouldn't be equal 0.";
        }
        return (8 * log10(_b - 1) - _c) / (_a * 2 + _b / _c);
    }
};

int main()
{
    vector<Expression> array = { Expression(-4,5,9,0), Expression(10,12,8,6), Expression(1,2,1,1) };
    for (auto i : array)
    {
        cout << i.Calc() << endl;
    }
}
