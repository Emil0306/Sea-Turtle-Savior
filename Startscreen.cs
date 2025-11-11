
class Startscreen
{
    //Attributes
    private DateTime startTime;

    //Constructor


    //Methods
    public void Startinformation()
    {
        Console.WriteLine("Sea turtles have swum Earth’s oceans since the age of dinosaurs. Now, they face extinction from human impact. But there’s still hope and that hope is you. Build the Cleaning Machine. CLean the ocean. Restore harmony.");
        Console.WriteLine();

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

