namespace GridDungeon
{
    class Map
    {
        static string[] map =
        {
            ". . . . . . . . . M",
            ". # . # # # # # # #",
            ". # . . . # . . . T",
            ". # . # . # . # # #",
            ". # . # . # . . . #",
            ". # . # . . . # . #",
            ". # . # . # . # . M",
            ". # . # # # . # # #",
            ". # . . . # . # . T",
            ". # . # M # . . . #",
        };
        static char[,] area = new char[map.Length, map[0].Length];

        public static void AreaBuilder()
        {
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    area[i, j] = map[i][j];
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
                    }
                    else
                    {
                        Console.Write(area[i, j]);
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
                    if (row > 0 && area[row - 1, col] != '#')
                    {
                        result = true;
                    }
                    break;
                case "down":
                    if (row < map.Length - 1 && area[row + 1, col] != '#')
                    {
                        result = true;
                    }
                    break;
                case "left":
                    if (col > 1 && area[row, col - 2] != '#')
                    {
                        result = true;
                    }
                    break;
                case "right":
                    if (col < map[0].Length - 2 && area[row, col + 2] != '#')
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
                area[row, col] = '.';
                result = 't';
            }
            return result;
        }

    }
}
