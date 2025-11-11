
class Startscreen
{
    //Attributes
    private DateTime startTime;

    //Constructor


    //Methods
    public void Startinformation()
    {
            Console.ForegroundColor = ConsoleColor.Blue; 
        Console.WriteLine("Sea Turtles have romead Earths oceans for 150 million years");
        Console.WriteLine("Now, at present day, Sea Turtles very existence is threathed by man-made pollution.");
        Console.WriteLine("6 out of 7 turtle species are criticality indangered. It said that only 1 out of every 1000 sea turles makes it to adult hood");
        Console.WriteLine("Now it's up to you. Sea Turtle savoir. Build the Cleaning Machine. Clean the ocean. Restore harmony!");
        Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray; 

        Console.WriteLine(" 🐢 Welcome to SEATURTLE SAVIOR 🐢 Please press 'k' to start the game : ");
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

