﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_tetris
{
    internal class Block : Figure
    {
        public Direction direction;
        public Block(int form, int width)
        {
            ls = new List<Point>();
            if (form == 1) // Куб
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 1; j < 3; j++)
                    {
                        Point p = new (width / 2 + i, j, '*');
                        ls.Add(p);
                    }
                }
            }
        }

        internal void Move()
        {
            List<int> yList = new List<int>();
            foreach (Point p in ls) // список всех у-координат блока
            {
                yList.Add(p.y);
            }
            yList.Sort();
            int topRow = yList[0]; // самый высокий ряд блока

            foreach (Point p in ls) // удалить ряд topRow
            {
                if (p.y == topRow)
                {
                    p.Clear();
                }
            }
            for (int i = 0; i < ls.Count; i++) // переместить блок ниже
            {
                ls[i].y++;
                ls[i].symb = '*';
                ls[i].Draw();
            }


            //Point tail = pL.First();
            //pL.Remove(tail);
            //pL.Add(head);
            //tail.Clear();
            //head.Draw();

        }

        //public Point GetNextPoint()
        //{
        //    Point head = pL.Last();
        //    Point nextP = new Point(head);
        //    nextP.Move(1, direction);
        //    return nextP;
        //}

        //public void DirectionListener(ConsoleKey key)
        //{
        //    if (key == ConsoleKey.LeftArrow) direction = Direction.LEFT;
        //    else if (key == ConsoleKey.RightArrow) direction = Direction.RIGHT;
        //    else if (key == ConsoleKey.UpArrow) direction = Direction.UP;
        //    else if (key == ConsoleKey.DownArrow) direction = Direction.DOWN;
        //}

        //internal bool IsHit()
        //{
        //    var head = pL.Last();
        //    for (int i = 0; i < pL.Count - 2; i++)
        //    {
        //        if (head.IsHit(pL[i])) return true;
        //    }
        //    return false;
        //}
    }
}
