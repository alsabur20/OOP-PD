using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Problem1.BL;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\UET\\Week6\\Problem1\\Maze.txt";
            Grid gridMaze = new Grid(10, 10, path);
            Ghost g1 = new Ghost(5, 5, "left", 'H', 0.1F, ' ', gridMaze);
           // Ghost g2 = new Ghost(4, 7, "up", 'V', 0.1F, ' ', gridMaze);
            List<Ghost> enemies = new List<Ghost>();
            enemies.Add(g1);
            //enemies.Add(g2);

            gridMaze.Draw();

            bool gameRunning = true;

            while (gameRunning)
            {
                Thread.Sleep(30);
                foreach(Ghost g in enemies)
                {
                    g.Remove();
                    g.Move();
                    g.Draw();
                }
            }
            Console.ReadKey();
        }
    }
}
