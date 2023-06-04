using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.BL
{
    class Cell
    {
        public char value;
        public int x;
        public int y;
        public Cell(char value, int x, int y)
        {
            this.value = value;
            this.x = x;
            this.y = y;
        }
        public char GetValue()
        {
            return value;
        }
        public void SetValue(char value)
        {
            this.value = value;
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        public bool IsPacmanPresent()
        {
            if (this.value == 'P')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsGhostPresent(char Ghost)
        {
            if (this.value == Ghost)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
