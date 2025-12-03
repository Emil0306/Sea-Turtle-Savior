namespace SeaTurtleSavior.Commands;

class CommandShield : BaseCommand, ICommand
{
    public CommandShield()
    {
        description = "Show's how many shields you left";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (GuardEq(parameters, 0))
        {
            Console.WriteLine("Usage: shield");
            return;
        }
        Console.WriteLine("You got "+Game.GetShield()+(Game.GetShield() == 1 ? " shield" : " shields"));
    }
}