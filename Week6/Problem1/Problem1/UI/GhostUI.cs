using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1.UI
{
    class GhostUI
    {
        public static void Remove(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        public static void Draw(char c, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }
    }
}
