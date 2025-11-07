using System.Timers;

class Pollutionmeter
{
    //atributtes

    private static Pollutionmeter pollutionmeter = new Pollutionmeter ();

    private static int maxPollution = 100; // Vi skal have linkede op - Hans

    private static System.Timers.Timer timer; // from Timer class
    private static int procent = 50;
    //constructor

    // Methods

    public static void GetPollutionData()
    {
        timer = new System.Timers.Timer(50000); // 1000 = 1 second

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
        procent = procent + amount;
        if (procent > maxPollution)
        {
            procent = maxPollution;
        }
        ShowPollution();
    }

    // Metode til når man samler skrald = fald af pollution
    public void DecreasePollution(int amount)
    {
        procent = procent - amount;
        if (procent < 0)
        {
            procent = 0;
        }
        ShowPollution();
    }

    // Pollution meter visuelt:
    public void ShowPollution()
    {
        int barLength = 20;
        int filled = procent * barLength / maxPollution;

        string bar = "";
        int i = 0;
        while (i < filled)
        {
            bar = bar + "#";
            i = i + 1;
        }
        while (i < barLength)
        {
            bar = bar + "-";
            i = i + 1;
        }

        int percent = procent * 100 / maxPollution;
        Console.WriteLine("Pollution: [" + bar + "] " + procent + "/" + maxPollution + " (" + procent + "%)");
    }
}



