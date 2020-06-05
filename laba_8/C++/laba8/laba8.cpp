#include <iostream>
using namespace std;
#include <stdexcept>

string Symbol(string str)
{
    int digits = 0;
    int letters = 0;
    if (size(str) == 0)
        throw invalid_argument("The string is empty\n");
    else
    {
        for (int i = 0; i < size(str); i++)
        {
            if ((str[i] >= '0') && (str[i] <= '9'))
                digits++;
            if ((str[i] >= 'a') && (str[i] <= 'z'))
                letters++;
            if ((str[i] >= 'A') && (str[i] <= 'Z'))
                letters++;
        }
        if (digits == 0 && letters == 0)
            throw invalid_argument("The string has no letters or digits\n");
        if (digits > letters)
            cout << "The number of digits in a line is more\n";
        if (digits < letters)
            cout << "The number of letters in a line is more\n";
        else
            cout << "The number of numbers and letters in a line is the same.\n";
    }
    return str;
}

int main()
{
    string str = "123456";
    string(*Ptr)(string) = Symbol;
    try
    {
        Ptr(str);
    }
    catch (invalid_argument ex)
    {
        cout << ex.what();
    }
}