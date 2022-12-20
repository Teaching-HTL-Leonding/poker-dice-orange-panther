Console.OutputEncoding = System.Text.Encoding.Default;

Console.Clear();
Console.ResetColor();
Console.CursorVisible = false; //turns cursor off

const int PADDLE_WIDTH = 10;
const int PADDLE_DISTANCE_FROM_BOTTOM = 3;

int paddlePosX = (Console.WindowWidth - PADDLE_WIDTH) / 2;
int paddlePosY = Console.WindowHeight - PADDLE_DISTANCE_FROM_BOTTOM; // for quick input, first letters of constants

int ballPosX = Console.WindowWidth / 2;
int ballPosY = 0;
int speedVectorX = 1;
int speedVectorY = 1;

while (true) //infinity - loop; does not have an end
{
    Console.SetCursorPosition(0, paddlePosY);
    for (var i = 0; i < Console.WindowWidth; i++)
    {
        if (i >= paddlePosX && i <= paddlePosX + PADDLE_WIDTH)
        {
            Console.Write("=");
        }
        else 
        {
            Console.Write(" ");
        }
    }

    Console.SetCursorPosition(ballPosX, ballPosY);
    Console.Write(" ");

    ballPosX += speedVectorX;
    ballPosY += speedVectorY;

    if (ballPosY == Console.WindowHeight - 1)
    {
        speedVectorY *= -1;
    }

    Console.SetCursorPosition(ballPosX, ballPosY);
    Console.Write("Ü");

    Thread.Sleep(250); // for faster movement use smaller values of milliseconds

    if (Console.KeyAvailable) // KeyAvailable is true when key is pressed
    {
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.LeftArrow: paddlePosX--; break;
            case ConsoleKey.RightArrow: paddlePosX++; break;
        }
    }
}