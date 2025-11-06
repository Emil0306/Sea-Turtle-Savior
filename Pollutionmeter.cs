using System.Timers;

class Pollutionmeter
{
    //atributtes

    private static System.Timers.Timer timer; // from Timer class
    private static int procent = 50;
    //constructor

    // Methods

    public static void GetPollutionData()
    {
        timer = new System.Timers.Timer(30000); // 1000 = 1 second

        timer.Elapsed += Timer_Elapsed;

        timer.Enabled = true;
        
    }
    private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (procent < 100)
        {
            procent += 1;
            Console.WriteLine($"Pollution procent: {procent}%");
        }
        else
        {
            Console.WriteLine("100% reached! gameover");
            timer.Stop();
        }
    }
}
