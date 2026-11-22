using GridDungeon;

int row = 9;
int col = 0;
bool running = true;
Console.CursorVisible = false;
int coinsCollected = 0;
int hp = 2;
Map.AreaBuilder();
while (running)
{

    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"Coins collected: {coinsCollected}");
    Console.WriteLine($"Hp left: {hp}");
    Map.AreaDrawer(row, col);
    ConsoleKey key = Console.ReadKey(true).Key;
    switch (key)
    {
        case ConsoleKey.W:
        case ConsoleKey.UpArrow:
            if (Map.MovementValidation(row, col, "up"))
            {
                row--;
            }
            break;
        case ConsoleKey.S:
        case ConsoleKey.DownArrow:
            if (Map.MovementValidation(row, col, "down"))
            {
                row++;
            }
            break;
        case ConsoleKey.A:
        case ConsoleKey.LeftArrow:
            if (Map.MovementValidation(row, col, "left"))
            {
                col -= 2;
            }
            break;
        case ConsoleKey.D:
        case ConsoleKey.RightArrow:
            if (Map.MovementValidation(row, col, "right"))
            {
               col += 2;
            }
            break;
        case ConsoleKey.Escape:
            running = false;
            break;

    }
    char interaction = Map.StepOn(row, col);
    if (interaction == 'm')
    {
        coinsCollected++;
    }
    else if(interaction == 't')
    {
        hp--;
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
        Map.AreaBuilder();

        if (running)
        {
            Console.Clear();    
        }
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