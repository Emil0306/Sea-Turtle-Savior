using System;

class CommandAddMaterial : BaseCommand, ICommand
{
    private readonly CleaningMachine _machine;
    private Inventory inv;

    public CommandAddMaterial(CleaningMachine machine, Inventory inv)
    {
        _machine = machine;
        this.inv = inv;
        description = "Add a material to the CleaningMachine";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (context.GetCurrent().GetName() == "Cleaning Machine"){
            if (GuardEq(parameters, 1))
            {
                Console.WriteLine("Usage: add <material>");
                return;
            }

            string result = _machine.AddMaterial(parameters[0], inv);
            Console.WriteLine(result);
        }
        else {
            Console.WriteLine("You are not at the Cleaning Machine");
        }
    }
}

