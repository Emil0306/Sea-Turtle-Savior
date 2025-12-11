namespace SeaTurtleSavior;

class Startscreen
{
    //Attributes
    private DateTime startTime;

    //Methods
    public void Startinformation()
    {
        Console.ForegroundColor = ConsoleColor.Cyan; 
        Console.WriteLine("Sea turtles, have been navigating Earth's oceans since the age of the dinosaurs.");
        Console.WriteLine("Currently, the very existence of sea turtles is greatly threatened by man-made pollution.");
        Console.WriteLine("6 of the 7 sea turtle species are critically endangered, and only one in every 1,000 sea turtles survives to adulthood.");
        Console.WriteLine("You are the Sea Turtle Savior, it's up to you to act fast! Clean the ocean and build the Cleaning Machine to restore harmony before the pollution levels get out of hand!");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[How To Play]");
        Console.WriteLine("- Use the arrowkeys to move");
        Console.WriteLine("- Pick up trash by swimming into it, but be aware of the dsngerous trash marked by  '\u2620\uFE0E'.");
        Console.WriteLine("- To move to a differnet location, swim into the sides of the map marked with an direction.\n");
        Console.ResetColor();
        
        Console.WriteLine(" 🐢 WELCOME TO SEATURTLE SAVIOR 🐢 Press 'k' to start the game! : ");
        
        while (Console.ReadKey(true).Key != ConsoleKey.K)
        {
            
        }
        startTime = DateTime.Now;
    }

    public DateTime GetStartTime()
    {
        return startTime;
    }
}