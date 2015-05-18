using System;
using System.Threading;
class PongGame
{
    static int ballX = 0;
    static int ballY = 0;
    static bool ballMovingRight = true;
    static bool ballMovingUp = true;
    static int player1X = Console.WindowWidth - 1;
    static int player1PositionY = 0;
    static int player2X = 0;
    static int player2PositionY = 0;
    static int player1BatSize = 5;
    static char player1Char = '|';
    static int player2BatSize = 5;
    static char player2Char;
    static int player1Score = 0;
    static int player2Score = 0;
    static Random randomNum = new Random();

    static void Main()
    {
        RemoveScrollBars();
        SetStartPositions();
        while (true)
        {
            DrawPlayer1();
            DrawBall();
            //MovePlayer2();
            //MoveBall();
            //ReDrawConsole();
            Console.Clear();
            Thread.Sleep(0);
        }
    }
    static void RemoveScrollBars()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
    }
    private static void SetStartPositions()
    {
        player2PositionY = (Console.WindowHeight - player2BatSize) / 2;
        player1PositionY = (Console.WindowHeight - player1BatSize) / 2;
        PutBallInInitialPosition();
    }
    private static void PutBallInInitialPosition()
    {
        ballX = Console.WindowWidth / 2;
        ballY = Console.WindowHeight / 2;
    }

    private static void DrawBall()
    {
        PrintObjectAtPosition(ballX, ballY, '@');
    }

    private static void DrawPlayer2()
    {
        //TODO:
        throw new NotImplementedException();
    }

    private static void DrawPlayer1()
    {
        for (int y = player1PositionY; y < player1PositionY + player1BatSize; y++)
        {
            PrintObjectAtPosition(player1X, y, player1Char); //TODO var char
        }
    }

    private static void PrintObjectAtPosition(int x, int y, char batSimbol)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(batSimbol);
    }

    private static void ReDrawConsole()
    {
        //TODO: Clear console and draw new position of objects (players and ball)
        throw new NotImplementedException();
    }

    private static void MoveBall()
    {
        //TODO: ball movement
        throw new NotImplementedException();
    }

    private static void MovePlayer2()
    {
        //TODO: implement how to move first palayer
        throw new NotImplementedException();
    }

    private static void MoveFirstPlayer()
    {
        ConsoleKeyInfo whatIsTheKey = Console.ReadKey();
        if (whatIsTheKey.Key == ConsoleKey.UpArrow)
        {
            MovePlayer1UP();
        }
        else
        {
            MovePlayer1DOWN();
        }
    }

    private static void MovePlayer1UP()
    {
        if (player1PositionY > 0)
        {
            player1PositionY--;
        }
    }

    private static void MovePlayer1DOWN()
    {
        if (player1PositionY < Console.WindowHeight - player1BatSize)
        {
            player1PositionY++;
        }
    }
}