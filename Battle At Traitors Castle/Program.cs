using System;
using System.Threading;

namespace Battle_At_Traitor_s_Castle
{
    static class Program
    {
        /// <summary>
        /// Entry point.  Initialise, play, ask to play again
        /// </summary>
        static void Main()
        {
            Console.Title = "TRAITOR'S CASTLE";

            do
            {
                GameLoop();
            } while (PlayAgain());
        }

        /// <summary>
        /// Main game loop
        /// </summary>
        private static void GameLoop()
        {
            Console.Clear();
            int shots = 0;
            Random rnd = new Random();
            for (int attempt = 0; attempt < 10; attempt++)
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
        }

        /// <summary>
        /// Will clear keyboard buffer to prevent too many keystrokes affecting the next shot
        /// </summary>
        static void ClearKeyPresses()
        {
            while(Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }

        /// <summary>        
        /// Will ask if user wants to play again and will wait until either "Y" or "N" is pressed. Can handle both upper and lower case
        /// </summary>
        /// <returns>Returns true if "Y" is pressed or false if "N" is pressed.</returns>
        private static bool PlayAgain()
        {
            Console.WriteLine("PLAY AGAIN (Y/N)");

            char keyPressed;
            do
            {
                keyPressed = Console.ReadKey(true).KeyChar;
            } while (!"yYnN".Contains(keyPressed.ToString()));

            return keyPressed == 'y' || keyPressed == 'Y';
        }
    }
}
