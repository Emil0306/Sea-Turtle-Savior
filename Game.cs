/* Main class for launching the game
 */

namespace SeaTurtleSavior;

class Game
{
    private static bool winloss = false;
    private static bool isRunning = true;

    static World world = new World();
    static Context context = new Context(world.GetEntry());
    static ICommand fallback = new CommandUnknown();
    static Registry registry = new Registry(context, fallback);
    static CleaningMachine machine = new CleaningMachine();
    static Inventory inv = new Inventory();

    public static void SetWinLoss(bool status)
    {
        winloss = status;
    }

    private static void InitRegistry()
    {
        world = new World();
        context = new Context(world.GetEntry());
        fallback = new CommandUnknown();
        registry = new Registry(context, fallback);
        machine = new CleaningMachine();
        inv = new Inventory();
        registry.Register("quit", new CommandExit());
        registry.Register("go", new CommandGo());
        registry.Register("help", new CommandHelp(registry));
        registry.Register("collect", new CommandCollect(inv));
        registry.Register("deadly", new CommandDeadly());
        registry.Register("show", new CommandShowInventory(inv));
        registry.Register("sort", new CommandSort(inv));
        registry.Register("add",  new CommandAddMaterial(machine, inv));
        registry.Register("list", new CommandListParts(machine));
        registry.Register("progress", new CommandProgress(machine));
    }

    static void Main(string[] args)
    { 
        while (isRunning)
        {
            InitRegistry();
            context.SetDone(false);
            Console.Clear();
            Startscreen start = new Startscreen();
            start.Startinformation();
            Pollutionmeter.StartPollutionMeter();
            context.GetCurrent().Welcome();
            while (context.GetDone() == false)
            {
                Console.Write("> ");
                string? line = Console.ReadLine();
                if (line != null) registry.Dispatch(line);
            }

            DateTime endtime = DateTime.Now;
            TimeSpan res = endtime.Subtract(start.GetStartTime());
            EndScreen endScreen = new EndScreen(winloss, res, Pollutionmeter.CurrentPollution(), machine.GetProgress());
            isRunning = endScreen.EndInfo();
        }
    }

    public static void CheckWinCondition()
    {
        if (machine.GetProgress() == 100 || Pollutionmeter.CurrentPollution() == 0)
        {
            Pollutionmeter.StopTimer();
            winloss = true;
            context.SetDone(true);
        }
        else if (Pollutionmeter.CurrentPollution()==100)
        {
            Pollutionmeter.StopTimer();
            winloss = false;
            context.SetDone(true);
        }
    }
}