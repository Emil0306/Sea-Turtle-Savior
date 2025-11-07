using System;
using System.Linq;

class CommandAddMaterial : BaseCommand, ICommand
{
    private readonly CleaningMachine _machine;

    public CommandAddMaterial(CleaningMachine machine)
    {
        _machine = machine;
        description = "Add a material to the CleaningMachine";
    }

    public void Execute(Context ctx, string cmd, string[] p)
    {
        if (!GuardEq(p, 1))
        {
            Console.WriteLine("Usage: add <material>");
            return;
        }

        string result = _machine.AddMaterial(p[0]);
        Console.WriteLine(result);
    }
}
