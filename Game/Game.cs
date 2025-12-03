/* Main class for launching the game
 */


using System.Runtime.CompilerServices;

namespace SeaTurtleSavior;

class Game
{
    private static bool winloss = false;
    private static bool isRunning = true;
    private static string endMessage = "";
    private static int coins = 0;
    private static int shield = 0;

    static Startscreen start = new Startscreen();
    static World world = new World();
    static Context context = new Context(world.GetEntry());
    static ICommand fallback = new CommandUnknown();
    static Registry registry = new Registry(context, fallback);
    static CleaningMachine machine = new CleaningMachine();
    static Inventory inv = new Inventory();

    public static Inventory GetInv()
    {
        return inv;
    }

    public static int GetShield()
    {
        return shield;
    }

    public static void SetShield(int newshield)
    {
        shield = newshield;
    }
    public static int GetCoins()
    {
        return coins;
    }

    public static void SetCoins(int newcoins)
    {
        coins = newcoins;
    }
    
    public static void SetWinLoss(bool status)
    {
        winloss = status;
    }


    private static void InitRegistry()
    {
        coins = 0;
        shield = 0;
        world = new World();
        context = new Context(world.GetEntry());
        fallback = new CommandUnknown();
        registry = new Registry(context, fallback);
        machine = new CleaningMachine();
        inv = new Inventory();
        registry.Register("quit", new CommandExit());
        registry.Register("help", new CommandHelp(registry));
        registry.Register("deadly", new CommandDeadly());
        registry.Register("show", new CommandShowInventory(inv));
        registry.Register("sort", new CommandSort(inv));
        registry.Register("add", new CommandAddMaterial(machine, inv));
        registry.Register("list", new CommandListParts(machine));
        registry.Register("progress", new CommandProgress(machine));
        registry.Register("upgrade", new CommandUpgrade(inv));
        registry.Register("coins", new CommandCoins());
        registry.Register("shield", new CommandShield());
    }



    static string? ReadInput()
    {
        string input = "";
        while (true)
        {
            if (context.GetDone()) return "";
            Pollutionmeter.GetPollutionMeter().ChangePollution(0);
            ConsoleKeyInfo key = Console.ReadKey(true);
            //haandtere piletasterne

            if (key.Key == ConsoleKey.UpArrow)
            {
                if (context.MovePlayer("up"))
                {
                    context.Redraw();
                }
                else if (context.GetPlayerY() == 0 && context.GetCurrent().GetExits().Contains("north"))
                {
                    context.Transition("north");
                }
                else if (context.GetPlayerY() == 0 && !context.GetCurrent().GetExits().Contains("north"))
                {
                    continue;
                }
                Console.Write("> "+input);
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (context.MovePlayer("down"))
                {
                    context.Redraw();
                }
                else if (context.GetPlayerY() == 8 && context.GetCurrent().GetExits().Contains("south"))
                {
                    context.Transition("south");
                }
                else if (context.GetPlayerY() == 8 && !context.GetCurrent().GetExits().Contains("south"))
                {
                    continue;
                }
                Console.Write("> "+input);
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                if (context.MovePlayer("left"))
                {
                    context.Redraw();
                }
                else if (context.GetPlayerX() == 0 && context.GetCurrent().GetExits().Contains("west"))
                {
                    context.Transition("west");
                }
                else if (context.GetPlayerX() == 0 && !context.GetCurrent().GetExits().Contains("west"))
                {
                    continue;
                }
                Console.Write("> "+input);
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                if (context.MovePlayer("right"))
                {
                    context.Redraw();
                }
                else if (context.GetPlayerX() == 8 && context.GetCurrent().GetExits().Contains("east"))
                {
                    context.Transition("east");
                }
                else if (context.GetPlayerX() == 8 && !context.GetCurrent().GetExits().Contains("east"))
                {
                    continue;
                }
                Console.Write("> "+input);
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                return input;
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                if (input.Length > 0)
                {
                    input = input.Substring(0, input.Length - 1);
                    Console.Write("\b \b"); // Sletter det sidste tegn i konsollen
                }
            }
            else if (!char.IsControl(key.KeyChar))
            {
                input += key.KeyChar;
                Console.Write(key.KeyChar);
            }
        }
    }

    static void Main(string[] args)
    {
        while (isRunning)
        {
            //Reset game state
            InitRegistry();
            context.SetDone(false);
            Console.Clear();
            //Start game Display instructions
            start.Startinformation();
            //Starrt Pollutionmeter
            Pollutionmeter.StartPollutionMeter();
            //Generate map and place player
            context.GetCurrent().Welcome(context,false);
            //gameplay loop
            while (context.GetDone() == false)
            {
                Console.Write("> ");
                string? line = ReadInput();
                if (line != null) registry.Dispatch(line);
            }
            //if win or loss display endscreen
            DateTime endtime = DateTime.Now;
            TimeSpan res = endtime.Subtract(start.GetStartTime());
            EndScreen endScreen = new EndScreen(winloss, res, Pollutionmeter.CurrentPollution(), machine.GetProgress(), endMessage);
            isRunning = endScreen.EndInfo();
        }
    }

    public static void CheckWinCondition()
    {
        if (machine.GetProgress() == 100 || Pollutionmeter.CurrentPollution() == 0)
        {
            EndGame(true, "");
        } 
        if (Pollutionmeter.CurrentPollution() >= 100)
        {
            EndGame(false, "Cause of death: Pollution reached 100 %");
        }
    }

    public static void EndGame(bool status, string msg)
    {
        Pollutionmeter.StopTimer();
        endMessage = msg;
        winloss = status;
        context.SetDone(true);
    }
}
