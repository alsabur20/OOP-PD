using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS.BL;

namespace MS.DL
{
    class BookCRUD
    {
        public static List<Book> b = new List<Book>();
        public static void AddBook(Book temp)
        {
            b.Add(temp);
        }
        public static void DeleteBook(int index)
        {
            b.RemoveAt(index);
        }
        public static List<Book> SearchBook(string s)
        {
            List<Book> books = new List<Book>();
            string t = "";
            foreach (Book x in b)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    t += x.bookName[i];
                }
                if (t == s)
                {
                    books.Add(x);
                }
                t = "";
            }
            return books;
        }
        public static int ReturnBookIndex(int bookid)
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
        public static Book ReturnBookFromString(string name)
        {
            foreach (Book x in b)
            {
                if (x.bookName == name)
                {
                    return x;
                }
            }
            return null;
        }
        public static bool DoesBookExist(Book temp)
        {
            foreach (Book x in b)
            {
                if (x.bookID == temp.bookID)
                {
                    return true;
                }
            }
            return false;
        }
        public static void ReadBooksData()
        {
            string path = "E:\\Week4\\MS\\booksData.txt";
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    string[] data = record.Split(',');
                    Book temp = new Book(int.Parse(data[0]), data[1], data[2], data[3], bool.Parse(data[4]), data[5]);
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
        public static void WriteBooksData()
        {
            string path = "E:\\Week4\\MS\\booksData.txt";
            StreamWriter myFile = new StreamWriter(path);
            for (int i = 0; i < b.Count; i++)
            {
                myFile.WriteLine(b[i].bookID + "," + b[i].bookName + "," + b[i].author + "," + b[i].genre + "," + b[i].isIssued + "," + b[i].issuer);
            }
            myFile.Flush();
            myFile.Close();
        }
    }
}
