#include <iostream>
#include <vector>

using namespace std;

vector<char> ToCharArray(const string &str)
{
    vector<char> CharArray;
    for (auto i : str)
    {
        CharArray.push_back(i);
    }
    return CharArray;
}

string ToString(const vector<char> &str)
{
    string myString;
    for (auto i : str)
    {
        myString += i;
    }
    return myString;
}



class StringLine
{
private:
    vector<char> text;
public:
    StringLine() 
    {
        vector<char> text(0);
    }
    StringLine(string str)
    {
        text = ToCharArray(str);

    }
    StringLine(StringLine& str)
    {
        text = str.text;
    }
    int Length()
    {
        return text.size();
    }
    void Print()
    {
        cout << ToString(text) << endl;
    }
    StringLine operator+(StringLine& str_1)
    {
        StringLine new_str;
        new_str.text = vector<char>(0);
        for (int i = 0; i < text.size(); i++)
        {
            new_str.text.push_back(text[i]);
        }
        for (int i = 0; i < str_1.Length(); i++)
        {
            new_str.text.push_back(str_1.text[i]);
        }
        return new_str;
    }
    StringLine operator-(char s)
    {
        StringLine new_str;
        new_str.text = vector<char>(0);
        int counter = 0;
        bool flag = false;
        for (int i = 0; i < text.size(); i++)
        {
            if (text[i] != s)
            {
                new_str.text.push_back(text[i]);
                counter += 1;
            }
        }
        return new_str;
    }
};


int main()
{
    StringLine CS1;
    StringLine CS2("Hell0 world! ");
    StringLine CS3(CS2);
    CS3 = CS3 - '0';
    CS3.Print();
    CS1 = CS2 + CS3;
    CS1.Print();
}
