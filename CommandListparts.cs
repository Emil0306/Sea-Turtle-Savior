class CommandListParts : BaseCommand, ICommand
{
    private readonly CleaningMachine Machine;

    public CommandListParts(CleaningMachine machine)
    {
        Machine = machine;
        description = "List all required parts";
    }

    public void Execute(Context ctx, string cmd, string[] p)
    {
        if (!GuardEq(p, 0)) { ctx.Print("Usage: list"); return; }

        var parts = _machine.GetConstructionList();
        ctx.Print(string.Join(", ", parts));
    }
}
