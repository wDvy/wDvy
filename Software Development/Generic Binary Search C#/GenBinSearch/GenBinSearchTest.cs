// Devin Ward Final Pt3

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;


public class GenBinSearchTest
{
    public static void Main(string[] args)
    {
        int[] a1 = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
        double[] a2 = { 5.0, 10.0, 15.0, 20.0, 25.0, 30.0, 35.0, 40.0, 45.0, 50.0 };

        
        WriteLine("Search double array");
        foreach (double e in a2)
            Write($"{e:f1} ");
        WriteLine();

        WriteLine("Where is 50.0?");
        WriteLine($"Position: {BinarySearch(a2, 50.0)}");
        WriteLine("Where is 42.0?");
        WriteLine($"Position: {BinarySearch(a2, 42.0)}");
        
        WriteLine();

        WriteLine("Search int array");
        foreach (int e in a1)
            Write($"{e:d} ");
        WriteLine();

        WriteLine("Where is 50?");
        WriteLine($"Position: {BinarySearch(a1, 50)}");
        WriteLine("Where is 42?");
        WriteLine($"Position: {BinarySearch(a1, 42)}");
    }

    public static int BinarySearch<T>(IEnumerable<T> data, T searchElement) where T : IComparable
    {
        int low = 0; // low end of the search area                   
        int high = data.Count() - 1; // high end of the search area   
        int middle = (low + high + 1) / 2; // middle element       
        int location = -1; // return value; -1 if not found          

        do // loop to search for element                             
        {
            T item = data.ElementAt(middle);
            // if the element is found at the middle
            var compare = searchElement.CompareTo(item); // Compare to method
            if (compare == 0)
                location = middle; // location is the current middle   

            // middle element is too high                             
            else if (compare < 0)
                high = middle - 1; // eliminate the higher half        
            else // middle element is too low                         
                low = middle + 1; // eliminate the lower half          

            middle = (low + high + 1) / 2; // recalculate the middle
        } while ((low <= high) && (location == -1));

        return location; // return location of search key            
    } // end method BinarySearch  

}