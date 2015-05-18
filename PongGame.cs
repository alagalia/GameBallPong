using System;
using System.Collections.Generic;
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
    static char player2Char = '|';
    static int player1Score = 0;
    static int player2Score = 0;
    static Random randomNum = new Random();
    private static int difficulty = 0; // will be used as percents

    static void Main()
    {
        ChooseDifficulty();
        RemoveScrollBars();
        SetStartPositions();
        PrintResult(); //print start score 0-0
        while (true)
        {
            Console.Clear();
            DrawPlayer1();
            DrawPlayer2();
            DrawBall();
            MoveAI(difficulty); //MovePlayer2(); - AI 
            //MoveBall();
            //ReDrawConsole();
            Thread.Sleep(60);
        }
    }
    private static void DrawPlayer2() /// принтира 2-ри играч
    {
        for (int i = player2PositionY; i < player2PositionY + player2BatSize; i++)
        {
            PrintObjectAtPosition(0, i, player2Char);
            PrintObjectAtPosition(1, i, player2Char);
        }
    }
    private static void ChooseDifficulty() // трудността
    {
        Console.WriteLine("Please Select how the 2nd player will be controlled:\n(S)uper Easy AI\n(E)asy AI\n(M)edium AI\n(H)ard AI\n(I)mpossible AI\n(2)nd Player");
        HashSet<string> allowed = new HashSet<string> { "S", "s", "E", "e", "M", "m", "H", "h", "I", "i", "2" };
        string input = Console.ReadLine();
        while (!allowed.Contains(input))
        {
            Console.WriteLine("Invalid input, please type the letter/number contained in the brackets next to your desired mode!");
            input = Console.ReadLine();
        }
        switch (input.ToLower())
        {
            case "2": difficulty = 0; break; // 2nd player
            case "s": difficulty = 10; break; // AI 10%
            case "e": difficulty = 30; break; // AI 30%
            case "m": difficulty = 50; break; // AI 50%
            case "h": difficulty = 70; break; // AI 70%
            case "i": difficulty = 90; break; // AI 90%
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

    private static void DrawPlayer1()
    {
        for (int y = player1PositionY; y < player1PositionY + player1BatSize; y++)
        {
            PrintObjectAtPosition(player1X, y, player1Char); //TODO var char
            PrintObjectAtPosition(player1X - 1, y, player1Char); //TODO var char
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
    static void PrintResult()
    {
        Console.SetCursorPosition(Console.WindowWidth / 2 - 2, 0);
        Console.WriteLine("{0} - {1}", player2Score, player1Score);
    }

    private static void MoveBall()
    {
        //TODO: ball movement
        throw new NotImplementedException();
    }

    private static void MovePlayer1()
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
    private static void MoveAI(int difficulty) // движението на AI спрямо трудността
    {
        if (GenerateRandomNumber() <= difficulty && difficulty != 0)
        {
            MoveAIDependOnDifficult();
        }
    }
    //private static void CheckForMovementPlayer2() // може да се сложи и проверка за движението на 1-ви играч в този метод (и да се извика 2 пъти?)
    //{
    //    ConsoleKeyInfo key = Console.ReadKey();
    //    if (key.Key == ConsoleKey.W)
    //    {
    //        MoveSecondPlayerUP();
    //    }
    //    else if (key.Key == ConsoleKey.S)
    //    {
    //        MoveSecondPlayerDown();
    //    }
    //}
    private static void MoveAIDependOnDifficult() // движението на играч 2 (AI) спрямо топката
    {
        if (ballMovingUp) MovePlayer2UP();
        else MovePlayer2DOWN();
    }

    private static int GenerateRandomNumber() // генерира рандом номер спрямо трудността
    {
        Random getRandomNumber = new Random();
        int generatedNumber = getRandomNumber.Next(1, 101);
        return generatedNumber;
    }

    private static void MovePlayer2UP() // играч 2 нагоре
    {
        if (player2PositionY > 0) player2PositionY--;
    }

    private static void MovePlayer2DOWN() // играч 2 надолу
    {
        if (player2PositionY < Console.WindowHeight - player2BatSize) player2PositionY++;
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
