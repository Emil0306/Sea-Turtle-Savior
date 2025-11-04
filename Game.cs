/* Main class for launching the game
 */

class Game
{
  private bool IsRunning;
  private int pollutionMeter = 0;

  public void startStartScreen()
  {
    Start start = new Start();
    start.Game();
  }

  public void startGame()
  static void Main(string[] args)
    {
         Console.WriteLine("Welcome to Sea Turtle Savior!");

    InitRegistry();
    context.GetCurrent().Welcome();

    }
  
  
private int pollutionMeter = 0;
  public void updatePollutionMeter()
  {
    pollutionMeter = +1;
    Console.WriteLine($"pollution: {pollutionMeter}");
  }
  public void gamestatus()
  {
    if (pollutionMeter >= 100)
    {
      Console.WriteLine("The sea is too polluted");
      endGame();
    }
  }
  public void endGame()
    {
         while (context.IsRunning() )
      {
      Console.Write("> ");
      string? line = Console.ReadLine();
      if (line != null) registry.Dispatch(line);
       Console.WriteLine("Game Over ");

      }
  
    }
   

    
  
    
    
 
  static World world = new World();
  static Context context = new Context(world.GetEntry());
  static ICommand fallback = new CommandUnknown();
  static Registry registry = new Registry(context, fallback);

  private static void InitRegistry()
  {
    ICommand cmdExit = new CommandExit();
    registry.Register("exit", cmdExit);
    registry.Register("quit", cmdExit);
    registry.Register("bye", cmdExit);
    registry.Register("go", new CommandGo());
    registry.Register("help", new CommandHelp(registry));
  }

  static void Main(string[] args)
  {
    
    Console.WriteLine("Welcome to Sea Turtle Savior!");

    InitRegistry();
    context.GetCurrent().Welcome();

    while (context.IsRunning() )
    {
      Console.Write("> ");
      string? line = Console.ReadLine();
      if (line != null) registry.Dispatch(line);
    }
    Console.WriteLine("Game Over 😥");
  }
}






