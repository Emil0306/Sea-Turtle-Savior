using System;
using System.Diagnostics;

public static class GameTimer
{
    //Attributes
    public static Stopwatch stopwatch;

    //methods

    public static void startimer()
    {
    GameTimer.stopwatch = new Stopwatch();
         stopwatch.Start();
    }

    public static void stoptimer()
    {
        stopwatch.Stop();
    }

    public static double readtimer() // Vi returner med sekunder ikke milliseconder; class fungere kun med Milliseconds
    {
        return stopwatch.ElapsedMilliseconds / 1000;
    }

}
