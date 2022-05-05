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
        public int wide;
        public int high;
        public List<Point> lineDownPoints;
        public List<Point> upLinePoints;
        public Frame(int width, int height)
        {
            wallList = new List<Figure>();
            wide = width;
            high = height;
            HorizLine lineUp = new (0, width, 0, '+');
            HorizLine lineDown = new (0, width, height, '+');
            VertLine lineLeft = new (0, 0, height, '|');
            VertLine lineRight = new (width, 0, height, '|');
            lineDownPoints = lineDown.ls;
            upLinePoints = lineUp.ls;
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
