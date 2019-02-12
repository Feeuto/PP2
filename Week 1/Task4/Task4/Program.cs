using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());// Read the number of lines and columns in array.
            string[,] Array = new string[n, n];// Array where "[*]" will contain.
            for(int i = 0; i < n; i++)// The loop to get lines.
            {
                for(int j = 0; j < n; j++)// The loop to get columns.
                {
                    if(i == j || i > j)// Conditions to get down left side of the array.
                    {
                        Array[i, j] = "[*]";
                    }
                    Console.Write(Array[i, j]);// Showing the "[*]"
                }
                Console.WriteLine();// To finish every line.
            }
            Console.ReadKey();
        }
    }
}
