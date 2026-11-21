int row = 9;
int col = 0;
bool running = true;
Console.CursorVisible = false;
int coinsCollected = 0;
int hp = 2;
bool reset = false;
string[] map =
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
char[,] area = new char[map.Length, map[0].Length];
AreaBuilder(area, map);
while (running)
{
    if (reset)
    {
        Console.Clear();
        reset = false;
    }
    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"Coins collected: {coinsCollected}");
    Console.WriteLine($"Hp left: {hp}");
    AreaDrawer(area, row, col);
    ConsoleKey key = Console.ReadKey(true).Key;
    switch (key)
    {
        case ConsoleKey.W:
        case ConsoleKey.UpArrow:
            if (row > 0 && area[row - 1, col] != '#')
            {
                row--;
            }
            break;
        case ConsoleKey.S:
        case ConsoleKey.DownArrow:
            if (row < map.Length - 1 && area[row + 1, col] != '#' )
            {
                row++;
            }
            break;
        case ConsoleKey.A:
        case ConsoleKey.LeftArrow:
            if (col > 1 && area[row, col - 2] != '#' )
            {
                col -= 2;
            }
            break;
        case ConsoleKey.D:
        case ConsoleKey.RightArrow:
            if (col < map[0].Length - 2 && area[row, col + 2] != '#' )
            {
                col += 2;
            }
            break;
            running = false;
            break;

    }
    if (area[row, col] == 'M')
    {
        coinsCollected++;
        area[row, col] = '.';
    }
    else if(area[row, col] == 'T')
    {
        hp--;
        area[row, col] = '.';
    }
    if (coinsCollected == 3 || hp < 1)
    {
        string message = (coinsCollected == 3) ? "You win!" : "You died!"; 
        Console.WriteLine(message);
        Console.CursorVisible = true;
        running = AskPlayAgain();
        Console.CursorVisible = false;
        coinsCollected = 0;
        hp = 2;
        row = 9;
        col = 0;
        AreaBuilder(area, map);
        if (running)
        {
            Console.Clear();
            reset = false;
        }
    }

}


static void AreaBuilder(char[,] area, string[] map)
{
    for (int i = 0; i < map.Length; i++)
    {
        for (int j = 0; j < map[i].Length ; j++)
        {
            area[i, j] = map[i][j];
        }
    }
}
static void AreaDrawer(char[,] area, int row, int col)
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

static bool AskPlayAgain()
{
    bool playAgain = false;
    do
    {
        Console.WriteLine("Wanna play again? (Y or N)");
        switch (Console.ReadLine()?.ToLower())
        {
            case "y":
                playAgain = true;
                break;
            case "n":
                Console.WriteLine("Exiting the game...");
                return playAgain;
            default:
                Console.WriteLine("Invalid input. Please enter Y or N.");
                break;

        }

    } while (playAgain == false);
    return playAgain;
}