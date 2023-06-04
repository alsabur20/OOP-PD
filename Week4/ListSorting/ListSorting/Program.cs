using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = new List<string>() 
            { 
                "Sabur",
                "Arsalan",
                "Ansa",
                "Fazeen"
            };
            for(int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(items[i]);
            }
            items.Sort();
            Console.WriteLine("");
            for(int i = 0; i < items.Count; i++)
            {
                Console.Write(items[i]+" ");
            }
            Console.ReadKey();
        }
    }
}
