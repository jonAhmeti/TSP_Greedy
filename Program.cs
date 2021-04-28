using System;
using System.Collections.Generic;
using System.Linq;

namespace TravellingSalespersonProblem_Greedy
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomNum = new Random();
            Console.WriteLine("The Traveling Salesperson Problem using the Greedy algorithm");
            Console.WriteLine("\n\nChoose the dimensions of the array to be created");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("***\tFirst dimension: ");
            int dimensionOne = int.Parse(Console.ReadLine());
            Console.Write("***\tSecond dimension: ");
            int dimensionTwo = int.Parse(Console.ReadLine());

            int[,] mapArray = new int[dimensionOne, dimensionTwo];

            for (int row = 0; row < mapArray.GetLength(0); row++)
            {
                for (int col = 0; col < mapArray.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        mapArray[row, col] = 0;
                        Console.WriteLine($"Value for {row + 1}x{col + 1} entity: {mapArray[row, col]}");
                    }
                    else
                    {
                        mapArray[row, col] = randomNum.Next(0, 99);
                        Console.WriteLine($"Value for {row + 1}x{col + 1}: {mapArray[row, col]}");
                        //mapArray[row, col] =int.Parse(Console.ReadLine());
                    }
                }
            }

            Console.ResetColor();
            Console.Write($"\nArray {dimensionOne} by {dimensionTwo} created.");
            Console.WriteLine("\n_____________________________________");
            for (int row = 0; row < mapArray.GetLength(0); row++)
            {
                for (int col = 0; col < mapArray.GetLength(1); col++)
                {
                    if (row == col)
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                    if (col == 0)
                    {
                        Console.Write("\n" + mapArray[row, col] + "\t");
                    }
                    else
                    {
                        Console.Write(mapArray[row, col] + "\t");
                    }

                    Console.ResetColor();
                }
            }
            Console.WriteLine("\n_____________________________________\n");

            CheckRow(mapArray, 0, new List<int>(),0);

            Console.Read();
        }

        public static void CheckRow(int[,] map, int row, List<int> visited, int sum)
        {
            Console.WriteLine($"\nrow visited: {row}");
            visited.Add(row);
            List<int> values = new List<int>();
            List<int> columns = new List<int>();
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (j==row || visited.Contains(j))
                    continue;

                columns.Add(j);
                values.Add(map[row,j]);
            }

            if (values.Any())
            {
                int minValue = values.Min();
                sum += minValue;
                Console.Write($"Minimum value: {minValue}\t");
                Console.WriteLine($"index {row}x{columns[values.IndexOf(minValue)]}");
                CheckRow(map, columns[values.IndexOf(minValue)], visited, sum);
            }
            else
            {
                Console.Write($"Last value to origin: {map[row, 0]} ");
                Console.WriteLine($"index {row}x0");
                sum += map[row, 0];
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("End of route. This is the last city (row) that had to be visited.");
                Console.WriteLine($"Final score: {sum}");
                Console.ResetColor();
            }
        }
    }
}
