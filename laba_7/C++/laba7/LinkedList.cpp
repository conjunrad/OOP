#include <iostream>
#include "LinkedList.h"

using namespace std;

void LinkedList::CreateNode(char value) {
    node = new Node;
    node->value = value;
    node->next = nullptr;
}

void LinkedList::AddLast(char value) {
    Node* current = node;
    if (node == nullptr)
    {
        node = new Node{ value, nullptr };
        return;
    }
    while (current->next) current = current->next;
    current->next = new Node{ value, nullptr };
}

void LinkedList::Print()
{
    Node* current = node;
    while (current != nullptr)
    {
        cout << current->value << endl;
        current = current->next;
    }
}

int LinkedList::CountAsteriks() {
    Node* current = node->next;
    if (node == nullptr)
    {
        return -1;
    }
    int counter = 0;
    while (current != nullptr)
    {
        if (current->value == '*') ++counter;
        if (current->next == nullptr) break;
        current = current->next->next;

    }
    return counter;
}


void LinkedList::Remove() {
    Node* current = node;
    while (current != nullptr)
    {
        if (current->value == '#') {
            current->next = nullptr;
            break;
        }
        current = current->next;
    }
    cout << "Cleaning succesfully done!" << endl;
    
}
