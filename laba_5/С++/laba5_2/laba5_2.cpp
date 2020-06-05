#include <iostream>
#include <vector>
#include <math.h>

#define M_PI acos(-1.0)

using namespace std;


class Figure
{
public:
    Figure() {}
    virtual double Area() { return 0; }
    virtual double Perimeter() { return 0; }
};

class Trapeze : public Figure
{
private:
    double _ab = 0;
    double _bc = 0;
    double _cd = 0;
    double _ad = 0;
    double _height = 0;
    double CalcSides(vector<int> a, vector<int> b)
    {
        return sqrt(pow((b[0] - a[0]), 2) + pow((b[1] - a[1]), 2));
    }
    double CalcHeight(double ab, double bc, double cd, double ad)
    {
        return sqrt(pow(ab, 2) - pow(((pow(ad - bc, 2) + pow(ab, 2) - pow(cd, 2)) / (2 * (ad - bc))), 2));
    }
public:
    Trapeze(vector<vector<int>> data) : Figure() 
    {
        _ab = CalcSides({ data[0][0], data[0][1] }, { data[1][0], data[1][1] });
        _bc = CalcSides({ data[1][0], data[1][1] }, { data[2][0], data[1][1] });
        _cd = CalcSides({ data[2][0], data[2][1] }, { data[3][0], data[3][1] });
        _ad = CalcSides({ data[0][0], data[0][1] }, { data[3][0], data[3][1] });
        _height = CalcHeight(_ab, _bc, _cd, _ad);
    }
    double Area() override
    {
        return ((_bc + _ad) / 2 * _height);
    }
    double Perimeter() override
    {
        return _ab + _bc + _cd + _ad;
    }
};

class Circle : Figure
{
private:
    int _radius;
public:
    Circle(int r) : Figure() {
        _radius = r;
    }
    double Area() override {
        return M_PI * pow(_radius, 2);
    }
    double Perimeter() override
    {
        return 2 * M_PI * _radius;
    }
};

int main()
{
    Trapeze test({ { 0, 0 }, { 3, 4 }, { 8, 4 }, { 11, 0 } });
    cout << test.Area() << endl << test.Perimeter() << endl;
    Circle test1(5);
    cout << test1.Area() << endl << test1.Perimeter();
}
