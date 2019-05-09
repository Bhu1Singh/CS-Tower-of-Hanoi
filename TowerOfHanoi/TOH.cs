using System;
using System.Collections.Generic;

namespace TowerOfHanoi
{
    class TOH
    {
        static int global_disc_num = 0;
        static int iCount = 0;
        static void Main(string[] args)
        {
            var loop = true;
            while (loop)
            {
                Console.WriteLine("Welcome to the Tower of Hanoi\n\n");
                Console.WriteLine("Enter the number of discs to move:");
                var disknum = 0;
                while (disknum <= 0)
                {
                    var check = int.TryParse(Console.ReadLine(), out disknum);
                    if (!check || disknum <= 0)
                    {
                        Console.WriteLine("Invalid input. Value should be a number greater than 0");
                    }
                }
                global_disc_num = disknum;
                Stack<int> source = new Stack<int>(disknum);
                for (int i = disknum; i > 0; i--)
                    source.Push(i);

                Stack<int> dest = new Stack<int>(disknum);
                Stack<int> aux = new Stack<int>(disknum);
                iCount = 0;
                Print_Tower(source, dest, aux);

                Move_Tower(disknum, source, dest, aux);
                //Move_Tower(disknum, "S", "D", "A");
                Console.WriteLine($"Number of tries(expected : {Math.Pow(2, global_disc_num) - 1 }) : {iCount}");
                Print_Tower(source, dest, aux);

                Console.WriteLine("Continue (C) or Exit(E):");
                var choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "C":
                        Console.Clear();
                        Main(null);
                        break;
                    case "E":
                        loop = false;
                        break;
                    default:
                        loop = false;
                        break;
                }
            }
        }
        static void Move_Tower(int disknum, Stack<int> sourcepillar, Stack<int> destpillar, Stack<int> auxpillar)
        {
            if (disknum > 0)
            {
                Move_Tower(disknum - 1, sourcepillar, auxpillar, destpillar);

                var temp = sourcepillar.Pop();
                destpillar.Push(temp);
                iCount++;

                Move_Tower(disknum - 1, auxpillar, destpillar, sourcepillar);
            }
        }

        static void Move_Tower(int disknum, string source, string dest, string aux)
        {
            if (disknum > 0)
            {
                Move_Tower(disknum - 1, source, aux, dest);

                Console.WriteLine($"Move disk {disknum} from {source} to {dest}");
                Move_Tower(disknum - 1, aux, dest, source);
            }
        }

        static void Print_Tower(Stack<int> sourcepillar, Stack<int> destpillar, Stack<int> auxpillar)
        {
            Console.WriteLine();

            Console.WriteLine("---------------------------------");
            Console.WriteLine("S     A     D");
            Console.WriteLine("---------------------------------");

            for (int i = 1; i <= global_disc_num; i++)
            {
                Console.WriteLine($"{(sourcepillar.Contains(i) ? i.ToString() : "")}      {(auxpillar.Contains(i) ? i.ToString() : "")}      {(destpillar.Contains(i) ? i.ToString() : "")}");
            }

        }
    }
}
