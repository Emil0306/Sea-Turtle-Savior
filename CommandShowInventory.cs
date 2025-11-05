
class CommandShowInventory : BaseCommand, ICommand {

public CommandShowInventory(){
	description = "Access your inventory trash list";
}

public void Execute (Context context, string command, string[] parameters) 
{
    if (GuardEq(parameters, 1)) {
    Console.WriteLine("Error: Did you mean \"show inventory\"?");
    return; 
	}
	if (parameters[0] == "inventory"){

		Inventory inv = new Inventory();
		inv.GetInventory();
	}



}

}


