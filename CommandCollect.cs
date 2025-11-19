/* Command for collecting trash
 */

class CommandCollect : BaseCommand, ICommand {
    private Inventory inv;
    
    public CommandCollect (Inventory inv) {
        this.inv = inv;
        description = "Pick up trash (e.g. collect container)";
    }

    public void Execute (Context context, string command, string[] parameters) {
        if (GuardEq(parameters, 1)) {
            Console.WriteLine("Error: Did you mean \"collect NAME_OF_TRASH\"?");
            return;
        }
        
        for (int i = 0 ; i < Space.trashList.Length ; i++){
            if (Space.trashList[i].Name == parameters[0] && parameters[0] == Space.GetavailableTrash().Name){
                if (Space.GetavailableTrash().ForbiddenMaterial){
                    Pollutionmeter.StopTimer();
                    Game.SetWinLoss(false);
                    context.SetDone(true);
                    return;
                }
                bool a = inv.CollectTrash(Space.trashList[i]);
                if (a == false)
                {
                    Pollutionmeter.StopTimer();
                    Game.SetWinLoss(false);
                    context.SetDone(true);
                    return;
                }
                Space.SetavailableTrash(new Trash("No trash here", "", false));
                return;
            }
        }
        Console.WriteLine("Can't pick up '"+parameters[0]+"' here");
    }
}
