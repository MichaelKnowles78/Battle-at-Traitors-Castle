using System;
using System.Threading;

namespace Battle_At_Traitor_s_Castle
{
    static class Program
    {
        static void Main()
        {
            Console.Title = "TRAITOR'S CASTLE";
            int shots = 0;

            Random rnd = new Random();
            for (int attempt=0; attempt < 10; attempt++)
            {
                int guardPosition = rnd.Next(1, 10);
                string row = "........";
                row = row.Insert(guardPosition - 1, "O");
                ClearKeyPresses();
                Console.WriteLine(row);
                Thread.Sleep(2000);
                if (Console.KeyAvailable)
                {
                    int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out int keyPressed);
                    if (keyPressed == guardPosition)
                    {
                        Console.WriteLine("GOOD SHOT");
                        shots++;
                        continue;
                    }
                }
                Console.WriteLine("MISSED");
            }

            Console.WriteLine($"YOU HIT {shots} OUT OF 10");
            Console.ReadKey();
        }

        static void ClearKeyPresses()
        {
            while(Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }
}
