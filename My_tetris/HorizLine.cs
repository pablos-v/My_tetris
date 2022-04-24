using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_tetris
{
    internal class HorizLine : Figure
    {
        public HorizLine(int xL, int xR, int y, char symb)
        {
            ls = new List<Point>();
            for (int i = xL; i <= xR; i++)
            {
                Point p = new (i, y, symb);
                ls.Add(p);
            }
        }
    }
}
