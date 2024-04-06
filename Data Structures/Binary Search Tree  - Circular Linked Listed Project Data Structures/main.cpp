// #include "ASListR.h"
#include "BST.h"
#include <fstream>
#include <sstream>
#include <iostream>
using namespace std;

BST CSVtoBST(string csvfile) { //convert a csv file to a list structure

	cout << csvfile << endl;
	ifstream File (csvfile); //open the csv file for reading
	
    string line;
	string curvalue;
	BST returnTree;
    
	getline(File, line); //throw away the first line (column names)
	
    while (getline(File,line)) {        
    



        stringstream ss(line); //turn the line into a string-stream
        
		int fielditer=0;
        
		AvaRecord newrec;
		
		while(getline(ss, curvalue, ',')){ //Separate each variable per sample from the comma separator
            switch (fielditer) { //We need to explicitly convert values to the appropriate type (stoi=integer, stod=double)

            	case 0: newrec.index=stoi(curvalue); break;
            	case 1: newrec.date = curvalue; break;
            	case 2: newrec.avgprice = stod(curvalue); break;
            	case 3: newrec.totalvolume = stod(curvalue); break;
            	case 4: newrec.smallhass = stod(curvalue); break;
            	case 5: newrec.medhass = stod(curvalue); break;
            	case 6: newrec.largehass = stod(curvalue); break;
            	case 7: newrec.totalbags = stod(curvalue); break;
            	case 8: newrec.smallbags = stod(curvalue); break;
            	case 9: newrec.largebags = stod(curvalue); break;
            	case 10: newrec.xlargebags = stod(curvalue); break;
            	case 11: newrec.type = curvalue; break;
            	case 12: newrec.year = stoi(curvalue); break;
            	case 13: newrec.region = curvalue; break;
            	cout << newrec.index << endl;
			}
            fielditer++;
        }
        returnTree.PutItem(newrec);
    }
    return returnTree;
}

int main(int argc, char** argv) {
	
	
	BST AvacadoData = CSVtoBST("avacado.csv");
	AvacadoData.PrintTree(); 
}
    
