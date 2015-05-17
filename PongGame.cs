using System;
class PongGame
{
    //TODO: static variables for the game
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