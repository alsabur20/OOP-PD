using EZInput;
using Game.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] maze = new char[39, 55];
            int mazeYMax = 30;

            //Player Position
            Ninja ninja = new Ninja();
            ninja.xPos = 2;
            ninja.yPos = 29;

            //Player Right
            char[,] ninjaRight = new char[4, 4] {
                { ' ',' ',' ','>'},
                { 'O',' ','/',' '},
                { ' ','\\',' ',' '},
                { ' ',' ',' ','>'}
            };
            // Player Left
            char[,] ninjaLeft = new char[4, 4] {
                {'<',' ',' ', ' '},
                { ' ','\\',' ','O'},
                { ' ',' ','/',' '},
                { '<',' ',' ', ' '}
            };
            // Snake Left Wall
            SnakeLeft sLeft = new SnakeLeft();
            sLeft.xPos = 2;
            sLeft.yPos = 3;
            List<SnakeLeft> sL = new List<SnakeLeft>();
            char[,] snakeLeft = new char[4, 2] {
                { '(',' '},
                { ' ',')'},
                { '(',' '},
                { ' ','0'}
            };

            // Snake Right Wall
            SnakeRight sRight = new SnakeRight();
            sRight.xPos = 50;
            sRight.yPos = 3;
            List<SnakeRight> sR = new List<SnakeRight>();
            char[,] snakeRight = new char[4, 2] {
                { ' ',')'},
                { '(',' '},
                { ' ',')'},
                { '0',' '}
            };
            char moveStatus = 'S';
            int hit = 0;
            int lifeCount = 5;
            LoadStage(maze);
            PrintStage(maze);
            PrintNinja(ninjaRight, ninjaLeft, ninja);
            do
            {
                Console.SetCursorPosition(60, 4);
                Console.WriteLine("Hits: {0}", hit);
                Console.SetCursorPosition(60, 5);
                Console.WriteLine("Lifes: {0}", lifeCount);
                Thread.Sleep(100);
                if (hit == 2)
                {
                    lifeCount--;
                    hit = 0;
                }
                if (GenerateRandomNumber() == 10)
                {
                    GenerateLeftSnake(snakeLeft, sL, sLeft);
                }
                if (GenerateRandomNumber() == 8)
                {
                    GenerateRightSnake(snakeRight, sR, sRight);
                }
                if (moveStatus == 'S')
                {
                    if (Keyboard.IsKeyPressed(Key.UpArrow))
                    {
                        MoveNinjaUp(maze, ninjaLeft, ninjaRight, ninja, ref moveStatus);
                    }
                }
                if (moveStatus == 'S')
                {
                    if (Keyboard.IsKeyPressed(Key.DownArrow))
                    {
                        MoveNinjaDown(maze, ninjaLeft, ninjaRight, ninja, ref moveStatus, mazeYMax);
                    }
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    if (moveStatus == 'S')
                    {
                        moveStatus = 'L';
                    }
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    if (moveStatus == 'S')
                    {
                        moveStatus = 'R';
                    }
                }
                if (moveStatus == 'R')
                {
                    MoveNinjaRight(maze, ninjaLeft, ninjaRight, ninja, ref moveStatus);
                }
                if (moveStatus == 'L')
                {
                    MoveNinjaLeft(maze, ninjaLeft, ninjaRight, ninja, ref moveStatus);
                }
                PrintNinja(ninjaRight, ninjaLeft, ninja);
                MoveLeftSnake(maze, snakeLeft, sL, ref hit, mazeYMax);
                MoveRightSnake(maze, snakeRight, sR, ref hit, mazeYMax);
                CollisionDetection(ninja, sL, sR, ref hit);

            }
            while (lifeCount > 0);
            if (lifeCount == 0)
            {
                Console.Clear();
                Console.WriteLine("Game Over!!");
                Console.Write("Press any key to continue...");
                Console.ReadLine();
            }
        }
        static int GenerateRandomNumber()
        {
            Random rnd = new Random();
            int min = 0;
            int max = 20;
            return rnd.Next(min, max);
        }
        static void CollisionDetection(Ninja ninja, List<SnakeLeft> sL, List<SnakeRight> sR, ref int hit)
        {
            int startX = ninja.xPos;
            int endX = ninja.xPos + 3;
            int startY = ninja.yPos;
            int endY = ninja.yPos + 3;
            for (int col = startY; col <= endY; col++)
            {
                for (int row = startX; row <= endX; row++)
                {
                    // For Left Snake 
                    for (int i = 0; i < sL.Count; i++)
                    {
                        if (row == sL[i].xPos && col == sL[i].yPos)
                        {
                            hit++;
                            eraseSnake(sL[i].xPos, sL[i].yPos);
                            deleteLeftSnakeFromList(sL, i);
                        }
                    }
                    // For Right Snake 
                    for (int i = 0; i < sR.Count; i++)
                    {
                        if (row == sR[i].xPos && col == sR[i].yPos)
                        {
                            hit++;
                            eraseSnake(sR[i].xPos, sR[i].yPos);
                            deleteRightSnakeFromList(sR, i);
                        }
                    }
                }
            }
        }
        static void MoveLeftSnake(char[,] maze, char[,] snakeLeft, List<SnakeLeft> sL, ref int hit, int mazeYMax)
        {
            int i = 0;
            while (i < sL.Count)
            {
                if (maze[sL[i].yPos + 1, sL[i].xPos + 1] != ' ' || maze[sL[i].yPos + 1, sL[i].xPos + 1] != ' ' || maze[sL[i].yPos + 1, sL[i].xPos] != ' ' || maze[sL[i].yPos + 1, sL[i].xPos] != ' ')
                {
                    eraseSnake(sL[i].xPos, sL[i].yPos);
                }
                else if (sL[i].yPos == mazeYMax)
                {
                    eraseSnake(sL[i].xPos, sL[i].yPos);
                    deleteLeftSnakeFromList(sL, i);
                }
                else
                {

                    eraseSnake(sL[i].xPos, sL[i].yPos);
                    sL[i].yPos = sL[i].yPos + 1;
                    printLeftSnake(snakeLeft, sL[i].xPos, sL[i].yPos);
                    i++;
                }
            }
        }
        static void MoveRightSnake(char[,] maze, char[,] snakeRight, List<SnakeRight> sR, ref int hit, int mazeYMax)
        {
            int i = 0;
            while (i < sR.Count)
            {
                if (maze[sR[i].yPos + 1, sR[i].xPos + 1] != ' ' || maze[sR[i].yPos + 1, sR[i].xPos + 1] != ' ' || maze[sR[i].yPos + 1, sR[i].xPos] != ' ' || maze[sR[i].yPos + 1, sR[i].xPos] != ' ')
                {
                    eraseSnake(sR[i].xPos, sR[i].yPos);
                }
                else if (sR[i].yPos == mazeYMax)
                {
                    eraseSnake(sR[i].xPos, sR[i].yPos);
                    deleteRightSnakeFromList(sR, i);
                }
                else
                {

                    eraseSnake(sR[i].xPos, sR[i].yPos);
                    sR[i].yPos = sR[i].yPos + 1;
                    printRightSnake(snakeRight, sR[i].xPos, sR[i].yPos);
                    i++;
                }
            }
        }
        static void GenerateLeftSnake(char[,] snakeLeft, List<SnakeLeft> sL, SnakeLeft sLeft)
        {
            SnakeLeft temp = new SnakeLeft();
            temp.xPos = sLeft.xPos;
            temp.yPos = sLeft.yPos;
            int x = sLeft.xPos;
            int y = sLeft.yPos;
            for (int row = 3; row >= 0; row--)
            {
                Console.SetCursorPosition(x, y);
                for (int col = 0; col < 2; col++)
                {
                    Console.Write(snakeLeft[row, col]);
                }
                y--;
            }
            sL.Add(temp);
        }
        static void printRightSnake(char[,] snakeRight, int x, int y)
        {
            // 3X4
            for (int row = 3; row >= 0; row--)
            {
                Console.SetCursorPosition(x, y);
                for (int col = 0; col < 2; col++)
                {
                    Console.Write(snakeRight[row, col]);
                }
                y--;
            }
        }
        static void printLeftSnake(char[,] snakeLeft, int x, int y)
        {
            // 3X4
            for (int row = 3; row >= 0; row--)
            {
                Console.SetCursorPosition(x, y);
                for (int col = 0; col < 2; col++)
                {
                    Console.Write(snakeLeft[row, col]);
                }
                y--;
            }
        }
        static void eraseSnake(int x, int y)
        {
            // 3X4
            Console.SetCursorPosition(x, y - 3);
            for (int i = 0; i < 2; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(x, y - 2);
            for (int i = 0; i < 2; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(x, y - 1);
            for (int i = 0; i < 2; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < 2; i++)
            {
                Console.Write(" ");
            }
        }
        static void deleteLeftSnakeFromList(List<SnakeLeft> sL, int index)
        {
            sL.RemoveAt(index);
        }
        static void deleteRightSnakeFromList(List<SnakeRight> sR, int index)
        {
            sR.RemoveAt(index);
        }
        static void GenerateRightSnake(char[,] snakeRight, List<SnakeRight> sR, SnakeRight sRight)
        {
            SnakeRight temp = new SnakeRight();
            temp.xPos = sRight.xPos;
            temp.yPos = sRight.yPos;
            int x = sRight.xPos;
            int y = sRight.yPos;
            for (int row = 3; row >= 0; row--)
            {
                Console.SetCursorPosition(x, y);
                for (int col = 0; col < 2; col++)
                {
                    Console.Write(snakeRight[row, col]);
                }
                y--;
            }
            sR.Add(temp);
        }
        static void MoveNinjaRight(char[,] maze, char[,] ninjaLeft, char[,] ninjaRight, Ninja ninja, ref char moveStatus)
        {
            if (maze[ninja.yPos, ninja.xPos + 4] == ' ')
            {
                EraseNinja(ninja.xPos, ninja.yPos);
                ninja.xPos++;
            }
            else
            {
                moveStatus = 'S';
            }
            PrintNinja(ninjaRight, ninjaLeft, ninja);
        }
        static void MoveNinjaLeft(char[,] maze, char[,] ninjaLeft, char[,] ninjaRight, Ninja ninja, ref char moveStatus)
        {
            if (maze[ninja.yPos, ninja.xPos - 1] == ' ')
            {
                EraseNinja(ninja.xPos, ninja.yPos);
                ninja.xPos--;
            }
            else
            {
                moveStatus = 'S';
            }
            PrintNinja(ninjaRight, ninjaLeft, ninja);
        }
        static void MoveNinjaUp(char[,] maze, char[,] ninjaLeft, char[,] ninjaRight, Ninja ninja, ref char moveStatus)
        {
            if (ninja.yPos > 8)
            {
                if (maze[ninja.yPos - 1, ninja.xPos] == ' ')
                {
                    EraseNinja(ninja.xPos, ninja.yPos);
                    ninja.yPos--;
                }
                else
                {
                    moveStatus = 'S';
                }
                PrintNinja(ninjaRight, ninjaLeft, ninja);
            }
        }
        static void MoveNinjaDown(char[,] maze, char[,] ninjaLeft, char[,] ninjaRight, Ninja ninja, ref char moveStatus, int mazeYMax)
        {
            if (ninja.yPos < mazeYMax)
            {
                if (maze[ninja.yPos + 1, ninja.xPos] == ' ')
                {
                    EraseNinja(ninja.xPos, ninja.yPos);
                    ninja.yPos++;
                }
                else
                {
                    moveStatus = 'S';
                }
                PrintNinja(ninjaRight, ninjaLeft, ninja);
            }
        }
        static void PrintStage(char[,] maze)
        {
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 55; col++)
                {
                    Console.Write(maze[row, col]);
                }
                Console.WriteLine("");
            }
        }
        static void PrintNinja(char[,] ninjaRight, char[,] ninjaLeft, Ninja ninja)
        {
            int x = ninja.xPos;
            int y = ninja.yPos;
            if (ninja.xPos < 27)
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.SetCursorPosition(x, y);
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write(ninjaLeft[i, j]);
                    }
                    y++;
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.SetCursorPosition(x, y);
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write(ninjaRight[i, j]);
                    }
                    y++;
                }
            }
        }
        static void PrintNinjaRight(char[,] ninjaRight, int ninjaX, int ninjaY)
        {
            int x = ninjaX;
            int y = ninjaY;
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(x, y);
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(ninjaRight[i, j]);
                }
                y++;
            }
        }
        static void EraseNinja(int x, int y)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(x, y);
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(" ");
                }
                y++;
            }
        }
        static void LoadStage(char[,] maze)
        {
            string path = "E:\\Week2\\Game\\stage.txt";
            if (File.Exists(path))
            {
                char temp;
                int row = 0;
                int col = 0;
                StreamReader stage = new StreamReader(path);
                do
                {
                    temp = (char)stage.Read();
                    if (temp == '\n')
                    {
                        row++;
                        col = 0;
                    }
                    else
                    {
                        maze[row, col] = temp;
                        col++;
                    }
                }
                while (!stage.EndOfStream);
                stage.Close();
            }
            else
            {
                Console.WriteLine("Stage Loading Error!!!");
            }
        }
    }
}
