using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_tetris
{
    internal class PlayGround
    {
        public List<List<Point>> pointsList;
        public int score;
        public PlayGround(int hight)
        {
            pointsList = new();
            for (int i = 0; i <= hight; i++)
            {
                pointsList.Add(new List<Point>());
            }
        }

        internal void CheckFilledLines(int wide, int high)
        {
            for (int i = 0; i <= high; i++)
            {
                if (pointsList[i].Count == wide - 1)
                {
                    DeleteLine(i);
                    score += wide - 1;
                }
            }
        }

        void DeleteLine(int line)
        {
            // убрать все точки линии с поля
            foreach (Point p in pointsList[line])
            {
                p.Clear();
                Thread.Sleep(10);
            }
            pointsList[line].Clear();

            // все точки что выше = у++ и перенести на линию ниже
            for (int i = line; i >= 1; i--)
            {
                pointsList[i].Clear();
                pointsList[i].AddRange(pointsList[i - 1]);

                foreach (Point p in pointsList[i])
                {
                    p.Clear();
                    p.y++;
                    p.symb = '*';
                    p.Draw();
                }
            }
        }

        internal void GameOver()
        {
            foreach (List<Point> ls in pointsList)
            {
                score += ls.Count;
            }
            Console.SetCursorPosition(30, 12);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("GAME OVER !!!");
            Console.SetCursorPosition(29, 13);
            Console.WriteLine($"your score: {score}");
            Console.ReadLine();
        }

        internal void AddPoints(List<Point> ls)
        {
            foreach (Point p in ls)
            {
                pointsList[p.y].Add(p);
            }
        }
    }
}
