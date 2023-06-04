using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.BL
{
    class User
    {
        public string name;
        public int jamat;
        public string username;
        public string password;
        public string role;
        public Book issuedBook;
        
        public void IssueBook(Book b)
        {
            this.issuedBook = b;

        }
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public User(string name,int jamat,string username, string password, string role)
        {
            this.name = name;
            this.jamat = jamat;
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
}
