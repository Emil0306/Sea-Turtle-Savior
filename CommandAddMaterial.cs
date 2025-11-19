using System;

class CommandAddMaterial : BaseCommand, ICommand
{
    private readonly CleaningMachine machine;
    private Inventory inv;

    public CommandAddMaterial(CleaningMachine machine, Inventory inv)
    {
        this.machine = machine;
        this.inv = inv;
        description = "Add Material to CleaningMachine(e.g. add motor)";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (context.GetCurrent().GetName() == "Cleaning Machine"){
            if (GuardEq(parameters, 1))
            {
                Console.WriteLine("Usage: add <material>");
                return;
            }
            string result = machine.AddMaterial(parameters[0], inv);
            Console.WriteLine(result);
        }
        else {
            Console.WriteLine("You are not at the Cleaning Machine");
        }
    }
}