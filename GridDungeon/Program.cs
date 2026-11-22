using GridDungeon;

Player player;
bool running = true;
Console.CursorVisible = false;
Map.AreaBuilder();
player = new Player();
while (running)
{
    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"Coins collected: {player.coins}");
    Console.WriteLine($"Hp left: {player.hp}");
    Map.AreaDrawer(player.row, player.col);
    ConsoleKey key = Console.ReadKey(true).Key;
    switch (key)
    {
        case ConsoleKey.W:
        case ConsoleKey.UpArrow:
            player.Move("up");
            break;
        case ConsoleKey.S:
        case ConsoleKey.DownArrow:
            player.Move("down");
            break;
        case ConsoleKey.A:
        case ConsoleKey.LeftArrow:
            player.Move("left");
            break;
        case ConsoleKey.D:
        case ConsoleKey.RightArrow:
            player.Move("right");
            break;
        case ConsoleKey.Escape:
            running = false;
            break;

    }
    char interaction = Map.StepOn(player.row, player.col);
    if (interaction == 'm')
    {
        player.AddCoin();
    }
    else if(interaction == 't')
    {
        player.ReduceHp();
    }

    if (player.coins == 3 || player.hp < 1)
    {
        string message = (player.coins == 3) ? "You win!" : "You died!"; 
        Console.WriteLine(message);
        Console.CursorVisible = true;
        running = AskPlayAgain();
        Console.CursorVisible = false;
        Map.AreaBuilder();
        player = new Player();
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