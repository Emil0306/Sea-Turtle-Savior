using System;

class CommandListParts : BaseCommand, ICommand
{
    private readonly CleaningMachine machine;

    public CommandListParts(CleaningMachine machine)
    {
        this.machine = machine;
        description = "List all required Machine_Parts";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (context.GetCurrent().GetName() == "Cleaning Machine"){
            if (GuardEq(parameters, 0))
            {
                Console.WriteLine("Usage: list");
                return;
            }

            string[] parts = machine.GetConstructionList();
            Console.WriteLine(string.Join(", ", parts));
        }
        else{ 
            Console.WriteLine("You are not at the Cleaning Machine");
        }
    }
}
