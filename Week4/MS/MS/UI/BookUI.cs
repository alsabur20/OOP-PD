using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS.BL;
using MS.DL;

namespace MS.UI
{
    class BookUI
    {
        public static void PrintSpecificBook(Book book)
        {
            Console.WriteLine("BookId".PadRight(10) + "Books".PadRight(20) + "Authors".PadRight(20) + "Genres".PadRight(20) + "Status".PadRight(20) + "Issuer".PadRight(20));
            Console.WriteLine(book.ViewBook());
        }
        public static void PrintIssuedBooks()
        {
            Console.WriteLine("BookId".PadRight(10) + "Books".PadRight(20) + "Authors".PadRight(20) + "Genres".PadRight(20) + "Status".PadRight(20) + "Issuer".PadRight(20));
            foreach (Book x in BookCRUD.b)
            {
                if (x.isIssued == true)
                {
                    Console.WriteLine(x.ViewBook());
                }
            }
        }
        public static void PrintBooks()
        {
            Console.WriteLine("BookId".PadRight(10) + "Books".PadRight(20) + "Authors".PadRight(20) + "Genres".PadRight(20) + "Status".PadRight(20) + "Issuer".PadRight(20));
            foreach (Book x in BookCRUD.b)
            {
                Console.WriteLine(x.ViewBook());
            }
        }
        public static Book BookInput()
        {
            Console.Write("Enter Book ID: ");
            int bookid = int.Parse(Console.ReadLine());
            Console.Write("Enter Book Name: ");
            string bookname = Console.ReadLine();
            Console.Write("Enter Author Name: ");
            string authorname = Console.ReadLine();
            Console.Write("Enter Book Genre: ");
            string genre = Console.ReadLine();
            return new Book(bookid, bookname, authorname, genre);
        }
        public static int InputBookId()
        {
            Console.Write("Enter Book ID: ");
            return int.Parse(Console.ReadLine());
        }
        public static string InputBookName()
        {
            Console.Write("Enter Book Name: ");
            return Console.ReadLine();
        }
        public static string InputAuthor()
        {
            Console.Write("Enter Author Name: ");
            return Console.ReadLine();
        }
    }
}
