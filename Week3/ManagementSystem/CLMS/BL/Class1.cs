using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLMS.BL
{
    class Credentials
    {
        public string username;
        public string password;
        public string role;
        public Credentials(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public Credentials(string username, string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }
        public bool isAdmin()
        {
            if (role == "admin" || role == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class BooksData
    {
        public int bookID;
        public string bookName;
        public string author;
        public string genre;
        public BooksData(int bookID, string bookName, string author, string genre)
        {
            this.bookID = bookID;
            this.bookName = bookName;
            this.author = author;
            this.genre = genre;
        }
    }
}
