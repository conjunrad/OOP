#include <iostream>
#include "LinkedList.h"

using namespace std;

int main() {
    LinkedList list;
    list.AddLast('a');
    list.AddLast('*');
    list.AddLast('#');
    list.AddLast('*');
    list.AddLast('5');
    list.Print();
    cout << "Number of * in list: " << list.CountAsteriks() << endl;
    list.Remove();
    list.Print();
    return 0;
}
