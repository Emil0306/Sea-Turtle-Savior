using System.Net.Mail;

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
		DateTime endTime = DateTime.Now;
		TimeSpan playtime = TimeSpan.FromSeconds(endtime);
		Console.WriteLine("You have "+(win==false ? "lost" : "won")+"!");
		Console.WriteLine("You finished in "+endtime+" seconds!");
		Console.Write("The pollutionmeter has reached: ");
		if (pollutionmeterProgress == 0){
			Console.ForegroundColor = ConsoleColor.Green;
		} else{
			Console.ForegroundColor = ConsoleColor.Red;
		}
		Console.Write((pollutionmeterProgress)+"%"); // Vi skal lige få fixede procenttallet - Hans
		Console.ForegroundColor = ConsoleColor.Gray;
		Console.Write(" And you are: ");
		if (cleaningMachineProgress == 1){
			Console.ForegroundColor = ConsoleColor.Green;
		} else if (cleaningMachineProgress < 1 && cleaningMachineProgress >= 0.50){
			Console.ForegroundColor = ConsoleColor.Yellow;
		} else {
			Console.ForegroundColor = ConsoleColor.Red;
		}
		Console.Write((cleaningMachineProgress*100)+"%");
		Console.ForegroundColor = ConsoleColor.Gray;
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
