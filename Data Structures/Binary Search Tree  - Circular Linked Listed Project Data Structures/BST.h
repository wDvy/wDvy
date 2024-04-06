#include <iostream>
#include "CLQueue.h"


struct AvaRecord {
  int index;
  std :: string date;
  double avgprice;
  double totalvolume;
  double smallhass;
  double medhass;
  double largehass;
  double totalbags;
  double smallbags;
  double largebags;
  double xlargebags;
  std :: string type;
  int year;
  std :: string region;
};

struct TNode {
  public:
  AvaRecord item;
  TNode *left;
  TNode *right;
};

enum OrderType {PRE_ORDER, IN_ORDER, POST_ORDER};


class BST {
  public:
  BST();
  BST(const BST& originalBST); //(Deep-)Copy constructor
  ~BST(); //Destructor
  
  
  //main BST functions that call helper functions using the root Node
  AvaRecord GetItem(AvaRecord gitem);
  void PutItem(AvaRecord newitem);
  void DeleteItem(AvaRecord ditem);
  int GetLength();
  void MakeEmpty();
  bool IsEmpty();
  bool IsFull();
  void PrintTree();
  void ResetTree(OrderType order);
  int GetNextItem();
  bool TravEmpty();

  
  private:
  //helper functions called to recursively view/manipulate sub-tree elements
  void Insert (TNode* &curnode, AvaRecord newitem);
  AvaRecord FindItem(TNode* curnode, AvaRecord gitem);
  void Delete(TNode* &curnode, AvaRecord ditem);
  void DeleteNode(TNode* &curnode);
  int CountNodes(TNode* curnode);
  void PrintNodes(TNode* curnode);
  void CopyNodes(TNode*& copyNode, const TNode* origNode);
  void DestroyNodes(TNode*& curNode);
  void PreNodes(TNode* curNode);
  void InNodes(TNode* curNode);
  void PostNodes(TNode* curNode);
  
  TNode *root;
  CLQueue *TravQueue;
};
