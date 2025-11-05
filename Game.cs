/* Main class for launching the game
 */

class Game
{
  private bool IsRunning;

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
    registry.Register("collect", new CommandCollect());
    registry.Register("deadly", new CommandDeadly());
    registry.Register("show", new CommandShowInventory());
    registry.Register("sort", new CommandSort());
  }

  static void Main(string[] args)
  {
    Console.Clear();
    Startscreen start = new Startscreen();
    start.Startinformation();


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
}






