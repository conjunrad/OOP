#ifndef LAB_7_LINKEDLIST_H
#define LAB_7_LINKEDLIST_H


#include <ostream>

class LinkedList {

private:
    struct Node
    {
        char value;
        Node* next;
    };

    Node* node = nullptr;

public:
    void CreateNode(char value);
    void AddLast(char value);
    void Print();
    int CountAsteriks();
    void Remove();
};


#endif //LAB_7_LINKEDLIST_H