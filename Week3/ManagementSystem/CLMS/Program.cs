using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLMS.BL;

namespace CLMS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Credentials> c = new List<Credentials>();
            List<BooksData> b = new List<BooksData>();
            ReadLoginCredentials(c);
            ReadBooksData(b);
            char option;
            do
            {
                Console.Clear();
                option = Menu();
                if (option == '1')
                {
                    Console.Clear();
                    Credentials user = TakeInputWithRole();
                    if (user != null)
                    {
                        StoreDataToList(c, user);
                        WriteCredentials(c);
                    }
                    Console.WriteLine("Signed UP successfully");
                    Console.Write("Press any key to continue..");
                    Console.ReadKey();
                }
                else if (option == '2')
                {
                    Console.Clear();
                    Credentials user = TakeInputWithoutRole();
                    if (user != null)
                    {
                        user = CheckCredentials(c, user);
                        if (user == null)
                        {
                            Console.WriteLine("Invalid User");
                        }
                        else if (user.isAdmin())
                        {
                            AdminHandler(b);
                        }
                        else
                        {
                            Console.WriteLine("User Menu");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Credentials!!!");
                        Console.Write("Press any key to continue..");
                        Console.ReadKey();
                    }
                }
                else if (option == '3')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice!!!");
                }
            }
            while (option != '3');
            Console.Write("Press any key to exit..");
            Console.ReadKey();
        }
        static void StoreDataToList(List<Credentials> c, Credentials user)
        {
            c.Add(user);
        }
        static void AdminHandler(List<BooksData> b)
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
                    index = ReturnIndex(b, bookid);
                    if (index == -1)
                    {
                        Console.Write("Enter Book Name: ");
                        string bookname = Console.ReadLine();
                        Console.Write("Enter Author Name: ");
                        string authorname = Console.ReadLine();
                        Console.Write("Enter Book Genre: ");
                        string genre = Console.ReadLine();
                        AddBook(bookid, bookname, authorname, genre, b);
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
                    index = ReturnIndex(b, bookid);
                    if (index != -1)
                    {
                        DeleteBook(index, b);
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
                    index = ReturnIndex(b, bookid);
                    if (index != -1)
                    {
                        Console.Write("Enter Author Name: ");
                        string name = Console.ReadLine();
                        ModifyBook(index, name, b);
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
                    PrintBooks(b);
                    Console.WriteLine("");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (option == 5)
                {
                    break;
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
        static void PrintBooks(List<BooksData> b)
        {
            Console.WriteLine("BookId".PadRight(10) + "Books".PadRight(20) + "Authors".PadRight(20) + "Genres".PadRight(20));
            for (int i = 0; i < b.Count; i++)
            {
                Console.WriteLine(b[i].bookID.ToString().PadRight(10) + b[i].bookName.PadRight(20) + b[i].author.PadRight(20) + b[i].genre.PadRight(20));
            }
        }
        static void ModifyBook(int index, string name, List<BooksData> b)
        {
            b[index].author = name;
            WriteBooksData(b);
        }
        static void DeleteBook(int index, List<BooksData> b)
        {
            b.RemoveAt(index);
            WriteBooksData(b);
        }
        static void AddBook(int bookid, string bookname, string authorname, string genre, List<BooksData> b)
        {
            BooksData b1 = new BooksData(bookid, bookname, authorname, genre);
            b.Add(b1);
            WriteBooksData(b);
        }
        static int ReturnIndex(List<BooksData> b, int bookid)
        {
            int index = -1;
            for (int i = 0; i < b.Count; i++)
            {
                if (b[i].bookID == bookid)
                {
                    index = i;
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
        static char Menu()
        {
            char option;
            Console.WriteLine("1. Sign UP");
            Console.WriteLine("2. sign IN");
            Console.WriteLine("3. Exit");
            option = char.Parse(Console.ReadLine());
            return option;
        }
        static Credentials TakeInputWithoutRole()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            if (name != null && password != null)
            {
                Credentials c = new Credentials(name, password);
                return c;
            }
            return null;
        }
        static Credentials TakeInputWithRole()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter Role: ");
            string role = Console.ReadLine();
            if (name != null && password != null && role != null)
            {
                Credentials c = new Credentials(name, password, role);
                return c;
            }
            return null;
        }
        static Credentials SignUp(string username, string password)
        {
            Credentials c1 = new Credentials(username, password);
            return c1;
        }
        static Credentials CheckCredentials(List<Credentials> c, Credentials user)
        {
            foreach (Credentials x in c)
            {
                if (user.username == x.username && user.password == x.password)
                {
                    return x;
                }
            }
            return null;
        }
        static void WriteCredentials(List<Credentials> c)
        {
            string path = "E:\\Semester2\\OOP\\PD\\Week3\\ManagementSystem\\membersdata.txt";
            StreamWriter myFile = new StreamWriter(path);
            for (int i = 0; i < c.Count; i++)
            {
                myFile.WriteLine(c[i].username + "," + c[i].password);
            }
            myFile.Flush();
            myFile.Close();
        }
        static void ReadLoginCredentials(List<Credentials> c)
        {
            string path = "E:\\Semester2\\OOP\\PD\\Week3\\ManagementSystem\\membersdata.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    string[] data = record.Split(',');
                    Credentials info = new Credentials(data[0], data[1], data[2]);
                    c.Add(info);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Unable to Load Data!!");
                Console.ReadKey();
            }
        }
        static void ReadBooksData(List<BooksData> b)
        {
            string path = "E:\\Semester2\\OOP\\PD\\Week3\\ManagementSystem\\booksdata.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    string[] data = record.Split(',');
                    BooksData temp = new BooksData(int.Parse(data[0]),data[1],data[2],data[3]);
                    b.Add(temp);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Unable to Load Data!!");
                Console.ReadKey();
            }
        }
        static void WriteBooksData(List<BooksData> b)
        {
            string path = "E:\\Semester2\\OOP\\PD\\Week3\\ManagementSystem\\booksdata.txt";
            StreamWriter myFile = new StreamWriter(path);
            for (int i = 0; i < b.Count; i++)
            {
                myFile.WriteLine(b[i].bookID + "," + b[i].bookName + "," + b[i].author + "," + b[i].genre);
            }
            myFile.Flush();
            myFile.Close();
        }
    }
}
