using System;
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
            ls = new();
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
            if (form == 2) // палка
            {
                for (int j = 0; j < 5; j++)
                {
                    Point p = new (width / 2 - 2 + j, 1, '*');
                    ls.Add(p);
                }
            }
            if (form == 3) // L
            {
                for (int j = 1; j < 5; j++)
                {
                    Point p = new(width / 2, j, '*');
                    ls.Add(p);
                }
                Point p1 = new(width / 2 + 1, 4, '*');
                ls.Add(p1);
            }
            if (form == 4) // зеркальная L
            {
                for (int j = 1; j < 5; j++)
                {
                    Point p = new(width / 2, j, '*');
                    ls.Add(p);
                }
                Point p1 = new(width / 2 - 1, 4, '*');
                ls.Add(p1);
            }
            if (form == 5) // зю
            {
                int x = 0;
                for (int i = 1; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Point p = new(width / 2 + j + x, i, '*');
                        ls.Add(p);
                    }
                    x++;
                }
            }
            if (form == 6) // зеркальная зю
            {
                int x = 0;
                for (int i = 1; i < 3; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Point p = new(width / 2 + j - x, i, '*');
                        ls.Add(p);
                    }
                    x++;
                }
            }
        }

        internal bool IsHit(List<Point> playGround, List<Point> lineDownPoints)
        {
            foreach (Point p in ls)
            {
                foreach (Point groundPoint in playGround)
                {
                    if (p.x==groundPoint.x && p.y+1 == groundPoint.y) return true;
                }
                foreach (Point groundPoint in lineDownPoints)
                {
                    if (p.x == groundPoint.x && p.y == groundPoint.y) return true;
                }
            }
            return false;
        }

        internal void Move()
        {
            for (int i = 0; i < ls.Count; i++) // стереть блок
            {
                ls[i].symb = ' ';
                ls[i].Draw();
            }

            for (int i = 0; i < ls.Count; i++) // отрисовать блок ниже
            {
                ls[i].y++;
                ls[i].symb = '*';
                ls[i].Draw();
            }

        }

        //public void DirectionListener(ConsoleKey key)
        //{
        //    if (key == ConsoleKey.LeftArrow) direction = Direction.LEFT;
        //    else if (key == ConsoleKey.RightArrow) direction = Direction.RIGHT;
        //    else if (key == ConsoleKey.UpArrow) direction = Direction.UP;
        //    else if (key == ConsoleKey.DownArrow) direction = Direction.DOWN;
        //}

    }
}
