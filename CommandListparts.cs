using System;

class CommandListParts : BaseCommand, ICommand
{
    private readonly CleaningMachine _machine;

    public CommandListParts(CleaningMachine machine)
    {
        _machine = machine;
        description = "List all required parts";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (GuardEq(parameters, 0))
        {
            Console.WriteLine("Usage: list");
            return;
        }

        string[] parts = _machine.GetConstructionList();
        Console.WriteLine(string.Join(", ", parts));
    }
}
