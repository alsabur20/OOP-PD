using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS.BL;

namespace MS.DL
{
    class UserCRUD
    {
        public static List<User> c = new List<User>();
        public static User ReturnUser(string name)
        {
            foreach (User x in c)
            {
                if (x.username == name)
                {
                    return x;
                }
            }
            return null;
        }
        public static User ReturnUserFromList(User temp)
        {
            foreach (User x in c)
            {
                if (temp.username == x.username && temp.password == x.password)
                {
                    return x;
                }
            }
            return null;
        }
        public static void AddUser(User temp)
        {
            c.Add(temp);
        }
        public static bool DoesUserExist(User temp)
        {
            foreach (User x in c)
            {
                if (x.username == temp.username)
                {
                    return true;
                }
            }
            return false;
        }
        public static void ReadLoginCredentials()
        {
            string path = "E:\\Week4\\MS\\membersdata.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    string[] data = record.Split(',');
                    User info = new User(data[0], int.Parse(data[1]), data[2], data[3], data[4]);
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
        public static void WriteCredentials()
        {
            string path = "E:\\Week4\\MS\\membersdata.txt";
            StreamWriter myFile = new StreamWriter(path);
            for (int i = 0; i < c.Count; i++)
            {
                myFile.WriteLine(c[i].name + "," + c[i].jamat + "," + c[i].username + "," + c[i].password + "," + c[i].role);
            }
            myFile.Flush();
            myFile.Close();
        }
    }
}
