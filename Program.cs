// See https://aka.ms/new-console-template for more 
using King;

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
            
            Player player = new Player(2, 3, "@");

            while (true)
            {
                King.Display.WriteAt(player.x, player.y, player.avatar);


                ConsoleKeyInfo keyInfo = Console.ReadKey(true);


                string currentRow = level[player.y];
                char currentCell = currentRow[player.x];
                King.Display.WriteAt(player.x, player.y, currentCell);



                int targetColumn = player.x;
                int targetRow = player.y;

                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    targetColumn = player.x - 1;
                }

                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    targetColumn = player.x + 1;
                }

                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    targetRow = player.y - 1;
                }

                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    targetRow = player.y + 1;
                }

                else
                {
                    break;
                }

                if (targetColumn >= 0 && targetColumn < level[player.y].Length && level[player.y][targetColumn] != '#')
                {
                    player.x = targetColumn;
                }

                if (targetColumn >= 0 && targetRow < level.Length && level[targetRow][player.x] != '#')

                {
                    player.y = targetRow;
                }
            }

            Console.SetCursorPosition(0, level.Length);
        }
    }
}