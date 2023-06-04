using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS.BL;

namespace MS.UI
{
    class UserUI
    {
        public static string TakeName()
        {
            Console.WriteLine("Enter Student username: ");
            return Console.ReadLine();
        }
        public static User TakeInputWithRole()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Class: ");
            int jamat = int.Parse(Console.ReadLine());
            Console.Write("Enter userame: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter Role: ");
            string role = Console.ReadLine();
            if (name != null && password != null && role != null)
            {
                User c = new User(name,jamat,username, password, role);
                return c;
            }
            return null;
        }
        public static User TakeInputWithoutRole()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            if (name != null && password != null)
            {
                User c = new User(name, password);
                return c;
            }
            return null;
        }
    }
}
