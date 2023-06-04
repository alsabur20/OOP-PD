using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    class Program
    {
        class Menu
        {
            public List<int> screens = new List<int>();
            public int count;
            public List<int> distinctElements = new List<int>();
            public Menu(List<int> screens)
            {
                count = 0;
                this.screens = screens;
                this.screens = this.screens.Distinct().ToList();
                this.screens.Sort();
            }
            public void to_the_right()
            {
                if (count == screens.Count - 1)
                {
                    count = 0;
                }
                else
                {
                    count++;
                }
            }
            public string display()
            {
                string temp = "";
                for (int i = 0; i < screens.Count; i++)
                {
                    if (count == i)
                    {
                        temp += "[" + screens[i] + "], ";
                    }
                    else
                    {
                        temp += screens[i] + ", ";
                    }
                }
                return temp;
            }

        }
        static void Main(string[] args)
        {
            int size;
            size = int.Parse(Console.ReadLine());
            List<int> screens = new List<int>();
            for (int i = 0; i < size; i++)
            {
                screens.Add(int.Parse(Console.ReadLine()));
            }
            Menu menu = new Menu(screens);
            int times = int.Parse(Console.ReadLine());
            for (int i = 0; i < times; i++)
            {
                menu.to_the_right();
            }
            Console.WriteLine(menu.display());
            Console.ReadKey();
        }
    }
}
