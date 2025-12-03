namespace SeaTurtleSavior;

class CommandSort : BaseCommand, ICommand {
	private Inventory inv;
	
	public CommandSort(Inventory inv){
		this.inv = inv;
		description = "Sort and recycle your trash (e.g. sort can Metal)";
	}

	public void Execute (Context context, string command, string[] parameters){
		if (context.GetCurrent().GetName() == "WasteStation"){
			if (GuardEq(parameters, 2)) {
				Console.WriteLine("Please specify the trash item and its corresponding recycling container");
				return; 
			}
			WasteStation myWasteStation = new WasteStation();
			myWasteStation.SortTrash(inv, inv.FindObj(parameters[0]), parameters[1]);
			InformationPrinter infoPrinter = new InformationPrinter();
			infoPrinter.PrintInfoMsg(infoPrinter.GetSortPrinter());
		}
		else{ 
			Console.WriteLine("You are not at the Waste Station");
		}
	}
}
// parameters[0] = trash item like: plastic_bottle
// parameters[1] = container number like: Metal
// command = sort
