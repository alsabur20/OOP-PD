using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.BL
{
    class Book
    {
        public int bookID;
        public string bookName;
        public string author;
        public string genre;
        public bool isIssued;
        public string issuer;

        public void IssueBook(string name)
        {
            this.isIssued = true;
            this.issuer = name;
        }
        public void ReturnBook()
        {
            this.isIssued = false;
            this.issuer = "";
        }
        public Book(int bookID, string bookName, string author, string genre)
        {
            this.bookID = bookID;
            this.bookName = bookName;
            this.author = author;
            this.genre = genre;
            this.isIssued = false;
            this.issuer = "";
        }
        public Book(int bookID, string bookName, string author, string genre, bool isIssued,string issuer)
        {
            this.bookID = bookID;
            this.bookName = bookName;
            this.author = author;
            this.genre = genre;
            this.isIssued = isIssued;
            this.issuer = issuer;
        }
        public void ModifyBook(string name)
        {
            this.author = name;
        }

        public string ViewBook()
        {
            string book = this.bookID.ToString().PadRight(10) + this.bookName.PadRight(20) + this.author.PadRight(20) + this.genre.PadRight(20);
            if (this.isIssued == true)
            {
                book += "Issued".PadRight(20);
            }
            else
            {
                book += "Not Issued".PadRight(20);
            }
            book += issuer.PadRight(20);
            return book;
        }

    }
}
