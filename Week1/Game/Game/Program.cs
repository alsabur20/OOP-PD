using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EZInput;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] maze = new char[39, 55];
            int mazeYMax = 30;

            //Player Position
            int ninjaX = 2;
            int ninjaY = 29;

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
            int snakeLeftX = 2;
            int snakeLeftY = 3;
            int[] leftSnakeX = new int[100];
            int[] leftSnakeY = new int[100];
            int leftSnakeCount = 0;
            char[,] snakeLeft = new char[4, 2] {
                { '(',' '},
                { ' ',')'},
                { '(',' '},
                { ' ','0'}
            };

            // Snake Right Wall
            int snakeRightX = 50;
            int snakeRightY = 3;
            int[] rightSnakeX = new int[100];
            int[] rightSnakeY = new int[100];
            int rightSnakeCount = 0;
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
            PrintNinja(ninjaRight, ninjaLeft, ninjaX, ninjaY);
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
                    GenerateLeftSnake(snakeLeft, leftSnakeX, leftSnakeY, ref leftSnakeCount, snakeLeftX, snakeLeftY);
                }
                if (GenerateRandomNumber()== 8)
                {
                    GenerateRightSnake(snakeRight, rightSnakeX, rightSnakeY, ref rightSnakeCount, snakeRightX, snakeRightY);
                }
                if (moveStatus == 'S')
                {
                    if (Keyboard.IsKeyPressed(Key.UpArrow))
                    {
                        MoveNinjaUp(maze, ninjaLeft, ninjaRight, ref ninjaX, ref ninjaY, ref moveStatus);
                    }
                }
                if (moveStatus == 'S')
                {
                    if (Keyboard.IsKeyPressed(Key.DownArrow))
                    {
                        MoveNinjaDown(maze, ninjaLeft, ninjaRight, ref ninjaX, ref ninjaY, ref moveStatus, mazeYMax);
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
                    MoveNinjaRight(maze, ninjaLeft, ninjaRight, ref ninjaX, ref ninjaY, ref moveStatus);
                }
                if (moveStatus == 'L')
                {
                    MoveNinjaLeft(maze, ninjaLeft, ninjaRight, ref ninjaX, ref ninjaY, ref moveStatus);
                }
                PrintNinja(ninjaRight, ninjaLeft, ninjaX, ninjaY);
                MoveLeftSnake(maze, snakeLeft, leftSnakeX, leftSnakeY, ref leftSnakeCount, ref hit, mazeYMax);
                MoveRightSnake(maze, snakeRight, rightSnakeX, rightSnakeY, ref rightSnakeCount, ref hit, mazeYMax);
                CollisionDetection(ninjaX, ninjaY, leftSnakeX, leftSnakeY, ref leftSnakeCount, rightSnakeX, rightSnakeY, ref rightSnakeCount, ref hit);
                
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
        static void CollisionDetection(int ninjaX, int ninjaY, int[] leftSnakeX, int[] leftSnakeY, ref int leftSnakeCount, int[] rightSnakeX, int[] rightSnakeY, ref int rightSnakeCount, ref int hit)
        {
            int startX = ninjaX;
            int endX = ninjaX + 3;
            int startY = ninjaY;
            int endY = ninjaY + 3;
            for (int col = startY; col <= endY; col++)
            {
                for (int row = startX; row <= endX; row++)
                {
                    // For Left Snake 
                    for (int i = 0; i < leftSnakeCount; i++)
                    {
                        if (row == leftSnakeX[i] && col == leftSnakeY[i])
                        {
                            hit++;
                            eraseSnake(leftSnakeX[i], leftSnakeY[i]);
                            deleteLeftSnakeFromArray(leftSnakeX, leftSnakeY, ref leftSnakeCount, i);
                        }
                    }
                    // For Right Snake 
                    for (int i = 0; i < rightSnakeCount; i++)
                    {
                        if (row == rightSnakeX[i] && col == rightSnakeY[i])
                        {
                            hit++;
                            eraseSnake(rightSnakeX[i], rightSnakeY[i]);
                            deleteRightSnakeFromArray(rightSnakeX, rightSnakeY, ref rightSnakeCount, i);
                        }
                    }
                }
            }
        }
        static void MoveLeftSnake(char[,] maze, char[,] snakeLeft, int[] leftSnakeX, int[] leftSnakeY, ref int leftSnakeCount, ref int hit, int mazeYMax)
        {
            int i = 0;
            while (i < leftSnakeCount)
            {
                if (maze[leftSnakeY[i] + 1, leftSnakeX[i] + 1] != ' ' || maze[leftSnakeY[i] + 1, leftSnakeX[i] + 1] != ' ' || maze[leftSnakeY[i] + 1, leftSnakeX[i]] != ' ' || maze[leftSnakeY[i] + 1, leftSnakeX[i]] != ' ')
                {
                    eraseSnake(leftSnakeX[i], leftSnakeY[i]);
                }
                else if (leftSnakeY[i] == mazeYMax)
                {
                    eraseSnake(leftSnakeX[i], leftSnakeY[i]);
                    deleteLeftSnakeFromArray(leftSnakeX, leftSnakeY, ref leftSnakeCount, i);
                }
                else
                {

                    eraseSnake(leftSnakeX[i], leftSnakeY[i]);
                    leftSnakeY[i] = leftSnakeY[i] + 1;
                    printLeftSnake(snakeLeft, leftSnakeX[i], leftSnakeY[i]);
                    i++;
                }
            }
        }
        static void MoveRightSnake(char[,] maze, char[,] snakeRight, int[] rightSnakeX, int[] rightSnakeY, ref int rightSnakeCount, ref int hit, int mazeYMax)
        {
            int i = 0;
            while (i < rightSnakeCount)
            {
                if (maze[rightSnakeY[i] + 1, rightSnakeX[i] + 1] != ' ' || maze[rightSnakeY[i] + 1, rightSnakeX[i] + 1] != ' ' || maze[rightSnakeY[i] + 1, rightSnakeX[i]] != ' ' || maze[rightSnakeY[i] + 1, rightSnakeX[i]] != ' ')
                {
                    eraseSnake(rightSnakeX[i], rightSnakeY[i]);
                }
                else if (rightSnakeY[i] == mazeYMax)
                {
                    eraseSnake(rightSnakeX[i], rightSnakeY[i]);
                    deleteRightSnakeFromArray(rightSnakeX, rightSnakeY, ref rightSnakeCount, i);
                }
                else
                {

                    eraseSnake(rightSnakeX[i], rightSnakeY[i]);
                    rightSnakeY[i] = rightSnakeY[i] + 1;
                    printRightSnake(snakeRight, rightSnakeX[i], rightSnakeY[i]);
                    i++;
                }
            }
        }
        static void GenerateLeftSnake(char[,] snakeLeft, int[] leftSnakeX, int[] leftSnakeY, ref int leftSnakeCount, int snakeLeftX, int snakeLeftY)
        {
            leftSnakeX[leftSnakeCount] = snakeLeftX;
            leftSnakeY[leftSnakeCount] = snakeLeftY;
            int x = snakeLeftX;
            int y = snakeLeftY;
            for (int row = 3; row >= 0; row--)
            {
                Console.SetCursorPosition(x, y);
                for (int col = 0; col < 2; col++)
                {
                    Console.Write(snakeLeft[row, col]);
                }
                y--;
            }
            leftSnakeCount++;
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
        static void deleteLeftSnakeFromArray(int[] leftSnakeX, int[] leftSnakeY, ref int leftSnakeCount, int index)
        {
            for (int j = index; j < leftSnakeCount - 1; j++)
            {
                leftSnakeX[j] = leftSnakeX[j + 1];
                leftSnakeY[j] = leftSnakeY[j + 1];
            }
            leftSnakeCount--;
        }
        static void deleteRightSnakeFromArray(int[] rightSnakeX, int[] rightSnakeY, ref int rightSnakeCount, int index)
        {
            for (int j = index; j < rightSnakeCount - 1; j++)
            {
                rightSnakeX[j] = rightSnakeX[j + 1];
                rightSnakeY[j] = rightSnakeY[j + 1];
            }
            rightSnakeCount--;
        }
        static void GenerateRightSnake(char[,] snakeRight, int[] rightSnakeX, int[] rightSnakeY, ref int rightSnakeCount, int snakeRightX, int snakeRightY)
        {
            rightSnakeX[rightSnakeCount] = snakeRightX;
            rightSnakeY[rightSnakeCount] = snakeRightY;
            int x = snakeRightX;
            int y = snakeRightY;
            for (int row = 3; row >= 0; row--)
            {
                Console.SetCursorPosition(x, y);
                for (int col = 0; col < 2; col++)
                {
                    Console.Write(snakeRight[row, col]);
                }
                y--;
            }
            rightSnakeCount++;
        }
        static void MoveNinjaRight(char[,] maze, char[,] ninjaLeft, char[,] ninjaRight, ref int ninjaX, ref int ninjaY, ref char moveStatus)
        {
            if (maze[ninjaY, ninjaX + 4] == ' ')
            {
                EraseNinja(ninjaX, ninjaY);
                ninjaX++;
            }
            else
            {
                moveStatus = 'S';
            }
            PrintNinja(ninjaRight, ninjaLeft, ninjaX, ninjaY);
        }
        static void MoveNinjaLeft(char[,] maze, char[,] ninjaLeft, char[,] ninjaRight, ref int ninjaX, ref int ninjaY, ref char moveStatus)
        {
            if (maze[ninjaY, ninjaX - 1] == ' ')
            {
                EraseNinja(ninjaX, ninjaY);
                ninjaX--;
            }
            else
            {
                moveStatus = 'S';
            }
            PrintNinja(ninjaRight, ninjaLeft, ninjaX, ninjaY);
        }
        static void MoveNinjaUp(char[,] maze, char[,] ninjaLeft, char[,] ninjaRight, ref int ninjaX, ref int ninjaY, ref char moveStatus)
        {
            if (ninjaY > 8)
            {
                if (maze[ninjaY - 1, ninjaX] == ' ')
                {
                    EraseNinja(ninjaX, ninjaY);
                    ninjaY--;
                }
                else
                {
                    moveStatus = 'S';
                }
                PrintNinja(ninjaRight, ninjaLeft, ninjaX, ninjaY);
            }
        }
        static void MoveNinjaDown(char[,] maze, char[,] ninjaLeft, char[,] ninjaRight, ref int ninjaX, ref int ninjaY, ref char moveStatus, int mazeYMax)
        {
            if (ninjaY < mazeYMax)
            {
                if (maze[ninjaY + 1, ninjaX] == ' ')
                {
                    EraseNinja(ninjaX, ninjaY);
                    ninjaY++;
                }
                else
                {
                    moveStatus = 'S';
                }
                PrintNinja(ninjaRight, ninjaLeft, ninjaX, ninjaY);
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
        static void PrintNinja(char[,] ninjaRight, char[,] ninjaLeft, int ninjaX, int ninjaY)
        {
            int x = ninjaX;
            int y = ninjaY;
            if (ninjaX < 27)
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
            string path = "E:\\Semester2\\Lab\\OOP\\PD\\Week1\\Game\\stage.txt";
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
