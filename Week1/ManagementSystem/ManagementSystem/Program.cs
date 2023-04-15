using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //User Data
            string[] userNames = new string[10];
            string[] userPasswords = new string[10];
            int userCount = 0;

            //Books Data
            int indexbook = 0;
            int[] bookIds = new int[10];
            string[] books = new string[10];
            string[] authors = new string[10];
            string[] genres = new string[10];

            ReadMembersData(userNames, userPasswords, ref userCount);
            ReadBooksData(bookIds, books, authors, genres, ref indexbook);

            int option;
            do
            {
                Console.Clear();
                option = LoginMenu();
                if (option == 1)
                {
                    Console.Clear();
                    Console.Write("Enter Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();
                    SignUp(username, password, userNames, userPasswords,ref userCount);
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (option == 2)
                {
                    Console.Clear();
                    Console.Write("Enter Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();
                    bool x = SignIn(username, password, userNames, userPasswords, ref userCount);
                    if (x == true)
                    {
                        AdminHandler(bookIds, books, authors, genres,ref indexbook);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Credentials!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else if (option > 3)
                {
                    Console.WriteLine("Invalid Choice!!");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            while (option != 3);
        }
        static void AdminHandler(int[] bookIds, string[] books, string[] authors, string[] genres, ref int indexbook)
        {
            int option;
            do
            {
                Console.Clear();
                option = AdminMenu();
                if (option == 1)
                {
                    int index;
                    Console.Clear();
                    Console.Write("Enter Book ID: ");
                    int bookid = int.Parse(Console.ReadLine());
                    index = ReturnIndex(bookIds, bookid, indexbook);
                    if (index == -1)
                    {
                        Console.Write("Enter Book Name: ");
                        string bookname = Console.ReadLine();
                        Console.Write("Enter Author Name: ");
                        string authorname = Console.ReadLine();
                        Console.Write("Enter Book Genre: ");
                        string genre = Console.ReadLine();
                        AddBook(bookid, bookname, authorname, genre, bookIds, books, authors, genres, ref indexbook);
                        Console.WriteLine("Book Added Successfully!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Book Already Exists!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else if (option == 2)
                {
                    int index;
                    Console.Clear();
                    Console.Write("Enter Book ID: ");
                    int bookid = int.Parse(Console.ReadLine());
                    index = ReturnIndex(bookIds, bookid, indexbook);
                    if (index != -1)
                    {
                        DeleteBook(index, bookIds, books, authors, genres, ref indexbook);
                        Console.WriteLine("Book Deleted Successfully!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Book doesn't Exist!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else if (option == 3)
                {
                    int index;
                    Console.Clear();
                    Console.Write("Enter Book ID: ");
                    int bookid = int.Parse(Console.ReadLine());
                    index = ReturnIndex(bookIds, bookid, indexbook);
                    if (index != -1)
                    {
                        Console.Write("Enter Author Name: ");
                        string name = Console.ReadLine();
                        ModifyBook(index, name, authors);
                        WriteBookDataToFile(bookIds, books, authors, genres, indexbook);
                        Console.WriteLine("Book Modified Successfully!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Book doesn't Exist!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else if (option == 4)
                {
                    Console.Clear();
                    PrintBooks(bookIds, books, authors, genres, indexbook);
                    Console.WriteLine("");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (option > 5)
                {
                    Console.WriteLine("Invalid Choice!!");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            while (option != 5);
        }
        static void AddBook(int bookid,string bookname, string authorname, string genre,int[] bookIds, string[] books, string[] authors, string[] genres, ref int indexbook)
        {
            bookIds[indexbook] = bookid;
            books[indexbook] = bookname;
            authors[indexbook] = authorname;
            genres[indexbook] = authorname;
            indexbook++;
            WriteBookDataToFile(bookIds, books, authors, genres, indexbook);
        }
        static void DeleteBook(int index,int[] bookIds,string[] books, string[] authors, string[] genres, ref int indexbook)
        {
            for(int i = index; i < indexbook - 1; i++)
            {
                bookIds[i] = bookIds[i + 1];
                books[i] = books[i + 1];
                authors[i] = authors[i + 1];
                genres[i] = genres[i + 1];
            }
            indexbook--;
            WriteBookDataToFile(bookIds, books, authors, genres, indexbook);
        }
        static void ModifyBook(int index,string name, string[] authors)
        {
            authors[index] = name;
        }
        static void PrintBooks(int[] bookIds, string[] books, string[] authors, string[] genres,int indexbook)
        {
            Console.WriteLine("BookId".PadRight(10) + "Books".PadRight(20) + "Authors".PadRight(20) + "Genres".PadRight(20));
            for (int i = 0; i < indexbook; i++)
            {
                Console.WriteLine(bookIds[i].ToString().PadRight(10) + books[i].PadRight(20) + authors[i].PadRight(20) + genres[i].PadRight(20));
            }
        }
        static int ReturnIndex(int[] bookIds,int bookid,int indexbook)
        {
            int index = -1;
            for(int i = 0; i < indexbook; i++)
            {
                if (bookid == bookIds[i])
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        static int AdminMenu()
        {
            int option;
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Delete Book");
            Console.WriteLine("3. Modify Book");
            Console.WriteLine("4. View Books");
            Console.WriteLine("5. Logout");
            Console.Write("Enter Choice: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static int LoginMenu()
        {
            int option;
            Console.WriteLine("1. Sign Up");
            Console.WriteLine("2. Sign In");
            Console.WriteLine("3. Exit");
            Console.Write("Enter Choice: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static void SignUp(string username,string password,string[] userNames,string[] userPasswords,ref int userCount)
        {
            userNames[userCount] = username;
            userPasswords[userCount] = password;
            userCount++;
            WriteMembersDataToFile(userNames, userPasswords, userCount);
        }
        static bool SignIn(string username, string password, string[] userNames, string[] userPasswords, ref int userCount)
        {
            bool x = false;

            for(int i = 0; i < userCount; i++)
            {
                if (username == userNames[i] && password == userPasswords[i])
                {
                    x = true;
                }
            }

            return x;
        }
        static void ReadBooksData(int[] bookIds,string[] books, string[] authors,string[] genres,ref int indexbook)
        {
            string path = "E:\\Semester2\\Lab\\OOP\\PD\\Week1\\ManagementSystem\\booksData.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    bookIds[indexbook] = int.Parse(data[0]);
                    books[indexbook] = data[1];
                    authors[indexbook] = data[2];
                    genres[indexbook] = data[3];
                    indexbook++;
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Data Files do not Exist");
            }
        }
        static void WriteBookDataToFile(int[] bookIds, string[] books, string[] authors, string[] genres, int indexbook)
        {
            string path = "E:\\Semester2\\Lab\\OOP\\PD\\Week1\\ManagementSystem\\booksData.txt";
            StreamWriter file = new StreamWriter(path);
            for (int i = 0; i < indexbook; i++)
            {
                file.WriteLine(bookIds[i] + "," + books[i] + "," + authors[i] + "," + genres[i]);
            }
            file.Flush();
            file.Close();
        }
        static void ReadMembersData(string[] userNames, string[] userPasswords,ref int userCount)
        {
            string path = "E:\\Semester2\\Lab\\OOP\\PD\\Week1\\ManagementSystem\\membersData.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine())!= null)
                {
                    string[] data = line.Split(',');
                    userNames[userCount] = data[0];
                    userPasswords[userCount] = data[1];
                    userCount++;
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Data Files do not Exist");
            }
        }
        static void WriteMembersDataToFile(string[] userNames, string[] userPasswords,int userCount)
        {
            string path = "E:\\Semester2\\Lab\\OOP\\PD\\Week1\\ManagementSystem\\membersData.txt";
            StreamWriter file = new StreamWriter(path);
            for(int i = 0; i < userCount; i++)
            {
                file.WriteLine(userNames[i] + "," + userPasswords[i]);
            }
            file.Flush();
            file.Close();
        }
    }
}
