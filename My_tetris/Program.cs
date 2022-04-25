Console.SetBufferSize(120, 30);

My_tetris.Frame frame = new (20, 28);
frame.Draw();

Random rnd = new();
int dice = rnd.Next(1, 5);

My_tetris.Block block = new (dice, frame.w);
block.Draw();

List<My_tetris.Point> playGround = new();
string direction;

while (true)
{
    //    if (точек в линии == ширине frame.width) удалить линию


    if (block.Fallen(playGround, frame.lineDownPoints))
    {
        if (block.BreakingUpLine(frame.upLinePoints)) break; // Геймовер
        playGround.AddRange(block.ls);
        dice = rnd.Next(1, 5);
        My_tetris.Block block1 = new(dice, frame.w);
        block = block1;
        block.Draw();
    }

    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo key = Console.ReadKey();
        block.DirectionListener(key.Key, frame.w);
    }

    block.Move(direction = "down", frame.w);
    Thread.Sleep(50);

}

Console.SetCursorPosition(30, 12);
Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine("GAME OVER !!!");
Console.ReadLine();