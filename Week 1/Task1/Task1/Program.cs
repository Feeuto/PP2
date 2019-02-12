using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void IsPrime(int[] numbers)
        {
            int[] primeNum = new int[numbers.Length]; //Prime numbers array.
            int cnt = 0, k = 0; // Counter and iterator for array of Prime numbers.

            for (int i = 0; i < numbers.Length; i++) //Loop to get all numbers from array "numbers"
            {
                if (numbers[i] == 1) //1 is not a prime number.
                    continue;
                bool checkPrime = true; // bool to check prime or not.
                for (int j = 2; j <= Math.Sqrt(numbers[i]) ; j++)
                {
                    if ((numbers[i] % j) == 0)  
                    {
                        checkPrime = false;
                        break;
                    }
                }
                if (checkPrime == true)
                {
                    primeNum[k] = numbers[i];
                    cnt++;
                    k++;
                }
            }
            Console.WriteLine(cnt); //Writing the amount of prime numbers.
            for (int i = 0; i < k; i++) //Writing all prime numbers.
            {
                Console.Write(primeNum[i] + " ");
            }
        }

        static int[] FromStrToInt (String[] numbers)
        {
            int[] s3 = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++) //loop to get int from str. 
            {
                s3[i] = int.Parse(numbers[i]);
            }
            return s3;
        }

        static void Main(string[] args)
        {
            string s1, s2; // Create 2 str for read 2 inputs.
            // Reading inputs.
            s1 = Console.ReadLine(); 
            s2 = Console.ReadLine();
            
            int number = int.Parse(s1); //Changing 1st input from str to int.
            
            int[] numbers = new int[number]; //Array to get the 2nd line's numbers.

            string[] a = s2.Split(); // Splitting the big str s2 into many str a.
            
            numbers = FromStrToInt(a); //Changing all a's strings to int which will be saved in array numbers.
            
            IsPrime(numbers); //Checking all numbers in array for prime.
            
            Console.ReadKey();
        }
    }
}
