namespace SeaTurtleSavior;

class CommandProgress : BaseCommand, ICommand
{
    private readonly CleaningMachine machine;

    public CommandProgress(CleaningMachine machine)
    {
        this.machine = machine;
        description = "Show current build progress in percent";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (context.GetCurrent().GetName() == "Cleaning Machine"){
            if (GuardEq(parameters, 0))
            {
                Console.WriteLine("Usage: progress");
                return;
            }
            Console.WriteLine($"{machine.GetProgress()}%");
        }
        else {
            Console.WriteLine("You are not at the Cleaning Machine");
        }
    }
}