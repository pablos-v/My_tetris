using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_tetris
{
    internal class Figure
    {
        public List<Point> ls;
        public void Draw()
        {
            foreach (Point i in ls)
            {
                i.Draw();
            }
        }
    }
}
