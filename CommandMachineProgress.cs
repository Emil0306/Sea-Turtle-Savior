using System;

class CommandProgress : BaseCommand, ICommand
{
    private readonly CleaningMachine _machine;

    public CommandProgress(CleaningMachine machine)
    {
        _machine = machine;
        description = "Show current build progress in percent";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (GuardEq(parameters, 0))
        {
            Console.WriteLine("Usage: progress");
            return;
        }

        Console.WriteLine($"{_machine.GetProgress()}%");
    }
}
