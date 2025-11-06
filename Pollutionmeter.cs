using System.Timers;

class Pollutionmeter
{
    //atributtes

    private static PollutionMeterVisual pollutionmeter = new PollutionMeterVisual ();

    private static System.Timers.Timer timer; // from Timer class
    private static int procent = 50;
    //constructor

    // Methods

    public static void GetPollutionData()
    {
        timer = new System.Timers.Timer(1000); // 1000 = 1 second

        timer.Elapsed += Timer_Elapsed;

        timer.Enabled = true;
        
    }
    private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (procent < 100)
        {
            procent += 1;
            pollutionmeter.IncreasePollution(1);
            Console.WriteLine($"Pollution procent: {procent}%");
        }
        else
        {
            Console.WriteLine("100% reached! gameover");
            timer.Stop();
        }
    }
}


class PollutionMeterVisual
{
    int pollution = 0;
    int maxPollution = 100;

    // Metode til når tiden går = stigning af pollution
    public void IncreasePollution(int amount)
    {
        pollution = pollution + amount;
        if (pollution > maxPollution)
        {
            pollution = maxPollution;
        }
        ShowPollution();
    }

    // Metode til når man samler skrald = fald af pollution
    public void DecreasePollution(int amount)
    {
        pollution = pollution - amount;
        if (pollution < 0)
        {
            pollution = 0;
        }
        ShowPollution();
    }

    // Pollution meter visuelt:
    public void ShowPollution()
    {
        int barLength = 20;
        int filled = pollution * barLength / maxPollution;

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

        int percent = pollution * 100 / maxPollution;
        Console.WriteLine("Pollution: [" + bar + "] " + pollution + "/" + maxPollution + " (" + percent + "%)");
    }
}



