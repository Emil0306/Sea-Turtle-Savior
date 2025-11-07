
class CommandSort : BaseCommand, ICommand {

	public CommandSort(){
		description = "Sort and recycle your trash";
		
	}

	public void Execute (Context context, string command, string[] parameters){

	if (context.GetCurrent().GetName() == "WasteStation"){
		if (GuardEq(parameters, 2)) {
    		Console.WriteLine("Please specify the trash item and its corresponding recycling container");
    		return; 
		}
		WasteStation myWasteStation = new WasteStation();
		Inventory inv = new Inventory();

		//int containerNumber = int.Parse(parameters[1]);
		int containerNumber;
		bool isInt = int.TryParse(parameters[1], out containerNumber);
		if (isInt){
			myWasteStation.SortTrash(inv, inv.FindObj(parameters[0]), containerNumber);
		}
		if (isInt == false){
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.WriteLine("The number '"+ parameters[1]+"' is invalid. Container numbers must be a single digit from 0 to 8.");
			Console.ForegroundColor = ConsoleColor.White;
		}


		
	}
	else {
			Console.WriteLine("You are not at the Waste Station");
		}
	

	}
}
//parameters[0] = skraldet feks. cykel
//parameters[1] = container nummer feks. 2

// command = sort 
