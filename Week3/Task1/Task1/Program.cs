using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Task1
{
    class FarManager
    {   
        public int Cursor;
        public int SizeOfFolder;
        public string path;
        FileSystemInfo curFS = null;
        DirectoryInfo directory = null;
        public bool ok;
        public int F;
        public int location;

        public FarManager(string path)// Constuctor to get the input "path" and the information about it.
        {
            this.path = path;
            directory = new DirectoryInfo(path);
            SizeOfFolder = directory.GetFileSystemInfos().Length;
            Cursor = 0;
            ok = true;
            location = 0;
        }

        public void Up()// It moves up the cursor with reducing the value of the variable "Cursor".
        {
            Cursor--;
            if (SizeOfFolder <= 10)// When SizeOfFolder less than 11.
            {
                if (Cursor < 0)// If it reaches the top then it will transfer the Cursor to the bottom.
                {
                    Cursor = SizeOfFolder - 1;
                }
            }
            else// When more than 10.
            {
                if (Cursor < location)//It is to move up when it reaches upper bound "location". 
                {
                    location -= 1;
                }
                if (Cursor < 0)// It transfers to the bottom. Hence the loc and Cursor will change.
                {
                    location = SizeOfFolder - 10;
                    Cursor = SizeOfFolder - 1;
                }
            }
        }

        public void Down()// It is converse to the func Up().
        {
            Cursor++;
            if (SizeOfFolder <= 10)
            {
                if (Cursor == SizeOfFolder)
                {
                    Cursor = 0;
                }
            }
            else
            {
                if(Cursor > 9 && Cursor != SizeOfFolder)
                {
                    location += 1;
                    if(location == SizeOfFolder - 9)// There are some moments when loc's value is more than it should be and the error comes out.
                    {
                        location = SizeOfFolder - 10;// this if() is to fix it.
                    }
                }
                if(Cursor == SizeOfFolder)// When it reaches the bottom it transfers to the top.
                {
                    location = 0;
                    Cursor = 0;
                }
            }
        }
        
        public void Color(FileSystemInfo file, int index)// The func's purpose is to color files or folder proceeding from their type.
        {
            Type type1 = typeof(DirectoryInfo);// Getting inf about type.
            Type type2 = typeof(FileInfo);
            if (index == Cursor && file.GetType() == type1)// The coloring when the cursor on a folder. 
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
                curFS = file;// We take the value of file to curFS. It helps us in the moments when we press the enter or use another commands in Start().
            }
            else if(index == Cursor && file.GetType() == type2)// On a file.
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Red;
                curFS = file;
            }
            else if(file.GetType() == type1)// Coloring of a folder
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (file.GetType() == type2)// Of a file.
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public void Show()
        {
            directory = new DirectoryInfo(path);
            FileSystemInfo[] fileInfo = directory.GetFileSystemInfos();
            Console.BackgroundColor = ConsoleColor.Black;// Cleaning the console from files and their color.
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            int index = 0;// Using index to know where cursor locates.
            Console.WriteLine(directory.FullName);// Showing where we are.
            if (SizeOfFolder > 10)// If folder has more than 10 files or folders. Then it shows only 10 files or folders and movex along when reaches borders.
            {
                for(int i = location; i < 10 + location; i++)
                {
                    if (ok == false && fileInfo[i].Name[0] == '.')// If ok is false we should ignore the hidden files. In false mode it does not work correctly.
                    {
                        continue;
                    }
                    Color(fileInfo[i], i);
                    Console.WriteLine(i + 1 + ". " + fileInfo[i].Name);                    
                }
            }
            else
            {
                for (int i = 0; i < fileInfo.Length; i++)
                {
                    if (ok == false && fileInfo[i].Name[0] == '.')// If ok is false we should ignore the hidden files.
                    {
                        continue;
                    }
                    Color(fileInfo[i], index);// Coloring and showing.
                    Console.WriteLine(index + 1 + ". " + fileInfo[i].Name);
                    index++;
                }
            }
        }

        public void Start()
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey();// consoleKey variable's purpose is to catch what command we choose. 
            while (consoleKey.Key != ConsoleKey.Escape)// This loop will work until we do not press the escape button.
            {
                CalcSz();
                Show();
                consoleKey = Console.ReadKey();// Reading consoleKey.
                if(consoleKey.Key == ConsoleKey.UpArrow)
                {
                    Up();// Moving the cursor Up 
                }

                if(consoleKey.Key == ConsoleKey.DownArrow)
                {
                    Down();// Moving Down.
                }

                if(consoleKey.Key == ConsoleKey.F)// Changing the mode. When we show and hide hidden files.
                {
                    Cursor = 0;
                    F++;// F to know in which mode we're in.
                    if(F % 2 == 1)//Showing
                    {
                        ok = false;
                    }
                    else// Hiding.
                    {
                        ok = true;
                    }
                }

                if(consoleKey.Key == ConsoleKey.E)// Creating a file not a folder.
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.WriteLine("Text the name of the file:");
                    string FileName = Console.ReadLine();
                    string create = Path.Combine(path, FileName);
                    if (!File.Exists(create))// Checking file already exists or not.
                    {
                        FileStream fs = File.Create(create);
                        fs.Close();
                    }
                    else
                    {
                        Console.WriteLine("This {0} file already exists", FileName);
                        Console.ReadKey();
                    }
                    
                }

                if(consoleKey.Key == ConsoleKey.Q)// Deleting a file or a folder
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.WriteLine("Do you really want to delete?");
                    Console.WriteLine("If yes , press the Q button again.");
                    consoleKey = Console.ReadKey();
                    if(consoleKey.Key == ConsoleKey.Q)// Asking to delete or not for the purpose of avoiding the missclicks.
                    {
                        if(curFS.GetType() == typeof(FileInfo))
                            File.Delete(curFS.FullName);
                        else
                            Directory.Delete(curFS.FullName);
                    }
                }

                if(consoleKey.Key == ConsoleKey.C)// Renaming.
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.WriteLine("File's or folder's new name is:");
                    string newname = Console.ReadLine();
                    string rename = Path.Combine(path, newname);
                    if (curFS.GetType() == typeof(FileInfo))// Proceeding from it's type renaming it.
                        File.Move(curFS.FullName, rename);
                    else
                        Directory.Move(curFS.FullName, rename);
                }
                
                if(consoleKey.Key == ConsoleKey.Enter)
                {
                    if(curFS.GetType() == typeof(FileInfo))// Opening the files.
                    {
                        Process.Start(curFS.FullName);
                    }
                    else// Opening the folders.
                    {
                        Cursor = 0;
                        path = curFS.FullName;// Changing the path aiming at to enter a folder.
                    }
                }

                if(consoleKey.Key == ConsoleKey.Backspace)// Exit from a folder.
                {
                    Cursor = 0;
                    path = directory.Parent.FullName;// Getting it's parent fullname because it shows where our folder is locating.
                }
            }
        }
        
        public void CalcSz()// We want here the func that calculates the size of the folder in order to hide the hidden files. If the bool "ok" is false.
        {
            directory = new DirectoryInfo(path);
            FileSystemInfo[] file = directory.GetFileSystemInfos();
            SizeOfFolder = file.Length;
            if (ok == false)// In false condition we remove all hidden files.
                for (int i = 0; i < file.Length; i++)
                    if (file[i].Name[0] == '.')// If it finds a file which is started with '.'. Then, it will reduce the SizeOfFolder.
                        SizeOfFolder--;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = "/Users/HP/Desktop/PP2_Experimental";
            FarManager d = new FarManager(path);
            d.Start();
        }
    }
}   
