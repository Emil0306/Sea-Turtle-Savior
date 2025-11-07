class CommandProgress : BaseCommand, ICommand
{
    private readonly CleaningMachine Machine;

    public CommandProgress(CleaningMachine machine)
    {
        Machine = machine;
        description = "Show current build progress in percent";
    }

    public void Execute(Context ctx, string cmd, string[] p)
    {
        if (!GuardEq(p, 0)) { ctx.Print("Usage: progress"); return; }

        ctx.Print($"{_machine.GetProgress()}%");
    }
}
