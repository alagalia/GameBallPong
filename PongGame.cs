using System;
class PongGame
{
    static int ballInitialX = Console.WindowWidth / 2;
    static int ballInitialY = Console.WindowHeight / 2;
    static int ballX;
    static int BallY;
    static bool allMovingRight = true;
    static bool allMovingUp = true;
    static int player1InitialX=0;
    static int player1InitialY= (Console.WindowHeight-player1BatSize)/2;
    static int player1X;
    static int player2IntialX=Console.WindowWidth-1;
    static int player2InitialY = (Console.WindowHeight - player2BatSize) / 2;
    static int player2X;
    static int player1BatSize=5;
    static int player2BatSize=5;
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
        Console.WindowHeight = 40;
        Console.WindowWidth = 80;
        Console.ForegroundColor = ConsoleColor.White;
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
    }
    private static void SetInitialPositions()
    {
        //TODO: Set ball and players position before start of the game
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
        //TODO: implement how to move first palayer (AI)
        throw new NotImplementedException();
    }
}