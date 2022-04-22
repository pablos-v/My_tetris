using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_tetris
{
    internal class Frame
    {
        List<Figure> wallList;
        public int w;

        public Frame(int width, int height)
        {
            wallList = new List<Figure>();
            w = width;
            HorizLine lineUp = new (0, width, 0, '-');
            HorizLine lineDown = new (0, width, height, '-');
            VertLine lineLeft = new (0, 0, height, '|');
            VertLine lineRight = new (width, 0, height, '|');
            wallList.Add(lineDown);
            wallList.Add(lineUp);
            wallList.Add(lineLeft);
            wallList.Add(lineRight);
        }
        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
