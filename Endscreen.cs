using System.Net.Mail;

class EndScreen{
	// Atributes
	private bool win;
	private double endtime;
	private int pollutionmeterProgress;
	private int cleaningMachineProgress;

	// Constructors
	public EndScreen (bool win, TimeSpan endtime, int pollutionmeterProgress, int cleaningMachineProgress) {
		this.win = win;												// Won or lost?
		this.endtime = endtime.TotalMinutes; 						// Get current time from "Player"
		this.pollutionmeterProgress = pollutionmeterProgress; 		// Get pollution from "Pollutionmeter"
		this.cleaningMachineProgress = cleaningMachineProgress;		// Get cleaning machine progress from "CleaningMachine"
	}

	// Methods
	public bool EndInfo () {	// Display an endscreen with time, pollution and the cleaning machine progress
		Console.Clear();
		Console.WriteLine("You have "+(win==false ? "lost" : "won")+"!");
		Console.WriteLine("You finished in "+endtime+" minutes!");
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

		return false;
		//return Restart();
	}
	public bool Restart () {	// Restart game to be played again
		Console.WriteLine("What do you wish to do now: ");
		Console.WriteLine(" - restart");
		Console.WriteLine(" - quit");
		while (true) {
			Console.Write("> ");
			string? line = Console.ReadLine();
			if (line == "quit") return false;
			else if (line == "restart") return true;
			else Console.WriteLine("Woopsie, I don't understand '"+line+"'. Please write 'quit' or 'restart'. 😕");
		}
	}

}
