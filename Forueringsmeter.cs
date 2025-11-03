
class ForueringsMeter2
{
    //atributtes

    private static Timer timer;
    private static int procent = 0;
    //constructor

    //Forueringsmeter

    public static void GetForueringsData()
    {
        timer = new Timer(1000);

        timer.Elapsed += Timer_Elapsed;

        timer.Enabled = true;
        Console.ReadLine();
    }
    private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (procent < 100)
        {
            procent += 1;
            Console.WriteLine($"Foureringsprocent: {procent}%");
        }
        else
        {
            Console.WriteLine("100% nået! gameover");
            timer.Stop();
        }
    }
}
