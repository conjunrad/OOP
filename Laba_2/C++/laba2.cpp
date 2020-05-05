#include <iostream>
#include <vector>
#include <Windows.h>


using namespace std;

vector<char> ToCharArray(string str)
{
    vector<char> CharArray;
    for (auto i : str)
    {
        CharArray.push_back(i);
    }
    return CharArray;
}

string ToString(vector<char> str)
{
    string myString = "";
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
    StringLine(string str)
    {
        text = ToCharArray(str);
    }
    string GetText()
    {
        return ToString(text);
    }
    int Length()
    {
        return text.size();
    }
};

void PrintString(StringLine str)
{
    for (auto i : str.GetText())
    {
        cout << i;
    }
    cout << endl;
}

class TextField
{
private:
    vector<StringLine> strings;
public:
    TextField(vector<string> txt)
    {       
        for (auto i : txt)
        {
            strings.push_back(StringLine(i));
        }
    }
    void ShowText()
    {
        if (strings.size() != 0)
        {
            cout << endl;
            for (auto i : strings)
            {
                PrintString(i);
            }
            cout << endl;
        }
    }
    void AddText(vector<string> txt)
    {
        int counter_general = strings.size() + txt.size();
        vector<StringLine> new_strings;
        for (int i = 0; i < strings.size(); i++)
        {
            new_strings.push_back(strings[i]);
        }
        for (auto i : txt)
        {
            new_strings.push_back(StringLine(i));
        }
        strings = new_strings;
    }
    void DelString()
    {
        int number = 0;
        cout << endl << "Enter the line number you want to delete: "; cin >> number;
        if (number > strings.size() && strings.size() > 0)
        {
            cout << "Error. The line number is greater than the number of lines" << endl;
        }
        else if (strings.size() == 0)
        {
            cout << "Text field is empty" << endl;
        }
        else
        {
            number -= 1;
            vector<StringLine> new_strings;
            for (int i = 0; i < number; i++)
            {
                new_strings.push_back(strings[i]);
            }
            for (int i = number+1; i < strings.size(); i++)
            {
                new_strings.push_back(strings[i]);
            }
            strings = new_strings;
        }
    }
    void ClearText()
    {
        strings.clear();
        cout << endl << "Text field is succesfully cleaned!" << endl;
    }
    void MaxLength()
    {
        int maxValue_index = 0;
        for (int i = 0; i < strings.size(); i++)
        {
            if (strings[i].Length() < maxValue_index)
            {
                maxValue_index = i;
            }
        }
        cout << "The longest line is " << maxValue_index << ": '" << strings[maxValue_index].GetText() << "'" << endl;
    }
    int LenText()
    {
        int counter = 0;
        for (int i = 0; i < strings.size(); i++)
        {
            counter += strings[i].Length();
        }
        return counter;
    }
    int GetAmountOfDigits()
    {
        int digit_amount = 0;
        for (int i = 0; i < strings.size(); i++)
        {
            for (int j = 0; j < strings[i].Length(); j++)
            {
                /*if (isdigit(strings[i].GetText()[j]) == true)
                {
                    cout << "TEST TEST TEST: " << strings[i].GetText()[j] << endl;
                    ++digit_amount;
                }*/
                if (isdigit(strings[i].GetText()[j]))
                {
                    cout << "YES";
                    ++digit_amount;
                }
            }
        }
        return digit_amount;
    }
    double DigitProcentInText()
    {
        int digit_amount = GetAmountOfDigits();
        int len_text = LenText();
        double percent = 100.0 * digit_amount / len_text;
        return percent;
    }
};



int main()
{
    TextField test = TextField({"Hello world", "Ho1a"});
    test.ShowText();
    test.ClearText();
    test.ShowText();
    test.AddText({ "Hello world", "Ho1a", "Ky", "Hallo" });
    test.ShowText();
    test.DelString();
    test.ShowText();
    test.MaxLength();
    cout << "The total number of characters: " << test.LenText() << endl;
    cout << "Percent of numbers in text: " << test.DigitProcentInText() << "%";
    //test.GetAmountOfDigits();
}
