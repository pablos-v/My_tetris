My_tetris.Frame frame = new (21, 28);
frame.Draw();

int dice = new Random().Next(1, 8);
My_tetris.Block block = new (dice, frame.wide);
block.Draw();

int score = 1;

// список линий игрового поля
List<List<My_tetris.Point>> playGround = new();

for (int i = 0; i <= frame.high; i++)
{
    playGround.Add(new List<My_tetris.Point>());
}

while (true)
{
    if (block.Fallen(playGround, frame.lineDownPoints))
    {
        // Добавить точки блока на игровое поле
        foreach (My_tetris.Point p in block.ls)
        {
            playGround[p.y].Add(p);
        }

        // Убрать заполненные линии
        for (int i = 0; i <= frame.high; i++)
        {
            if (playGround[i].Count == frame.wide - 1)
            {
                DeleteLine(i, playGround);
                score += frame.wide - 1;
            }
        }

        // Отрисовываем ещё раз всю массу на поле
        foreach (List<My_tetris.Point> line in playGround)
        {
            foreach (My_tetris.Point p in line) p.Draw();
        }

        // Геймовер
        if (block.BreakingUpLine(frame.upLinePoints))
        {
            foreach (List<My_tetris.Point> ls in playGround)
            {
                score += ls.Count();
            }
            break;
        }

        // Новый блок
        dice = new Random().Next(1, 8);
        My_tetris.Block block1 = new(dice, frame.wide);
        block = block1;
        block.Draw();
    }

    // Перемещения стрелочками
    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo key = Console.ReadKey();
        block.DirectionListener(key.Key, frame.wide, block.f);
    }

    block.Move("down", frame.wide);

    // Скорость падения блоков
    Thread.Sleep(250);
}

void DeleteLine(int line, List<List<My_tetris.Point>> playGround)
{
    // убрать все точки линии с поля
    foreach (My_tetris.Point p in playGround[line])
    {
        p.Clear();
        Thread.Sleep(10);
    }
    playGround[line].Clear();

    // все точки что выше = у++ и перенести на линию ниже
    for (int i = line; i >= 1; i--)
    {
        playGround[i].Clear();
        playGround[i].AddRange(playGround[i-1]);

        foreach (My_tetris.Point p in playGround[i])
        {
            p.Clear();
            p.y++;
            p.symb = '*';
            p.Draw();
        }
    }
}

Console.SetCursorPosition(30, 12);
Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine("GAME OVER !!!");
Console.SetCursorPosition(29, 13);
Console.WriteLine($"your score: {score}");
Console.ReadLine();