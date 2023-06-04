using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1.BL;
using P1.DL;

namespace P1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\UET\\Week6\\P1\\Maze.txt";
            Grid x = new Grid(10, 10, path);
            Cell y = new Cell('P', 5, 5);
            Console.WriteLine(x.FindPacman().GetX()+"\t"+ x.FindPacman().GetY());
            Console.ReadKey();
        }
    }
}
