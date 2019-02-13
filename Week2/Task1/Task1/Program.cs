using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        static bool IsPalindrome(string Word)
        {
            string lowercaseWord = Word.ToLower();// Change the letters from uppercase to lowercase.
            for ( int i = 0; i < lowercaseWord.Length; i++)// the loop to check every char in str.
            {
                if(lowercaseWord[i] != lowercaseWord[lowercaseWord.Length - 1 - i])// If this condition will be true.
                {
                    return false;//Then it will return false to show that the given str is not palindrome.
                } 
            }
            return true;// If it reaches to here then the given str will be palindrome.
        }
        static void Word()
        {
            StreamReader sr = new StreamReader("Week2T1.txt");// reading from file.
            string word = sr.ReadToEnd();// reading till the end.
            string WordWithoutSpaces = "";// string with removed spaces and etc.
            for(int i = 0; i < word.Length; i++)// The loop to remove them.
            {
                if (word[i] == ' '|| word[i] == '!'|| word[i] == ','|| word[i] == '.'|| word[i] == ':')
                    continue;
                WordWithoutSpaces += word[i];
            }
            //Showing that given string is palindrome or not with the help of IsPalindrome function.
            if (IsPalindrome(WordWithoutSpaces) == true)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            sr.Close();// Closing the opened file.
        }
        static void Main(string[] args)
        {
            Word();// Calling the Word function.
            Console.ReadKey();
        }
    }
}
