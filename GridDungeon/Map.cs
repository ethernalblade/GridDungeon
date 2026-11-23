using System.Runtime.CompilerServices;

namespace GridDungeon
{
    class Map
    {
        static string[] map =
        {
            ".....#.....#....M#...#...#T..........#...",
            ".#.###.###.#.#####.#.#.###.###.###.#.#.#.",
            ".#M#...#...#.......#.#.............#...#M",
            ".###.###.#########.#.#.......#####.#.#.##",
            "...#.T...#.......#.#.........#..M#.#.#...",
            "##.#.#######.###.#######.#####.#####.###.",
            ".....#...T.#.#.#.......#.........#.......",
            ".#.#.#.#.#.#.#T###.###.#####.###.#.#.#.#.",
            "...#.#T#.#.#M#.#.#...........#.#.#...#.#.",
            ".###.#.###.###.#.###.###.###.#.#.#.#####.",
            "...#.#.....#.#.#.......#..M#.....#...T...",
            "##.#.#.....#.#.#.#######.#####.###.#.#.#.",
            "...#M#.....#.#T..T...#.#.....#T..#.#M#.#.",
            ".#####.#####.###.###.#.#####.#####.###.#.",
            ".........#...T.....#.....#.#.....#.......",
            ".#.#####.#########.#######.#.###.###.....",
            ".#.#.T...#M....#...#.............#.#.....",
            "##.#.###.#####.#.#.#.###.......###.###.##",
            ".#.#T#...#.....#.#...#...........#.....#M",
            ".#.#.###.#.#T#.#T#.###.#.......#.#####.#.",
            "...#...#...#.........................#...",
        };

        static char[,] area = new char[map.Length, map[0].Length];
        static bool[,] visiblArea = new bool[map.Length, map[0].Length];

        public static void AreaBuilder()
        {
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    area[i, j] = map[i][j];
                    visiblArea[i, j] = false;
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
                        if (!visiblArea[i, j])
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
                    if (col > 0 && area[row, col - 1] != '#')
                    {
                        result = true;
                    }
                    break;
                case "right":
                    if (col < map[0].Length - 1 && area[row, col + 1] != '#')
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
            return result;
        }
        public static void Reveal(int row, int col)
        {
            for (int i = 0; i < area.GetLength(0); i++)
            {
                for (int j = 0; j < area.GetLength(1); j++)
                {
                    int visionRadius = 2;
                    if (Math.Abs(i - row) <= visionRadius && Math.Abs(j - col) <= visionRadius)
                    {

                        visiblArea[i, j] = true;
                    }
                }
            }
        }

    }
}
