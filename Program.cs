// See https://aka.ms/new-console-template for more 
namespace ConsoleApp1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("HI KING ^^ Who are you king?");
            string name = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Oh OK... I will call you Stranger, then.. ");
                name = "Stranger";
                //Console.ReadLine();
            }
            else if (name.ToLower() == "stranger")
            {
                Console.WriteLine("Ha! I knew it!");
            }

            Console.WriteLine($"Where are you from, {name}?");
            string place = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(place))
            {
                Console.WriteLine("You are not too talktive, are you?");
                place = "Nowhere";
            }
            Console.WriteLine($"Welcome to Neon Blade World, {name} from {place}!");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);

            string[] level = {
                "#############",
                "#    #  #   #",
                "#    #  #  ##",
                "##   #     ##",
                "##     #   ##",
                "#############",

            };

            string[] scroll = {
            @"     _______________",
            @"()==(              (@==()",
            @"    '______________'|",
            @"      |             |",
            @"      |             |",
            @"    __)_____________|     ",
            @"()==(               (@==()",
            @"    '--------------'      ",
            @"                     PjP",
            };

            Console.Clear();

            Console.WriteLine("Wanna see the map? Press any jey it is until revealed...");

            int scrollHalf = scroll.Length / 2;
            for (int i = 0; i < scrollHalf; i++)
            {
                Console.WriteLine(scroll[i]);
            }

            int nextMapRowPosition = Console.CursorTop;
            foreach (string row in level)
            {
                Console.SetCursorPosition(0, nextMapRowPosition);
                Console.WriteLine($"      |{row}|");



                for (int i = scrollHalf; i < scroll.Length; i++)
                {
                    Console.WriteLine(scroll[i]);
                }
                nextMapRowPosition++;
                Console.ReadKey(true);
            }
            Console.Clear();
            foreach (string row in level)
            {
                Console.WriteLine(row);
            }
            int playerColumn = 2;
            int playerRow = 3;

            while (true)
            {
                Console.SetCursorPosition(playerColumn, playerRow);
                Console.Write("@");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                Console.SetCursorPosition(playerColumn, playerRow);
                string currentRow = level[playerRow];
                char currentCell = currentRow[playerColumn];
                Console.Write(currentCell);

                int targetColumn = playerColumn;
                int targetRow = playerRow;

                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    targetColumn = playerColumn - 1;
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    playerColumn = playerColumn + 1;
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    playerRow = playerRow - 1;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    playerRow = playerRow + 1;
                }

                else
                {
                    break;
                }

                if (targetColumn >= 0 && targetColumn < level[playerRow].Length && level[playerRow][targetColumn] != '#')
                {
                    playerColumn = targetColumn;
                }

                if (targetColumn >= 0 && targetRow < level.Length && level[targetRow][playerColumn] != '#')

                {
                    playerRow = targetRow;
                }
            }

            Console.SetCursorPosition(0, level.Length);
        }
    }
}