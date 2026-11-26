namespace GridDungeon
{
    class Map
    {
        static string[] map = File.ReadAllLines(Path.Combine(AppContext.BaseDirectory, "maps", "level1.txt"));
        static char[,] area = new char[map.Length, map[0].Length];
        static bool[,] visibleArea = new bool[map.Length, map[0].Length];
        static int coinsCount;
        static bool doorIsOpen = false;
        static int visionRadius = 2;
        public static void AreaBuilder()
        {
            coinsCount = 0;
            doorIsOpen = false;
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    area[i, j] = map[i][j];
                    if(area[i, j] == 'M')
                    {
                        coinsCount++;
                    }
                    visibleArea[i, j] = false;
                }
            }
        }
        public static void AreaDrawer(int row, int col)
        {
            for (int i = 0; i < area.GetLength(0); i++)
            {
                for (int j = 0; j < area.GetLength(1); j++)
                {
                    if (i == row && j == col)
                    {
                        Console.Write("@");
                        Console.Write(' ');
                    }
                    else
                    {
                        if (!visibleArea[i, j])
                        {
                            Console.Write('?');
                            Console.Write(' ');
                        }
                        else
                        {
                            if (area[i, j] == 'T')
                            {
                                Console.Write('.');
                                Console.Write(' ');
                            }
                            else if (area[i, j] == 'D' && doorIsOpen)
                            {
                                Console.Write('O');
                                Console.Write(' ');
                            }
                            else
                            {
                                Console.Write(area[i, j]);
                                Console.Write(' ');
                            }
                        }

                    }
                }
                Console.WriteLine();
            }
        }
        public static bool MovementValidation(int row, int col, string direction)
        {
            bool result = false;
            switch (direction)
            {
                case "up":
                    if (row > 0 && IsWalkable(row - 1, col))
                    {
                        result = true;
                    }
                    break;
                case "down":
                    if (row < map.Length - 1 && IsWalkable(row + 1, col))
                    {
                        result = true;
                    }
                    break;
                case "left":
                    if (col > 0 && IsWalkable(row, col - 1))
                    {
                        result = true;
                    }
                    break;
                case "right":
                    if (col < map[0].Length - 1 && IsWalkable(row, col + 1))
                    {
                        result = true;
                    }
                    break;
            }

            return result;
        }
        public static char StepOn(int row, int col)
        {
            char result = ' ';
            if (area[row, col] == 'M')
            {
                area[row, col] = '.';
                result = 'm';
            }
            else if (area[row, col] == 'T')
            {
                area[row, col] = '*';
                result = 't';
            }
            else if (area[row, col] == 'D')
            {
                if (doorIsOpen)
                {
                    result = 'd';
                }
            }
            return result;
        }
        public static void Reveal(int row, int col)
        {
            for (int i = 0; i < area.GetLength(0); i++)
            {
                for (int j = 0; j < area.GetLength(1); j++)
                {
                    if (Math.Abs(i - row) <= visionRadius && Math.Abs(j - col) <= visionRadius)
                    {

                        visibleArea[i, j] = true;
                    }
                }
            }
        }
        static bool IsWalkable(int row, int col)
        {
            return area[row, col] != '#' && (area[row, col] != 'D' || doorIsOpen);
        }
        public static bool OpenDoor(int coins)
        {
            if (coins == coinsCount)
            {
                doorIsOpen = true;
                return true;
            }
            return false;
        }

    }
}
