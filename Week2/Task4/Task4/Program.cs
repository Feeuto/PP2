using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = @"C:\Users\HP\Desktop\FirstFolder";// The path to the source folder.
            string path2 = @"C:\Users\HP\Desktop\SecondFolder";// The target.
             
            string FileName = "OriginalFileToCopy.txt";// Name of the file.
            // Combining file with the source and the target.
            path1 = Path.Combine(path1, FileName);
            path2 = Path.Combine(path2, FileName);
            //Checking if file exists or not.
            if (!File.Exists(path1))
            {
                FileStream fs1 = File.Create(path1);// If file does not exist then creating it.
                fs1.Close();// Closing file to use it in following functions.
                StreamWriter sw = new StreamWriter(path1);// Writing to the source file a text.
                sw.WriteLine("Something...");
                sw.Close();
            }
            else
            {
                Console.WriteLine("File {0} already exists", FileName);// If file exists...
            }
            File.Copy(path1, path2, true);// Copying the file in the target directory.
            File.Delete(path1);// Then deleting the original file.
        }
    }
}
