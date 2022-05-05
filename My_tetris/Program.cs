My_tetris.Frame frame = new (21, 28);
frame.Draw();

int dice = new Random().Next(1, 8);
My_tetris.Block block = new (dice, frame.wide);
block.Draw();

// список точек игрового поля
My_tetris.PlayGround playGround = new(frame.high);

while (true)
{
    if (block.Fallen(playGround.pointsList, frame.lineDownPoints))
    {
        // Добавить точки блока на игровое поле
        playGround.AddPoints(block.ls);

        // Убрать заполненные линии
        playGround.CheckFilledLines(frame.wide, frame.high);

        // Отрисовываем ещё раз всю массу на поле
        foreach (List<My_tetris.Point> line in playGround.pointsList)
        {
            foreach (My_tetris.Point p in line) p.Draw();
        }

        // Геймовер
        if (block.BreakingUpLine(frame.upLinePoints))
        {
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
        block.DirectionListener(key.Key, frame.wide, block.form);
    }

    block.Move("down", frame.wide);

    // Скорость падения блоков
    Thread.Sleep(250);
}

playGround.GameOver();