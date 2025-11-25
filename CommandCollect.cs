/* Command for collecting trash
 */

namespace SeaTurtleSavior;

class CommandCollect : BaseCommand, ICommand {
    private Inventory inv;
    
    public CommandCollect (Inventory inv) {
        this.inv = inv;
        description = "Pick up trash (e.g. collect food wrapper)";
    }

    public void Execute (Context context, string command, string[] parameters) {
        if (GuardEq(parameters, 1)) {
            Console.WriteLine("Error: Did you mean \"collect TRASH NAME\"?");
            return;
        }

        for (int i = 0 ; i < Space.GetTrashList().Length ; i++){
            if (Space.GetTrashList()[i].GetName() == parameters[0] && parameters[0] == Space.GetavailableTrash().GetName()){
                if (Space.GetavailableTrash().GetForbiddenMaterial()){
                    Pollutionmeter.StopTimer();
                    Game.SetWinLoss(false);
                    context.SetDone(true);
                    return;
                }
                bool a = inv.CollectTrash(Space.GetTrashList()[i]);
                
                if (a == false)
                {
                    Pollutionmeter.StopTimer();
                    Game.SetWinLoss(false);
                    context.SetDone(true);
                    return;
                }
                
                Space.SetavailableTrash(new Trash("No trash here", "", false));
                InformationPrinter printer = new InformationPrinter();
                printer.PrintInfoMsg(printer.GetTrashPrinter());
                return;
            }
        }
        Console.WriteLine("Can't pick up '"+parameters[0]+"' here");
    }
}