
<h1 style="text-align: center;">Devin Ward</h2>

![C](https://img.shields.io/badge/c-%2300599C.svg?style=for-the-badge&logo=c&logoColor=white)  ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)  ![Python](https://img.shields.io/badge/python-3670A0?style=for-the-badge&logo=python&logoColor=ffdd54) ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)  ![HTML5](https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white) ![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E) ![CSS3](https://img.shields.io/badge/css3-%231572B6.svg?style=for-the-badge&logo=css3&logoColor=white)

Hello! My Name is Devin Ward, I'm a student interested in software and web development. I've collected some of my hosted projects and notable examples from my undergraduate classes below.


[Resume (Spring 2024)](DWResume2024-1.pdf)

## Projects
Projects Currently Listed on Github:

***Active***
- [Artifact / Chess Dungeon Game](https://github.com/speedacm/GD2024ChessDungeon)
		Current game development project for Speed Association of Computing Machinery, built in Unreal Engine using blueprints and C++.
- Portfolio Website WIP (.NET Model View Controller) 

***Inactive***
- [2D Platformer (Catformer)](https://github.com/speedacm/Game-Dev-Catformer)
		Second game development project for Speed ACM. 2D platformer built in Godot game engine with Python-like scripting language GDscript. 
- [Dungeon Crawler](https://github.com/speedacm/GameDevSHMUP)
		First game development project for Speed ACM, built in Godot.

# Undergrad Portfolio
<p align="center">
  <img src="University_of_Louisville_seal.svg.png" width="200" title="Uofl Seal">
</p>


## Web Development Project
This project was the culmination of the semester's work in full-stack development. The project consists of three major parts: a Database (hosted on Azure and managed through Microsoft SQL server management studio), an ASP.NET API, and a front-end windows form admin panel application.   

<details> 
  <summary> <h3>API Code Example</h3> <p>  This Code snippet is pulled from the API portion of the project and covers 3 of 9 HTTPS requests handled by the API. </p> </summary>
  


```c#
namespace ChessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChessGamesController : ControllerBase
    {
        [HttpGet(Name = "GetChessGames")]
        public IActionResult GetChessGames(int GameID)
        {
            using (ChessGamesDBContext cgdbc = new ChessGamesDBContext())
            {
                ChessGames foundchessgame = cgdbc.ChessGames.Find(GameID);

                if (foundchessgame != null)
                {
                    return Ok(foundchessgame);
                }
                else
                {
                    return NotFound($"Game ID {GameID} does not exist");
                }
            }
        }

        [HttpPost(Name = "PostChessGames")]
        public IActionResult PostChessGames([FromBody] ChessGames gameData)
        {
            using (ChessGamesDBContext cgdbc = new ChessGamesDBContext())
            {
                ChessGames foundchessgame = cgdbc.ChessGames.Find(gameData.GameID);

                if(foundchessgame == null)
                {
                    cgdbc.ChessGames.Add(gameData);
                    cgdbc.SaveChanges();
                    return Ok(gameData);
                }
                else
                {
                    return BadRequest($"The Game ID {gameData.GameID} already exists");
                }
            }
        }

        [HttpPut(Name = "PutChessGames")]
        public IActionResult PutChessGames(int GameID, [FromBody] ChessGames gameData)
        {
            using (ChessGamesDBContext cgdbc = new ChessGamesDBContext())
            {
                ChessGames foundchessgame = cgdbc.ChessGames.Find(GameID);

                if (foundchessgame != null)
                {
                    foundchessgame.PlayerID1 = gameData.PlayerID1;
                    foundchessgame.PlayerID2 = gameData.PlayerID2;
                    foundchessgame.WinningPlayer = gameData.WinningPlayer;
                    foundchessgame.LosingPlayer = gameData.LosingPlayer;
                    foundchessgame.GameTime = gameData.GameTime;

                    cgdbc.SaveChanges();
                    return Ok(gameData);
                }
                else
                {
                    return NotFound($"Game ID {GameID} does not exist");
                }
            }
        }
    }
}
```
</details>


<details> 
  <summary> <h3>Application Code Example</h3> 
  <p> Simple POST and GET requests pulled from the application. 
  </summary>
  
```c#
        //POST request for Users
        private async void createGamebtn_Click(object sender, EventArgs e)
        {
            DateTime gameTime = DateTime.Parse(gameTimeTextbox.Text);

            var data = new
            {
                gameID = 0,
                playerID1 = playerID1TextBox.Text,
                playerID2 = playerID2TextBox.Text,
                winningPlayer = winningPlayerTextBox.Text,
                losingPlayer = losingPlayerTextBox.Text,
                gameTime = gameTime
            };

            var jsondata = JsonSerializer.Serialize(data);
            var content = new StringContent(jsondata, Encoding.UTF8, "application/json");

            using (HttpClient chessClient = new HttpClient())
            {
                try
                {
                    chessClient.BaseAddress = new Uri($"https://localhost:{port}/api/");
                    var response = await chessClient.PostAsync($"ChessGames?GameID=0", content);

                    response.EnsureSuccessStatusCode();

                    MessageBox.Show("New Game Created");
                    newGameLogbtn.Enabled = true;
                    gamesSearchTextBox.Text = "";
                }
                catch (HttpRequestException err)
                {
                    MessageBox.Show("New game not created. Please fill in all fields");
                    newGameLogbtn.Enabled = false;
                }
            }
        }


        //GET Request for Users
        private async void getUserbtn_Click(object sender, EventArgs e)
        {
            using (HttpClient chessClient = new HttpClient())
            {
                try
                {
                    chessClient.BaseAddress = new Uri($"https://localhost:{port}/api/");

                    chessClient.DefaultRequestHeaders.Add("User_Agent", "CIS411FinalAssignment");
                    chessClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string UserID = userIDTextBox.Text;
                    System.IO.Stream pageinfo = null;
                    var response = await chessClient.GetAsync($"ChessUsers?UserName={UserID}");
                    response.EnsureSuccessStatusCode();
                    pageinfo = await response.Content.ReadAsStreamAsync();
                    editUserbtn.Enabled = true;
                    deleteUserbtn.Enabled = true;
                    button1.Enabled = false;

                    ChessUser chessUser = JsonSerializer.Deserialize<ChessUser>(pageinfo);

                    usernameOutlbl.Text = chessUser.userName;
                    RegisterDateOutlbl.Text = "" + chessUser.registerDate;
                    dateOfBirthOutlbl.Text = "" + chessUser.dateOfBirth;
                    userRankOutlbl.Text = chessUser.userRank;
                    eloScoreOutlbl.Text = "" + chessUser.eloScore;
                    displayNameOutlbl.Text = chessUser.displayName;
                }
                catch (HttpRequestException err)
                {
                    MessageBox.Show($"User Not Found");
                    editUserbtn.Enabled = false;
                    deleteUserbtn.Enabled = false;
                    button1.Enabled = true;
                    newUsernameTextBox.Text = userIDTextBox.Text;
                }
            }
        }
```
</details>

## Data Structures and Algorithms
A quick example of some data structures and algorithms from Undergrad Courses:

<details> 
  <summary> <h3>Binary Search Tree Implementation with Binary Search Algorithm</h3> <p> Example of C++ Code and Data structure understanding</p> </summary>

```c++
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

```
</details>

<details> 
  <summary> <h3>Remove Duplicates</h3> <p>Given an array of ints, remove any instance of the int where it appears more than 2 times. return the length of the array that would comprise the orignal array - any double duplicates.</p> </summary>

```cpp

int removeduplicates(vector<int>& nums){
  int i =0;
  for (int element : nums)
    {
    if(i == 0 || i == 1 || nums[i-2] != element)
      {
        nums[i] = element;
        i++;
      }
    }
    return i;
}

```


## Explanation:
1. Initialize i = 0, this is the index for the modified array to be returned.
2. iterate through the length of the array, checking
3. If we are on the first element, the second element, or if the index two steps back equals the current element.
4. if so, set the array's ith element to the current element and increase i, if not skip that element and continue to the next.
5. return i.

</details>




<details> 
  <summary> <h3>Hashmap - Ransom Note Problem</h3>
  <p>Given two strings ransomNote and magazine, find out if you can construct the contents of ransomNote with the characters in magazine. Each character can only be used once.</p>
  </summary>


```cpp
bool canConstruct(string ransomNote, string magazine) {
	unordered_map<char, int> dictionary;
	
	for(char c : magazine){
	
		if(dictionary.find(c) == dictionary.end()){
			dictionary[c] = 1;
		} else {
			dictionary[c]++;
		}

	}

	for(char c: ransomNote){
	
		if(dictionary.find(c) != dictionary.end() && dictionary[c] > 0){
			dictionary[c]--;
		} else {
			return false;
		}
	}
	return true;
}
```

## Explanation
1. Create hashmap (in cpp as unordered_map) with type char and int named dictionary.
2. for every character in string magazine, check if that character is in the hashmap (the if statement explicitly is checking if the character found equals the .end() function which always returns true if the character is not within the hashmap(?))
3. if it does not exist, add it do the hashmap, if it does exist, iterate it by one to show that there is more than one inside.
4. then, iterate through every character in the ransomNote String. if the character exists within the hashmap, and it's integer value (count) is greater than 0, remove it from the hashtable and continue. 
5. if it does not exist within the hashtable, return false, as the ransomNote could not be created from the magazine. 
6. If you successfully iterate through the entirety of the ransomNote with characters from the magazine string, than it can be created from it, so return true.

</details>


### [Data Structures C++](https://github.com/wDvy/wDvy/tree/main/Data%20Structures)
### [More Algo implementations](https://github.com/wDvy/code-challenges/tree/main)









- Automata Theory
- [Analytical Programming (Python)](https://github.com/wDvy/wDvy/tree/main/Analytical%20Programming)
- [Software Development I & II (C#)](https://github.com/wDvy/wDvy/tree/main/Software%20Development)

- Design of Databases (Microsoft SQL Server)
- [Systems Analysis and Design](https://github.com/wDvy/wDvy/tree/main/Systems%20Analysis%20and%20Design)


