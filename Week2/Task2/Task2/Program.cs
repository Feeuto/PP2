using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task2
{
    class Program
    {   
        static bool IsPrime(string a)
        {
            int s = int.Parse(a);// str to int.
            if (s == 1)// 1 is not a prime number therefore this condition. 
                return false;
            for (int i = 2; i <= Math.Sqrt(s); i++)
            {
                if ((s % i) == 0)// if this cond is true then the number is not prime
                {
                    return false;
                }
            }
            // If reaches here then the number is prime.
            return true;
        }
        static void Text()
        {
            StreamReader sr = new StreamReader("input.txt");// Reading from file.
            StreamWriter sw = new StreamWriter("output.txt");// Writing in another file.
            string s = sr.ReadToEnd();// Raed all from input file
            string[] num = s.Split();// Splitting into numbers(string).
            int i = 0;//Iterator to get all numbers in num array.
            foreach (var number in num)
            {
                if (IsPrime(num[i]) == true)// Checking prime or not 
                {
                    sw.Write(num[i] + " ");// Writing prime numbers in output file
                }
                i++;
            }    
            sr.Close();// Closing files.
            sw.Close();
        }
        static void Main(string[] args)
        {
            Text();// Calling the Text func.
            Console.ReadKey();
        }
    }
}
