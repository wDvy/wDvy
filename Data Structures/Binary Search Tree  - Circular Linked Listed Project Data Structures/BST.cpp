#include "BST.h"
#include <string>
using namespace std;

  
BST::BST() {
  root=NULL;
  TravQueue=new CLQueue;
}


bool BST::IsFull() { // Returns true if there is no room for another item on the heap; false otherwise.
  TNode* location;
  try
  {
    location = new TNode;
    delete location;
    return false;
  }
  catch(std::bad_alloc exception)
  {
    return true;
  }
}

int BST::CountNodes(TNode* curnode) { //Return total number of nodes in (sub-)tree denoted by curnode
  if (curnode == NULL)
    return 0;
  else 
    return CountNodes(curnode->left) + CountNodes(curnode->right) + 1;
}

int BST::GetLength()
// Calls recursive function CountNodes to count the 
// nodes in the tree.
{
  return CountNodes(root);
}

bool BST::IsEmpty()
// Returns true if the tree is empty; false otherwise.
{
  return root == NULL;
}
  
void BST::Insert (TNode* &curnode, AvaRecord newitem) { //Helper function to insert an item into (sub-)tree denoted by curnode
  if (curnode==NULL) {
    curnode = new TNode;
	curnode->item = newitem;
	curnode->right = NULL;
	curnode->left = NULL;
  } else if (newitem.avgprice<curnode->item.avgprice)
    Insert(curnode->left,newitem);
  else
    Insert(curnode->right,newitem);
}
  
AvaRecord BST::FindItem(TNode* curnode, AvaRecord gitem) { //Helper function to locate an item in (sub-)tree denoted by curnode
  if (curnode == NULL)
    return gitem;
  else if (gitem.avgprice == curnode->item.avgprice)
    return curnode->item;
  else if (gitem.avgprice < curnode->item.avgprice)
    return FindItem(curnode->left,gitem);
  else
    return FindItem(curnode->right,gitem);
}


void BST::DeleteNode(TNode* &delnode) { //Helper function to delete an actual node
  TNode *tmpNode;
  if ((delnode->left) == NULL) { //If left child is null, we can replace with right child (whether NULL or not!)
    tmpNode = delnode;
    delnode = delnode -> right;
    delete(tmpNode);
  } else if ((delnode->right) == NULL) { //Check to see if other easy case applies (right child is NULL, but left is not)
    tmpNode = delnode;
    delnode = delnode -> left;
    delete(tmpNode);
  } else { //Difficult case -- we need to replace item with that of the logical predecessor
    TNode *predecessor = delnode->left;
    while (predecessor->right != NULL) {	
      predecessor = predecessor->right;
    }
    AvaRecord replaceitem = predecessor->item;
    delnode->item = replaceitem;
    Delete(delnode->left, replaceitem);
  }     
  
}



void BST::Delete(TNode* &curnode, AvaRecord ditem) { //Helper function to delete an item in (sub-)tree denoted by curnode
  if (curnode == NULL)
    throw;
  else if (ditem.avgprice < curnode->item.avgprice)
    Delete(curnode->left, ditem);   // Look in left subtree.
  else if (ditem.avgprice > curnode->item.avgprice)
    Delete(curnode->right, ditem);  // Look in right subtree.
  else
    DeleteNode(curnode);           // Node found; call DeleteNode.
}   


//Main functions always call recursive helper functions using root node as initial node
void BST::PutItem(AvaRecord newitem) {
  Insert(root,newitem);
}  

AvaRecord BST::GetItem(AvaRecord gitem) {
  return FindItem(root, gitem);
}
  
void BST::DeleteItem(AvaRecord ditem) {
  Delete(root,ditem);
}

void BST::PrintNodes(TNode* curnode) { // Prints items in (sub-)tree in sorted order
  if (curnode != NULL) {
    PrintNodes(curnode->left);   // Print left subtree.
    std::cout << curnode->item.avgprice << ", ";
    std::cout << curnode->item.date << ", ";
    std::cout << curnode->item.largebags << ", ";
    std::cout << curnode->item.largehass << ", ";
    std::cout << curnode->item.medhass << ", ";
    std::cout << curnode->item.region << ", ";
    std::cout << curnode->item.smallbags << ", ";
    std::cout << curnode->item.totalbags << ", ";
    std::cout << curnode->item.totalvolume << ", ";
    std::cout << curnode->item.type << ", ";
    std::cout << curnode->item.xlargebags << ", ";
    std::cout << curnode->item.year << ", " << std :: endl;




    PrintNodes(curnode->right);  // Print right subtree.
  }
}

void BST::PrintTree() {// Calls recursive function PrintNodes to print items in the tree.
  if (IsEmpty())
    std::cout<<"(Empty Tree)"<<std::endl;
  else {
    PrintNodes(root);
    std::cout << "\b\b "<<std::endl;
  }
}

void BST::CopyNodes(TNode*& copyNode, const TNode* origNode) {
  if (origNode == NULL)
    copyNode = NULL;
  else {
    copyNode = new TNode;
    copyNode->item = origNode->item;
    CopyNodes(copyNode->left, origNode->left);
    CopyNodes(copyNode->right, origNode->right);
  }
}

BST::BST(const BST& originalBST) { //Constructor that calls recursive function CopyNodes to copy original tree into root
  CopyNodes(root, originalBST.root);
  TravQueue=new CLQueue;
}

void BST::DestroyNodes(TNode*& curNode) {
  if (curNode != NULL) {
    DestroyNodes(curNode->left);
    DestroyNodes(curNode->right);
    delete curNode;
  }
}


void BST::MakeEmpty() {
  DestroyNodes(root);
  root=NULL;
}

BST::~BST() { //Destructor -- calls recursive Function DestroyNodes to destroy tree starting from root
  DestroyNodes(root);
  //std::cout<<"Destruction Complete!"<<std::endl;
}

bool BST::TravEmpty() {
  return TravQueue->IsEmpty();	
}

void BST::PreNodes(TNode* curNode) {    
  if (curNode!=NULL) {
    TravQueue->Enqueue(curNode->item.avgprice);
	PreNodes(curNode->left);    
    PreNodes(curNode->right);
  }
}

void BST::InNodes(TNode* curNode) {    
  if (curNode!=NULL) {
    InNodes(curNode->left);
    TravQueue->Enqueue(curNode->item.avgprice);
    InNodes(curNode->right);
  }
}

void BST::PostNodes(TNode* curNode) {    
  if (curNode!=NULL) {
    PostNodes(curNode->left);    
    PostNodes(curNode->right);
    TravQueue->Enqueue(curNode->item.avgprice);
  }
}

int BST::GetNextItem() {
	if (TravQueue->IsEmpty())
	  return INT_MIN;
	else
	  return (TravQueue->Dequeue());
}

void BST::ResetTree(OrderType order) {
// Calls function to create a queue of the tree elements in 
// the desired order.
  TravQueue->MakeEmpty();  
  switch (order) {
    case PRE_ORDER : PreNodes(root);
                     break;
    case IN_ORDER  : InNodes(root);
                     break;
    case POST_ORDER: PostNodes(root);
                     break;
  }
  
}

