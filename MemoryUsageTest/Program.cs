using System;
using System.Collections.Generic;

namespace MemoryUsageTest
{
    internal static class Program
    {
        private static List<string> logMessages = new List<string>();

        private static void Main(string[] args)
        {
            var countOfKeysPressed = 0;
            var random = new Random(Environment.TickCount);

            while (true)
            {
                var keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.Escape)
                    break;

                if (keyPressed.Key != ConsoleKey.Enter)
                    continue;

                countOfKeysPressed++;

                var randomValue = random.Next(0, 1000);
                var isOdd = randomValue % 2 == 0;

                Log(isOdd, "Log data", new { isOdd, randomValue });
            }

            Console.WriteLine($"Keys pressed: {countOfKeysPressed}");
            Console.WriteLine($"Logs count: {logMessages.Count}");

            Console.ReadKey();
        }

        private static void Log(bool isEnabled, string message, object data)
        {
            if (isEnabled)
            {
                logMessages.Add($"{message} {data}");
            }
        }
    }
}