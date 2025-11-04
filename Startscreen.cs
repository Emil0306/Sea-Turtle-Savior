
class Startscreen
{
    //Attributes
    private DateTime startTime;

    //Constructor


    //Methods
    public void Startinformation()
    {
        Console.WriteLine("Blah blah info info about sea turtles amd stuff");
        Console.WriteLine();

        Console.WriteLine("Welcome to the game! Please Press 'k' to start the game : ");
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

