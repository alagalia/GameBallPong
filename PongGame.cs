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
    static int player1BatSize = 15;
    static char player1Char = '|';
    static int player2BatSize = 5;
    static char player2Char = '|';
    static int player1Score = 0;
    static int player2Score = 0;
    static Random randomNum = new Random();
    static int difficulty = 0; // will be used as percents
    static string namePlayer1 = "Pesho";
    static string namePlayer2 = "Gosho";
    static bool ballSpeed = true;
    static bool brickIsSpawned = false;
    static int brickTurnCounter = 0;
    static int turnsToStay = 200;
    static int brickPositionX = 0;
    static int brickPositionY = 0;

    static void Main()
    {
        ChooseDifficulty();
        RemoveScrollBars();
        SetStartPositions();
        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo whatIsTheKey = Console.ReadKey();
                if (whatIsTheKey.Key == ConsoleKey.UpArrow)
                {
                    MovePlayer1UP();
                }
                if (whatIsTheKey.Key == ConsoleKey.DownArrow)
                {
                    MovePlayer1DOWN();
                }
            }
            if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pause = Console.ReadKey();
                    if (pause.Key == ConsoleKey.P && pause.Modifiers == ConsoleModifiers.Control)
                    {
                        PauseGame();
                    }
                }
            Console.Clear();
            HoldObstacleFor();
            DrawPlayer1();
            DrawPlayer2();
            DrawBall();
            MoveAI(difficulty); //MovePlayer2(); - AI 
            if (ballSpeed)//забавя топката наполовина, прескача цикъл
            {
                MoveBall();
            }
            ballSpeed = !ballSpeed;
            PrintResult(); //print start score 0-0
            Thread.Sleep(40);
        }
    }
    static void PauseGame()  
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 2);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
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

    static void PrintResult()
    {
        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 0);
        Console.WriteLine("{0} {1} - {2} {3}", namePlayer2, player2Score, player1Score, namePlayer1);
    }

    private static void MoveBall()
    {
        {
            if (ballY == 0)
            {
                ballMovingUp = false;
            }
            if (ballY == Console.WindowHeight - 1)
            {
                ballMovingUp = true;
            }
            //проверка дали десният играч изпуска топката
            if (ballX == Console.WindowWidth - 1)
            {
                PutBallInInitialPosition();
                ballMovingRight = false;
                ballMovingUp = true;
                player2Score++;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2);
                Console.WriteLine("{0} wins!", namePlayer2);
                Console.ReadKey();
            }

            //Проверка дали левият играч изпуска топката
            if (ballX == 0)
            {
                PutBallInInitialPosition();
                ballMovingRight = true;
                ballMovingUp = false;
                player1Score++;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2);
                Console.WriteLine("{0} wins!", namePlayer1);
                Console.ReadKey();
            }

            //проверка дали удря в препятствие
            if ((ballX == brickPositionX - 1 && ballY >= brickPositionY && ballY < brickPositionY + 4) ||
                (ballX == brickPositionX + 1 && ballY >= brickPositionY && ballY < brickPositionY + 4))
            {
                ballMovingRight = !ballMovingRight;
                ballMovingUp = !ballMovingUp;
            }

            //проверка дали удря хилката в ляво
            if (ballX < 3)
            {
                if (ballY >= player2PositionY
                    && ballY < player2PositionY + player2BatSize)
                {
                    ballMovingRight = true;
                }
            }

            //проверка дали удря хилката в дясно
            if (ballX >= Console.WindowWidth - 3 - 1)
            {
                if (ballY >= player1PositionY
                    && ballY < player1PositionY + player1BatSize)
                {
                    ballMovingRight = false;
                }
            }

            if (ballMovingUp)
            {
                ballY--;
            }
            else
            {
                ballY++;
            }


            if (ballMovingRight)
            {
                ballX++;
            }
            else
            {
                ballX--;
            }
        }
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
    private static void ShowBricks()
    {
        Random rnd = new Random();
        int timeWhenBrickShow = rnd.Next(0, 5000);
        brickPositionX = rnd.Next(10, Console.WindowWidth - 10);
        brickPositionY = rnd.Next(3, Console.WindowHeight - 3);
        if (timeWhenBrickShow < 4950)
        {
            DrawBrick(brickPositionX, brickPositionY);
            brickIsSpawned = true;
        }
    }
    private static void DrawBrick(int brickX, int brickY)
    {
        Console.SetCursorPosition(brickX, brickY);
        for (int i = brickY; i < brickY + 4; i++)
        {
            PrintObjectAtPosition(brickX, i, '*');
        }
    }
    private static void HoldObstacleFor()
    {
        if (brickIsSpawned && brickTurnCounter <= turnsToStay)
        {
            DrawBrick(brickPositionX, brickPositionY);
            brickTurnCounter++;
        }
        else
        {
            brickTurnCounter = 0;
            brickIsSpawned = false;
            ShowBricks();//Метод за препятствията
        }
    }

}
