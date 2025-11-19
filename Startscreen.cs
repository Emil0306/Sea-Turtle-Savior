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
        Console.WriteLine("6 of the 7 sea turtle species are critically endangered, and only one in every 1,000 hatchlings survives to adulthood.");
        Console.WriteLine("Now it's up to you. Sea Turtle savoir. Build the Cleaning Machine. Clean the ocean. Restore harmony quickly, before the pollution levels get out of hand !!!");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Gray; 

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