using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL
{
    class Ninja
    {
        public int xPos;
        public int yPos;
        public Ninja(int xPos,int yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
        }
    }
    class SnakeLeft
    {
        public int xPos;
        public int yPos;
        public SnakeLeft(int xPos, int yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
        }
    }
    class SnakeRight
    {
        public int xPos;
        public int yPos;
        public SnakeRight(int xPos, int yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
        }
    }
}
