using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Battle_At_Traitor_s_Castle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "TRAITOR'S CASTLE";
            int shots = 0;

            for(int attempt=0; attempt < 10; attempt++)
            {
                Random rnd = new Random();
                int guardPosition = rnd.Next(1, 10);
                string row = "";
                for(int i=1; i < 10; i++)
                {
                    if (guardPosition == i)
                    {
                        row += "O";
                    }
                    else
                    {
                        row += ".";
                    }
                }
                ClearKeyPresses();
                Console.WriteLine(row);
                Thread.Sleep(2000);
                if (Console.KeyAvailable)
                {
                    int keyPressed;
                    int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out keyPressed);
                    if (keyPressed == guardPosition)
                    {
                        Console.WriteLine("GOOD SHOT");
                        shots++;
                        continue;
                    }
                }
                Console.WriteLine("MISSED");
            }

            Console.WriteLine("YOU HIT " + shots.ToString() + " OUT OF 10");
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
