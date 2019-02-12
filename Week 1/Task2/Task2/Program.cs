using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student // Creating the new class Student.
    {
        public string Name;
        public string ID;
        public int Year;
        
        public Student(string Name, string ID)// Getting the input.
        {
            this.Name = Name;
            this.ID = ID;
        }

        public void StudentName()// Show the Student Name. 
        {
            Console.WriteLine(Name);
        }
        public void StudentID()// Show the Student ID. 
        {
            Console.WriteLine(ID);
        }
        public void StudentYearOfStudy()// And the Year of study with increase for 1 year after calling this function. 
        {
            Year++;
            Console.WriteLine(Year);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student Temirlan = new Student(Console.ReadLine(), Console.ReadLine()); //Creating new object in class Student.
            // Getting the information.
            Temirlan.StudentName();
            Temirlan.StudentID();
            Temirlan.StudentYearOfStudy();
            Console.ReadKey();
        }
    }
}
