using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task3
{
    class Program
    {
        static void Levels(int level)
        {
            for (int i = 0; i < level; i++)
                Console.Write("     ");
        }
        static void Repository(DirectoryInfo directory, int level)
        {
            FileInfo[] files = directory.GetFiles(); //Here I also can use FileSystemInfo. 
            DirectoryInfo[] directories = directory.GetDirectories();// This is the func to get all information about files and folders.

            foreach(FileInfo file in files)// To get to every file in files array.
            {
                Levels(level);// levels func is using to know in what level file or directory stores. 
                Console.WriteLine(file.Name);// Showing the files.
            }
            foreach (DirectoryInfo direct in directories)// To get to every folder in directories array.
            {
                Levels(level);
                Console.WriteLine(direct.Name);// Showing the directory
                // Level + 1 is in order to show that the following files and dir is located in this directory.
                Repository(direct, level + 1);// Here we use Recursive to get all files and directories.
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo("/Users/HP/Desktop/PP2_Experimental"); // Getting the data from directory in the given path. 
            Repository(d, 0);// Calling the Repository func. 
            Console.ReadKey();
        }
    }
}
