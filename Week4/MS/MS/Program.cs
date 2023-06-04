using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS.BL;
using MS.DL;
using MS.UI;


namespace MS
{
    class Program
    {
        static User currentUser;
        static void Main(string[] args)
        {
            UserCRUD.ReadLoginCredentials();
            BookCRUD.ReadBooksData();
            char option;
            do
            {
                Console.Clear();
                option = Menu();
                User temp;
                if (option == '1')
                {
                    temp = UserUI.TakeInputWithRole();
                    if (temp != null)
                    {
                        if (!(UserCRUD.DoesUserExist(temp)))
                        {
                            UserCRUD.AddUser(temp);
                            UserCRUD.WriteCredentials();
                            Console.WriteLine("Signed UP successfully");
                            Console.Write("Press any key to continue..");
                        }
                        else
                        {
                            Console.WriteLine("User Already Exists!!!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter Correct Input!!");
                    }
                    Console.ReadKey();
                }
                else if (option == '2')
                {
                    Console.Clear();
                    temp = UserUI.TakeInputWithoutRole();
                    if (temp != null)
                    {
                        temp = UserCRUD.ReturnUserFromList(temp);
                        if (temp == null)
                        {
                            Console.WriteLine("Invalid User");
                        }
                        else if (temp.isAdmin())
                        {
                            currentUser = temp;
                            AdminHandler();
                        }
                        else
                        {
                            currentUser = temp;
                            StudentHandler();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter Correct Input!!");
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
        static void AdminHandler()
        {
            int option;
            do
            {
                Console.Clear();
                option = AdminMenu();
                if (option == 1)
                {
                    Console.Clear();
                    Book temp = BookUI.BookInput();
                    if (!(BookCRUD.DoesBookExist(temp)))
                    {
                        BookCRUD.AddBook(temp);
                        BookCRUD.WriteBooksData();
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
                    Console.Clear();
                    int index = BookCRUD.ReturnBookIndex(BookUI.InputBookId());
                    if (index != -1)
                    {
                        BookCRUD.DeleteBook(index);
                        BookCRUD.WriteBooksData();
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
                    Console.Clear();
                    int index = BookCRUD.ReturnBookIndex(BookUI.InputBookId());
                    if (index != -1)
                    {
                        BookCRUD.b[index].ModifyBook(BookUI.InputAuthor());
                        BookCRUD.WriteBooksData();
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
                    if (BookCRUD.b.Count != 0)
                    {
                        BookUI.PrintBooks();
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("No Books Found!!");
                        Console.WriteLine("Add Books First!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else if (option == 5)
                {
                    Console.Clear();
                    if (BookCRUD.b.Count != 0)
                    {
                        BookUI.PrintIssuedBooks();
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("No Books Found!!");
                        Console.WriteLine("Add Books First!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else if (option == 6)
                {
                    Console.Clear();
                    int index = BookCRUD.ReturnBookIndex(BookUI.InputBookId());
                    if (index != -1 && BookCRUD.b[index].isIssued == false)
                    {
                        string name = UserUI.TakeName();
                        UserCRUD.ReturnUser(name).IssueBook(BookCRUD.b[index]);
                        BookCRUD.b[index].IssueBook(name);
                        BookCRUD.WriteBooksData();
                        Console.WriteLine("Book Issued Successfully!!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Book Unavailable!!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else if (option == 7)
                {
                    Console.Clear();
                    int index = BookCRUD.ReturnBookIndex(BookUI.InputBookId());
                    if (index != -1 && BookCRUD.b[index].isIssued == true)
                    {
                        BookCRUD.b[index].ReturnBook();
                        BookCRUD.WriteBooksData();
                        Console.WriteLine("Book Returned Successfully!!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Book Unavailable!!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else if (option == 8)
                {
                    break;
                }
                else if (option > 8)
                {
                    Console.WriteLine("Invalid Choice!!");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            while (option != 8);
        }
        static int AdminMenu()
        {
            int option;
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Delete Book");
            Console.WriteLine("3. Modify Book");
            Console.WriteLine("4. View Books");
            Console.WriteLine("5. View Issued Books");
            Console.WriteLine("6. Issue Book");
            Console.WriteLine("7. Return Book");
            Console.WriteLine("8. Logout");
            Console.Write("Enter Choice: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static int StudentMenu()
        {
            int option;
            Console.WriteLine("1. Search Book");
            Console.WriteLine("2. View Books");
            Console.WriteLine("3. Check Status of a Book");
            Console.WriteLine("4. Issue Book");
            Console.WriteLine("5. Return Book");
            Console.WriteLine("6. My Books");
            Console.WriteLine("7. Logout");
            Console.Write("Enter Choice: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static void StudentHandler()
        {
            int option;
            do
            {
                Console.Clear();
                option = StudentMenu();
                if (option == 1)
                {
                    Console.Clear();
                    foreach (Book x in BookCRUD.SearchBook("a"))
                    {
                        Console.WriteLine(x.bookName + "\t");
                    }
                    //BookUI.PrintSpecificBook(BookCRUD.ReturnBookFromString(BookUI.InputBookName()));
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (option == 2)
                {

                    Console.Clear();
                    if (BookCRUD.b.Count != 0)
                    {
                        BookUI.PrintBooks();
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("No Books Found!!");
                        Console.WriteLine("Add Books First!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else if (option == 3)
                {
                    Console.Clear();
                    int id = BookUI.InputBookId();
                    if (BookCRUD.b[BookCRUD.ReturnBookIndex(id)].isIssued == true)
                    {
                        Console.WriteLine("Book is Issued!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Book is UnIssued!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else if (option == 4)
                {
                    Console.Clear();
                    int id = BookUI.InputBookId();
                    Book temp = BookCRUD.b[BookCRUD.ReturnBookIndex(id)];
                    if (BookCRUD.DoesBookExist(temp))
                    {
                        if (!(temp.isIssued))
                        {
                            temp.IssueBook(currentUser.name);
                            BookCRUD.WriteBooksData();
                            Console.WriteLine("Book Issued Successfully!!!");
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Book already issued!!");
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Book does not exist!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else if (option == 5)
                {
                    Console.Clear();
                    int id = BookUI.InputBookId();
                    Book temp = BookCRUD.b[BookCRUD.ReturnBookIndex(id)];
                    if (temp.isIssued && temp.issuer == currentUser.name)
                    {
                        temp.ReturnBook();
                        BookCRUD.WriteBooksData();
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Unable to return book!!");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else if (option == 6)
                {
                    int counter = 0;
                    Console.Clear();
                    foreach (Book x in BookCRUD.b)
                    {
                        if (x.issuer == currentUser.name)
                        {
                            Console.WriteLine("BookId".PadRight(10) + "Books".PadRight(20) + "Authors".PadRight(20) + "Genres".PadRight(20) + "Status".PadRight(20) + "Issuer".PadRight(20));
                            Console.WriteLine(x.ViewBook());
                            counter++;
                        }
                    }
                    if (counter == 0)
                    {
                        Console.WriteLine("No Issued Books!!!");
                    }
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (option == 7)
                {
                    break;
                }
                else if (option > 7)
                {
                    Console.WriteLine("Invalid Choice!!");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            while (option != 7);
        }
    }
}

