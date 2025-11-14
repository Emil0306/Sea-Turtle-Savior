
class CommandShowInventory : BaseCommand, ICommand {
	private Inventory inv;
		
	public CommandShowInventory(Inventory inv)
	{
		this.inv = inv;
		description = "Access your inventory trash list";
	}

	public void Execute (Context context, string command, string[] parameters) 
	{
	    if (GuardEq(parameters, 1)) {
		    Console.WriteLine("Error: Did you mean \"show inventory\"?");
		    return; 
		}
		if (parameters[0] == "inventory"){
			inv.GetInventory();
		}
		else
		{
			Console.WriteLine("Error: Did you mean \"show inventory\"?");
		}
	}
}