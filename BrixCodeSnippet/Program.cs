using System;
using System.Linq;

namespace BrixCodeSnippet
{
    //Time complexity is O(n)
    //*5 *2.
   
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //allocate an array for all letters. if case matters, then index array should be double at double size
                //if not, compering statement should be if, using upper case.
                Console.WriteLine("Please enter a word to match:");

                string word = Console.ReadLine(); ;
                int CharachtersCount = 5;
                string[] ListOfWords = System.IO.File.ReadAllLines("../../../Dictionary.txt");

                Console.WriteLine("List of Matching Words for {0}", word);
                Boolean found = false;
                foreach (var ind in ListOfWords)
                {
                    int[] indexArray = new int[26];//allocate an array for all possible letters.  

                    for (int i = 0; i < CharachtersCount; i++)//add one to index array at letters position, 
                    {                                       // and decrease one if letter exists
                        indexArray[word[i] - 'a']++;
                        indexArray[ind[i] - 'a']--;
                    }

                    int counter = 0;
                    for (int i = 0; i < CharachtersCount; i++)//check if all index of letters on initial word, were turn back to zero.
                        if (indexArray[word[i] - 'a'] == 0)
                            counter++;
                        else i = CharachtersCount;//stop searching this word.
                    if (counter == CharachtersCount && !ind.Equals(word))//dont print the same word user chose
                    {
                        Console.WriteLine(ind);
                        found = true;
                    }

                }

                if (!found)
                    Console.WriteLine("Is Empty. Maybe try again? There is a nice list out there!!");
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
