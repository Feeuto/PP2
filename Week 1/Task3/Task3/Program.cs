using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static int[] Double(int[] numbers)
        {
            int[] array = new int[numbers.Length * 2];// creating new array with twice more capacity, because input array should be doubled.
            int cnt = -1;// -1 in order to get the 0's element in new array.
            for (int i = 0; i < numbers.Length; i++) 
            {
                cnt++;// adding to double. 
                array[cnt] = numbers[i];
                cnt++;
                array[cnt] = numbers[i];
            }
            return array;// returning new array.
        }
        static void Main(string[] args)
        {
            string s1, s2; // strs to read input
            // Reading
            s1 = Console.ReadLine();
            s2 = Console.ReadLine();

            int number = int.Parse(s1);// Amount of numbers in s2.
            int[] numbers = new int[number];// Creating new array to get all numbers from s2.
            string[] n1 = s2.Split();// Splitting into numbers in s2.
            for(int i = 0; i < number; i++)
            {
                numbers[i] = int.Parse(n1[i]);// adding int numbers to array "numbers" 
            }
            int[] Newarr = Double(numbers);// Returning doubled array.
            // Showing the doubled array. 
            for(int i = 0; i < Newarr.Length; i++)
            {
                Console.Write(Newarr[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
