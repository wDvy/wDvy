#include <iostream>

struct LNode {
  public:
  int item;
  LNode *next;
};

class CLQueue {
public: 
  CLQueue();
  ~CLQueue();
  void MakeEmpty();
  bool IsEmpty() const;
  bool IsFull() const;
  void Enqueue(int newItem);
  int Dequeue();
//private:
  LNode* QEnd;
};


