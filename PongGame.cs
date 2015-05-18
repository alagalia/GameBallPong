using System;
class PongGame
{
    static int ballInitialX = Console.WindowWidth / 2;
    static int ballInitialY = Console.WindowHeight / 2;
    static int ballX;
    static int BallY;
    static bool allMovingRight = true;
    static bool allMovingUp = true;
    static int player1InitialX = 0;
    static int player1InitialY = (Console.WindowHeight - player1BatSize) / 2;
    static int player1Position;
    static int player2IntialX = Console.WindowWidth - 1;
    static int player2InitialY = (Console.WindowHeight - player2BatSize) / 2;
    static int player2Position;
    static int player1BatSize = 5;
    static int player2BatSize = 5;
    static int player1Score = 0;
    static int player2Score = 0;
    static Random randomNum = new Random();


    static void Main()
    {
        RemoveScrollBars();
        while (true)
        {
            SetInitialPositions();
            MoveFirstPlayer();
            MoveSecondPlayer();
            MoveBall();
            ReDrawConsole();
        }
    }
    static void RemoveScrollBars()
    {
        //Console.WindowHeight = 40;
        //Console.WindowWidth = 80;
        Console.ForegroundColor = ConsoleColor.White;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
    }
    private static void SetInitialPositions()
    {
        //TODO: Set ball and players position before start of the game and draw them
        DrawPlayer1();
        DrawPlayer2();
        DrawBall();
    }

    private static void DrawBall()
    {
        throw new NotImplementedException();
    }

    private static void DrawPlayer2()
    {
        throw new NotImplementedException();
    }

    private static void DrawPlayer1()
    {
        throw new NotImplementedException();
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

    private static void MoveSecondPlayer()
    {
        //TODO: implement how to move first palayer
        throw new NotImplementedException();
    }

    private static void MoveFirstPlayer()
    {
        if (Console.KeyAvailable)
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
    }

    private static void MovePlayer1UP()
    {
        if (player1Position > 0)
        {
            player1Position--;
        }
    }

    private static void MovePlayer1DOWN()
    {
        if (player1Position < Console.WindowHeight - player1BatSize)
        {
            player1Position++;
        }
    }
}