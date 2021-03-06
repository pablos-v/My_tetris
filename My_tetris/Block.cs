using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_tetris
{
    internal class Block : Figure
    {
        public int form;
        //public Direction direction;
        public Block(int type, int width)
        {
            form = type;
            ls = new();
            int centre = width / 2;
            if (type == 1) // Куб
            {
                CubeMaker(width);
            }
            if (type == 2) // палка
            {
                for (int j = 0; j < 5; j++)
                {
                    Point p = new (centre - 2 + j, 1, '*');
                    ls.Add(p);
                }
            }
            if (type == 3) // L
            {
                for (int j = 1; j < 5; j++)
                {
                    Point p = new(centre, j, '*');
                    ls.Add(p);
                }
                Point p1 = new(centre + 1, 4, '*');
                ls.Add(p1);
            }
            if (type == 4) // зеркальная L
            {
                for (int j = 1; j < 5; j++)
                {
                    Point p = new(centre, j, '*');
                    ls.Add(p);
                }
                Point p1 = new(centre - 1, 4, '*');
                ls.Add(p1);
            }
            if (type == 5) // зю
            {
                CubeMaker(width);
                ls[2].x -= 2;
            }
            if (type == 6) // зеркальная зю
            {
                CubeMaker(width);
                ls[3].x -= 2;
            }
            if (type == 7) // T
            {
                CubeMaker(width);
                ls[1].x += 2;
                ls[1].y -= 1;
            }
        }

        private void CubeMaker(int width)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    Point p = new(width / 2 + i, j, '*');
                    ls.Add(p);
                }
            }
        }

        internal bool BreakingUpLine(List<Point> UpLinePoints)
        {
            foreach (Point p in ls)
            {
                foreach (Point l in UpLinePoints)
                {
                  if (p.y == l.y+2) return true;
                }
            }
            return false;
        }

        internal bool Fallen(List<List<Point>> playGround, List<Point> lineDownPoints)
        {
            foreach (Point p in ls)
            {
                foreach (List<Point> line in playGround)
                {
                    foreach (Point groundPoint in line)
                    {
                        if (p.x==groundPoint.x && p.y+1 == groundPoint.y) return true;
                    }
                }
                foreach (Point groundPoint in lineDownPoints)
                {
                    if (p.y+1 == groundPoint.y) return true;
                }
            }
            return false;
        }

        internal void Move(string direction, int w)
        {
             if (direction == "down")
            {
                Delete();
                for (int i = 0; i < ls.Count; i++) // отрисовать блок ниже
                {
                    ls[i].y++;
                    ls[i].symb = '*';
                    ls[i].Draw();
                }
            }

            if (direction == "left")
            {
                foreach (Point p in ls) // проверить на границу
                {
                    if (p.x == w - 1 || p.x == 1) return;
                }
                Delete();
                for (int i = 0; i < ls.Count; i++) // отрисовать блок левее
                {
                    ls[i].x--;
                    ls[i].symb = '*';
                    ls[i].Draw();
                }
            }

            if (direction == "right")
            {
                foreach (Point p in ls) // проверить на границу
                {
                    if (p.x == w - 1 || p.x == 1) return;
                }
                Delete();
                for (int i = 0; i < ls.Count; i++) // отрисовать блок правее
                {
                    ls[i].x++;
                    ls[i].symb = '*';
                    ls[i].Draw();
                }
            }
        }
        // решил прокинуть границу правой стороны рамки для проверки границы в методе Move(),
        // получилось корявоо, это костыль. Но я пока не знаю как лучше.
        // с кодом проверки тоже косяк - он написан дважды, тоже не знаю как улучшить.
        public void DirectionListener(ConsoleKey key, int w, int type) 
        {
            if (key == ConsoleKey.LeftArrow)
            {
                Move("left", w);
            }
            else if (key == ConsoleKey.RightArrow)
            {
                Move("right", w);
            }
            else if (key == ConsoleKey.UpArrow)
            {
                Rotate("clockwize", type);
            }
            else if (key == ConsoleKey.DownArrow)
            {
                Rotate("backward", type);
            }
        }

        private void Rotate(string side, int type)
        {
            // куб не крутится
            if (type == 1) return;

            int degrees = side == "clockwize" ? 90 : 270;
            double angle = Math.PI * degrees / 180.0;

            // опорная точка
            Point zero;

            if (type == 5 || type == 6) zero = ls[1];

            else zero = ls[2];

            Delete();
            for (int i = 0; i < ls.Count; i++)
            {
                int offsetX = ls[i].x - zero.x;
                int offsetY = ls[i].y - zero.y;
                ls[i].x = (int)(offsetX * Math.Cos(angle) - offsetY * Math.Sin(angle) + zero.x);
                ls[i].y = (int)(offsetX * Math.Sin(angle) + offsetY * Math.Cos(angle) + zero.y);
                ls[i].symb = '*';
                ls[i].Draw();
            }
        }
    }
}
