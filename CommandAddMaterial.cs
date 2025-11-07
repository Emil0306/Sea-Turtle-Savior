class CommandAddMaterial : BaseCommand, ICommand
{
    private readonly CleaningMachine Machine;

    public CommandAddMaterial(CleaningMachine machine)
    {
        Machine = machine;
        description = "Add a material to the CleaningMachine";
    }

    public void Execute(Context ctx, string cmd, string[] p)
    {
        if (!GuardEq(p, 1)) { ctx.Print("Usage: add <material>"); return; }

        string result = _machine.AddMaterial(p[0]);
        ctx.Print(result);
    }
}
