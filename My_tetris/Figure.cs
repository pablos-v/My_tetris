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
        public void Delete()
        {
            for (int i = 0; i < ls.Count; i++)
            {
                ls[i].symb = ' ';
                ls[i].Draw();
            }
        }
    }
}
