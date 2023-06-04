using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1.DL;
using P1.UI;

namespace P1.BL
{
    class Grid
    {
        public Cell[,] maze;
        public int rowSize;
        public int colSize;
        public Grid(int rowSize, int colSize, string path)
        {
            this.rowSize = rowSize;
            this.colSize = colSize;
            maze = new Cell[rowSize, colSize];
            GridCRUD.LoadMaze(path, this.maze);
        }
        public Cell GetLeftCell(Cell c)
        {
            return maze[c.GetY(), c.GetX() - 1];
        }
        public Cell GetRightCell(Cell c)
        {
            return maze[c.GetY(), c.GetX() + 1];
        }
        public Cell GetUpCell(Cell c)
        {
            return maze[c.GetY() - 1, c.GetX()];
        }
        public Cell GetDownCell(Cell c)
        {
            return maze[c.GetY() + 1, c.GetX()];
        }
        public Cell FindPacman()
        {
            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize; col++)
                {
                    if (maze[row, col].GetValue() == 'P')
                    {
                        return maze[row, col];
                    }
                }
            }
            return null;
        }
        public Cell FindGhost(char GhostCharacter)
        {
            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize; col++)
                {
                    if (maze[row, col].GetValue() == GhostCharacter)
                    {
                        return maze[row, col];
                    }
                }
            }
            return null;
        }
       /* public bool IsStoppingCondition()
        {
            if ()
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/
        public void Draw()
        {
            GridUI.PrintGrid(maze);
        }
    }
}
