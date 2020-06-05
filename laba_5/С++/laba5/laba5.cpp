#include <iostream>
#include <vector>
#include <math.h>

using namespace std;

vector<char> ToCharArray(const string& str)
{
    vector<char> CharArray;
    for (auto i : str)
    {
        CharArray.push_back(i);
    }
    return CharArray;
}

string ToString(const vector<char>& str)
{
    string myString;
    for (auto i : str)
    {
        myString += i;
    }
    return myString;
}

class MyString {
protected:
    vector<char> text;
public:
    MyString(string str) {
        text = ToCharArray(str);
    }
    int Length()
    {
        return text.size();
    }
    string GetText()
    {
        return ToString(text);
    }
};

class DigitalString : public MyString
{
public:
    DigitalString(string str) : MyString(str)
    {
        for (auto i : str)
        {
            if (!isdigit(i))
            {
                throw new invalid_argument("Error! Your arguments must contain only digits!");
            }
        }
    }
    void DelChar()
    {
        char symbol;
        cout << "Enter the digit you want to delete: "; cin >> symbol;
        vector<char> new_text;
        int counter = -1;
        for (int i = 0; i < text.size(); i++)
        {
            if (text[i] == symbol)
            {
                counter = i;
                break;
            }
            if (i != text.size() - 1)
            {
                new_text.push_back(text[i]);
            }
        }
        if (counter >= 0)
        {
            for (int i = counter + 1; i < text.size(); i++)
            {
                new_text.push_back(text[i]);
            }
            text = new_text;
        }
        else
        {
            cout << "Digit " << symbol << " is not found!" << endl;
        }
    }
};

int main()
{
    MyString test("Hello world!");
    DigitalString test1("12345");
    cout << test.GetText() << endl;
    cout << test1.GetText() << endl;
    test1.DelChar();
    cout << test1.GetText() << endl;
}