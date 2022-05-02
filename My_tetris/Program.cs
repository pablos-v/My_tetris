My_tetris.Frame frame = new (20, 28);
frame.Draw();

int dice = new Random().Next(1, 8);
My_tetris.Block block = new (dice, frame.wide);
block.Draw();

List<My_tetris.Point> playGround = new();

while (true)
{
    if (block.Fallen(playGround, frame.lineDownPoints))
    {
        // Добавить точки блока в массу на игровом поле
        playGround.AddRange(block.ls);

        // линия - список точек
        // список линий
        //    if (точек в линии == ширине frame.wide) удалить линию, сместить оставшиеся

        // Отрисовываем ещё раз всю массу на поле
        foreach (My_tetris.Point p in playGround) p.Draw();

        // Геймовер
        if (block.BreakingUpLine(frame.upLinePoints)) break;

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

Console.SetCursorPosition(30, 12);
Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine("GAME OVER !!!");
Console.ReadLine();