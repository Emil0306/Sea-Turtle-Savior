/* Space class for modeling spaces (rooms, caves, ...)
 */

class Space : Node {
  public static Trash[] trashList = new Trash[18]{ // change to private and add getters
    new Trash("plastic_bottle", "Plastic", false),
    new Trash("food_wrapper", "Plastic", false),
    new Trash("syringe", "Plastic", true),
    new Trash("car_tire", "Plastic", false),
    new Trash("pesticide_container", "Plastic", true),
    new Trash("motor", "Metal", false),
    new Trash("container", "Plastic", false),
    new Trash("filter", "Plastic", false),
    new Trash("metal_frame", "Metal", false),
    new Trash("solar_panel", "Electronics", false),
    new Trash("banana_peel", "Organic", false),
    new Trash("phone", "Electronics", true),
    new Trash("aa_battery", "Batteries", true),
    new Trash("car_battery", "Batteries", true),
    new Trash("t-shirt", "Textile", false),
    new Trash("wood_plank", "Wood", false),
    new Trash("glass_bottle", "Glass", false),
    new Trash("can", "Metal", false)
  };
  private static Trash availableTrash = new Trash("No trash here", "", false);
  private HashSet<string> exits;

  public static Trash GetavailableTrash (){
    return availableTrash;
  }
  public static void SetavailableTrash (Trash trash){
    availableTrash = trash;
  }

  private void SetExits()
  {
      exits = edges.Keys.ToHashSet();
  }

  public HashSet<string> GetExits()
  {
      return exits;
  }

  public Space (String name) : base(name)
  {
  }
  
  public void Welcome () {
    Console.Clear();
    SetExits();

    Pollutionmeter pollution = new Pollutionmeter();
    Console.WriteLine(pollution.ShowPollution());
    
    
    if (name == "Harbor" || name == "Cleaning Machine" || name == "WasteStation"){
      availableTrash = new Trash("No trash here", "", false);
      Console.WriteLine(MakeMaps(exits));
    }

    if (name == "WasteStation")
    {
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.Write("Instructions:\nType '");

      Console.ForegroundColor = ConsoleColor.Blue;
      Console.Write("help");

      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.Write("' to view options, then use '");

      Console.ForegroundColor = ConsoleColor.Blue;
      Console.Write("sort");

      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.Write("' ");

        Console.WriteLine("\nHere are the types of containers you can sort your waste into:");
            Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("[Plastic] ");
            Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("[Glass] ");
            Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("[Metal] ");
            Console.ForegroundColor = ConsoleColor.White;
        Console.Write("[Paper] ");
            Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("[Organic] ");
            Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("[Electronics] ");
            Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("\n[Batteries] ");
            Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("[Textile] ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("[Wood]");
            Console.ResetColor();
    }

    else if (name == "Harbor")
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Important instructions:\nType '");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("help");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("' to view commands menu, '");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("go");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("' to move direction, \n'");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("deadly");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("' to check lethal items, and '");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("collect");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("' to pick up items.\n");

        Console.ResetColor();
        Console.WriteLine("You are now at Harbor: \neast ➡️ Cleaning Machine, west ➡️ WasteStation");

      }

      else if (name == "Cleaning Machine")
      {
          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.Write("Instructions:\nType '");

          Console.ForegroundColor = ConsoleColor.Blue;
          Console.Write("help");

          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.Write("' to view options, then use '");

          Console.ForegroundColor = ConsoleColor.Blue;
          Console.Write("list");

          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.Write("' '");

          Console.ForegroundColor = ConsoleColor.Blue;
          Console.Write("progress");

          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.Write("' or '");

          Console.ForegroundColor = ConsoleColor.Blue;
          Console.Write("add");

          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.Write("'for your next action.\n");

          Console.ResetColor();
        }

    else {
      Random rng = new Random();
      int randomNumber = rng.Next(0, trashList.Length);
      availableTrash = trashList[randomNumber];
      Console.Write(MakeMaps(exits)); // change to other method
      Console.WriteLine("Trash: "+availableTrash.Name);
    }
    if (name != "Harbor")
    {
    Console.WriteLine("You are now at "+name);
    }
    Console.WriteLine("Current exits are:");
    foreach (String exit in exits) {
      Console.WriteLine(" - "+exit);
    }
  }
  
  public void Goodbye () {
  }
  
  public override Space FollowEdge (string direction) {
    return (Space) (base.FollowEdge(direction));
  }

  public string MakeMaps(HashSet<string> exits) {
    int mapSize = 9;
    string makemap = "";
    if (exits.Contains("north")){
        for (int i = 0 ; i<((mapSize*3)/2)+5 ; i++){
            makemap += " ";
        }
        makemap += "north\n";
    } else{
        makemap += "\n";
    }
    makemap += Borders(mapSize);

    for (int i=0 ; i<mapSize ; i++){
      for (int h=0 ; h<mapSize ; h++){
        if (exits.Contains("west") && h==0 && i==mapSize/2){
            makemap += "west";
        } else if (h==0){
            makemap += "    ";
        }

        if (h==0) makemap += " | ";

        if (i==4 && h==4) makemap += "🐢 ";
        else makemap += " ~ ";

        if (h==mapSize-1) makemap += " | ";

       

        if (exits.Contains("east") && i==mapSize/2 && h==mapSize-1) makemap += "east";
      }
      makemap += "\n";
    }
    makemap += Borders(mapSize);
    if (exits.Contains("south")){
        for (int i = 0 ; i<((mapSize*3)/2)+5 ; i++){
            makemap += " ";
        }
        makemap += "south\n";
    } else{
        makemap += "\n";
    }
    return makemap;
  }
      
  public string MakeMaps(HashSet<string> exits, int pos1, int pos2){ // to make variable positions make parameters like pos1 and pos 2
    int mapSize = 9;
    string makemap = "";
    if (exits.Contains("north")){
        for (int i = 0 ; i<((mapSize*3)/2)+5 ; i++){
            makemap += " ";
        }
        makemap += "north\n";
    } else{
        makemap += "\n";
    }
    makemap += Borders(mapSize);
    for (int i=0 ; i<mapSize ; i++){
      for (int h=0 ; h<mapSize ; h++){
        if (exits.Contains("west") && h==0 && i==mapSize/2){
            makemap += "west";
        } else if (h==0){
            makemap += "    ";
        }

        if (h==0) makemap += " | ";

        if (i==4 && h==4) makemap += "🐢 ";

        else if (i==pos1 && h==pos2) makemap += "🥤 ";

        else makemap += " ~ ";

        if (h==mapSize-1) makemap += " | ";

       

        if (exits.Contains("east") && i==mapSize/2 && h==mapSize-1) makemap += "east";
      }
      makemap += "\n";
    }
    makemap += Borders(mapSize);
    if (exits.Contains("south")){
        for (int i = 0 ; i<((mapSize*3)/2)+5 ; i++){
            makemap += " ";
        }
        makemap += "south\n";
    } else{
        makemap += "\n";
    }
    return makemap;
  }
  private string Borders(int mapSize){
    string border = "     ";
    for (int i = 0 ; i<mapSize*3+4 ; i++){
      border += "-";
    }
    border += "\n";
    return border;
    }
}



