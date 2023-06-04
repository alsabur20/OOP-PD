using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem1.BL;

namespace Problem1.DL
{
    class GridCRUD
    {
        public static void LoadMaze(string path, Cell[,] maze)
        {
            if (File.Exists(path))
            {
                char temp;
                int row = 0;
                int col = 0;
                StreamReader stage = new StreamReader(path);
                do
                {
                    temp = (char)stage.Read();
                    if (temp == '\r') continue;
                    if (temp == '\n')
                    {
                        row++;
                        col = 0;
                    }
                    else
                    {
                        Cell x = new Cell(temp, col, row);
                        maze[row, col] = x;
                        col++;
                    }
                }
                while (!stage.EndOfStream);
                stage.Close();
            }
        }
    }
}
