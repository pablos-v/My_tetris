Console.SetBufferSize(120, 30);

My_tetris.Frame frame = new (20, 28);
frame.Draw();

Random rnd = new();
int dice = rnd.Next(1, 5);

My_tetris.Block block = new (dice, frame.w);
block.Draw();

List<My_tetris.Point> playGround = new();

while (true)
{
    if (block.IsHit(playGround, frame.lineDownPoints))
    {
        playGround.AddRange(block.ls);
        dice = rnd.Next(1, 5);
        My_tetris.Block block1 = new(dice, frame.w);
        block = block1;
        block.Draw();
    }
    block.Move();
    Thread.Sleep(100);
}


//while (true)
//{
//    if (block.IsHit()) добавить все точки в список, создать блок, нарисовать блок
//    if (точек в линии == ширине frame.width) удалить линию
//    if (GameOver()) break;
//    block.Move();

//    Thread.Sleep(250);

//    if (Console.KeyAvailable)
//    {
//        ConsoleKeyInfo key = Console.ReadKey();
//        block.DirectionListener(key.Key); в классе блок метод Rotate() или Strafe() смотря от кнопки
//    }




Console.ReadLine();