namespace SeaTurtleSavior.Commands;

class CommandCoins : BaseCommand, ICommand
{
    public CommandCoins()
    {
        description = "Show's how many coins you got. Hint: you get coins by sorting trash";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (GuardEq(parameters, 0))
        {
            Console.WriteLine("Usage: coins");
            return;
        }
        Console.WriteLine("You got "+Game.GetCoins()+(Game.GetCoins() == 1 ? " coin" : " coins"));
    }
}