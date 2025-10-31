class Test {
	public static void Main (string[] args) {
		bool donedone = false;
		while (donedone == false){
			EndScreen end = new EndScreen(true, 200, 0, 0.20);
			donedone = end.EndInfo();
		}
	}
}

class EndScreen{
	// Atributes
	private bool win;
	private double endtime;
	private double pollutionmeterProgress;
	private double cleaningMachineProgress;

	// Constructors
	public EndScreen (bool win, double endtime, double pollutionmeterProgress, double cleaningMachineProgress) {
		this.win = win;												// Won or lost?
		this.endtime = endtime; 									// Get current time from "Player"
		this.pollutionmeterProgress = pollutionmeterProgress; 		// Get pollution from "Pollutionmeter"
		this.cleaningMachineProgress = cleaningMachineProgress;		// Get cleaning machine progress from "CleaningMachine"
	}

	// Methods
	public bool EndInfo () {	// Display an endscreen with time, pollution and the cleaning machine progress
		Console.Clear();
		Console.WriteLine("You have "+(win==false ? "lost" : "won")+"!");
		Console.WriteLine("You finnished in "+endtime+" seconds!");

		Console.Write("The pollutionmeter has reached: ");
		if (pollutionmeterProgress == 0){
			Console.ForegroundColor = ConsoleColor.Green;
		} else{
			Console.ForegroundColor = ConsoleColor.Red;
		}
		Console.Write((pollutionmeterProgress*100)+"%");
		Console.ForegroundColor = ConsoleColor.White;
		Console.Write(" And you are: ");
		if (cleaningMachineProgress == 1){
			Console.ForegroundColor = ConsoleColor.Green;
		} else if (cleaningMachineProgress < 1 && cleaningMachineProgress >= 0.50){
			Console.ForegroundColor = ConsoleColor.Yellow;
		} else {
			Console.ForegroundColor = ConsoleColor.Red;
		}
		Console.Write((cleaningMachineProgress*100)+"%");
		Console.ForegroundColor = ConsoleColor.White;
		Console.WriteLine(" done with the cleaning machine");


		return Restart();
	}
	public bool Restart () {	// Restart game to be played again
		Console.WriteLine("What do you wish to do now: ");
		Console.WriteLine(" - restart");
		Console.WriteLine(" - quit");
		while (true) {
			Console.Write("> ");
			string? line = Console.ReadLine();
			if (line == "quit") return true;
			else if (line == "restart") return false;
			else Console.WriteLine("Woopsie, I don't understand '"+line+"' 😕");
		}
	}

}
