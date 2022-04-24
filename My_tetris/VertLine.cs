using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_tetris
{
    internal class VertLine : Figure
    {
        public VertLine(int x, int yT, int yB, char symb)
        {
            ls = new List<Point>();
            for (int i = yT; i <= yB; i++)
            {
                Point p = new (x, i, symb);
                ls.Add(p);
            }
        }
    }
}
