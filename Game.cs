/* Main class for launching the game
 */

class Game
{
  private bool IsRunning;

  static World world = new World();
  static Context context = new Context(world.GetEntry());
  static ICommand fallback = new CommandUnknown();
  static Registry registry = new Registry(context, fallback);
  
  static CleaningMachine machine = new CleaningMachine();

  private static void InitRegistry()
  {
    ICommand cmdExit = new CommandExit();
    registry.Register("exit", cmdExit);
    registry.Register("quit", cmdExit);
    registry.Register("bye", cmdExit);
    registry.Register("go", new CommandGo());
    registry.Register("help", new CommandHelp(registry));
    registry.Register("collect", new CommandCollect());
    registry.Register("deadly", new CommandDeadly());
    registry.Register("show", new CommandShowInventory());
    registry.Register("sort", new CommandSort());
    registry.Register("add",  new CommandAddMaterial(machine));
    registry.Register("list", new CommandListParts(machine));
    registry.Register("progress", new CommandProgress(machine));

  }

  static void Main(string[] args)
  {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.BackgroundColor = ConsoleColor.Black;
    Startscreen start = new Startscreen();
    start.Startinformation();
    Pollutionmeter.GetPollutionData();
    GameTimer.startimer();
    double time = GameTimer.readtimer();
    Console.WriteLine(time);
       
    InitRegistry();
    context.GetCurrent().Welcome();

    while (context.IsDone()==false)
    {
      Console.Write("> ");
      string? line = Console.ReadLine();
      if (line != null) registry.Dispatch(line);
    }
    Console.WriteLine("Game Over 😥");
  }

  public static void CheckWinCondition()
  { // Når både maskinen er bygget + pollution er 0
    if (machine.GetProgress() == 100 && Pollutionmeter.CurrentPollution() == 0)
    {
      Pollutionmeter.StopTimer();
      
      // mangeler noget som gør at der bliver vist at man vinder
    }
  }
}






