/* Command for collecting trash
 */

class CommandCollect : BaseCommand, ICommand {
    public CommandCollect () {
        description = "Pick up trash";
    }

    public void Execute (Context context, string command, string[] parameters) {
        if (GuardEq(parameters, 1)) {
            Console.WriteLine("Thats weird 🤔");
            return;
        }

        // maybe make CollectTrash static and then remove myInv
        Inventory myInv = new Inventory();
        for (int i = 0 ; i < Space.trashList.Length ; i++){
            if (Space.trashList[i].Name == parameters[0] && parameters[0] == Space.availableTrash.Name){
                if (Space.availableTrash.ForbiddenMaterial == true){
                    context.MakeDone();
                    return;
                }
                bool a = myInv.CollectTrash(Space.trashList[i]);
                if (a == false) context.MakeDone();
                Space.availableTrash = new Trash("No trash here", "", false);
                return;
            }
        }
        Console.WriteLine("Can't pick up "+parameters[0]+" here");
    }
}
