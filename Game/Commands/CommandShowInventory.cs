namespace SeaTurtleSavior.Commands;

class CommandShowInventory : BaseCommand, ICommand {
	private Inventory inv;
		
	public CommandShowInventory(Inventory inv)
	{
		this.inv = inv;
		description = "View your inventory trash list (use: show inventory)";
	}

	public void Execute (Context context, string command, string[] parameters) 
	{
		if (GuardEq(parameters, 1)) {
			Console.WriteLine("Error: Did you mean \"show inventory\"?");
			return; 
		}
		if (parameters[0] == "inventory" || parameters[0] == "inv"){
			inv.GetInventory();
		}
		else
		{
			Console.WriteLine("Error: Did you mean \"show inventory\"?");
		}
	}
}