using System.Timers;

namespace SeaTurtleSavior;

class Pollutionmeter
{
    // attributes
    private static Pollutionmeter pollutionmeter = new Pollutionmeter ();
    private static int maxPollution = 100;
    private static System.Timers.Timer timer;
    private static int procent;
    
    // Methods
    public static void StartPollutionMeter()
    {
        procent = 50;
        timer = new System.Timers.Timer(10000); // in milliseconds
        timer.Elapsed += Timer_Elapsed;
        timer.Enabled = true;
    }
    private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (procent < maxPollution)
        {
            pollutionmeter.ChangePollution(1);
        }
        Game.CheckWinCondition();
    }

    public bool ChangePollution(int amount)
    {
        int left = Console.CursorLeft;
        int top = Console.CursorTop;
        
       
        if (procent > maxPollution)
        {
            procent = maxPollution;
            return false;
        }
        if (procent < 0)
        {
            procent = 0;
            return false;
        }
        procent = procent + amount;
        // Put cursor at top
        Console.SetCursorPosition(0, 0);
        Console.Write(ShowPollution());
        
        // Put cursor back to its original place
        Console.SetCursorPosition(left, top);
        return true;
    }
    
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

    public static int CurrentPollution()
    {
        return procent;
    }

    public static void StopTimer()
    {
        timer.Stop();
    }
}