using System.Timers;

class Pollutionmeter
{
    //atributtes

    private static Pollutionmeter pollutionmeter = new Pollutionmeter ();

    private static int maxPollution = 100;

    private static System.Timers.Timer timer; // from Timer class
    private static int procent = 50;
    //constructor

    // Methods

    public static void GetPollutionData()
    {
        timer = new System.Timers.Timer(10000); // 1000 = 1 second

        timer.Elapsed += Timer_Elapsed;

        timer.Enabled = true;
        
    }
    private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (procent < maxPollution)
        {
            pollutionmeter.IncreasePollution(1);
        }
        else
        {
            timer.Stop();
            EndScreen endscreen = new EndScreen(false, GameTimer.readtimer(), procent, 0.5); //ToDo få CleaningMachine.GetProgress til at fungere
            endscreen.EndInfo();
        }
    }

    // Metode til når tiden går = stigning af pollution
    public void IncreasePollution(int amount)
    {
        int left = Console.CursorLeft; // method fra library
        int top = Console.CursorTop; // method fra library
        
        procent = procent + amount;
        if (procent > maxPollution)
        {
            procent = maxPollution;
        }
        
        Console.SetCursorPosition(0, 0);
        Console.Write(ShowPollution());
        
        // gør at man skriver i bunden igen
        Console.SetCursorPosition(left, top); //method fra library
    }

    // Metode til når man samler skrald = fald af pollution
    public void DecreasePollution(int amount)
    {
        int left = Console.CursorLeft; // method fra library
        int top = Console.CursorTop; // method fra library
        
        procent = procent - amount;
        if (procent < 0)
        {
            procent = 0;
        }

        Console.SetCursorPosition(0, 0);
        Console.Write((ShowPollution()));
        
        // gør at man skriver i bunden igen
        Console.SetCursorPosition(left, top); //method fra library
        
        Game.CheckWinCondition(); // tjekker om spilleren har vundet (pollution = 0 og machine 100%)
    }

    // Pollution meter visuelt:
    public string ShowPollution()
    {
        int barLength = 20;
        int filled = procent * barLength / maxPollution;

        string bar = "";
        
        int i = 0;
        while (i < filled)
        {
            bar += "#";
            i++;
        }
        while (i < barLength)
        {
            bar += "-";
            i++;
        }
        
        Console.SetCursorPosition(0, 0);
        return "Pollution: [" + bar + "] " + procent + "/" + maxPollution + " (" + procent + "%)";
    }

    public static int CurrentPollution() // til når man vinder
    {
        return procent;
    }

    public static void StopTimer() // stop timer når man vinder
    {
        timer.Stop();
    }
}



