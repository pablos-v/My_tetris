Console.SetBufferSize(120, 30);

My_tetris.Frame frame = new (20, 28);
frame.Draw();

My_tetris.Block block = new (1, frame.w);
block.Draw();
block.Move();
for (int i = 0; i < 15; i++)
{
    block.Move();
    Thread.Sleep(250);
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