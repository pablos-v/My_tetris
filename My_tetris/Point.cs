using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_tetris
{
    internal class Point
    {
        public int x;
        public int y;
        public char symb;

        public Point() //Конструктор 1
        {
        }
        public Point(int _x, int _y, char _symb) //Конструктор 2
        {
            x = _x;
            y = _y;
            symb = _symb;
        }

        public Point(Point p) //Конструктор 3
        {
            x = p.x;
            y = p.y;
            symb = p.symb;
        }

        public bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }

        //public void Move(int offset, Direction direction)
        //{
        //    if (direction == Direction.LEFT)
        //    {
        //        x -= offset;
        //    }
        //    else if (direction == Direction.RIGHT)
        //    {
        //        x += offset;
        //    }
        //    else if (direction == Direction.UP)
        //    {
        //        y -= offset;
        //    }
        //    else if (direction == Direction.DOWN)
        //    {
        //        y += offset;
        //    }
        //}
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symb);
        }

        public void Clear()
        {
            symb = ' ';
            Draw();
        }
    }
}
