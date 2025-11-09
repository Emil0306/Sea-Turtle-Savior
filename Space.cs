/* Space class for modeling spaces (rooms, caves, ...)
 */

class Space : Node {
  public static Trash[] trashList = new Trash[16]{ // change to private and add getters
// --- Plastic (5) ---
new Trash("Plastic_Bottle",      "Plastic",     false),
new Trash("Food_Wrapper",        "Plastic",     false),
new Trash("Syringe",             "Plastic",     true),
new Trash("Car_Tire",            "Plastic",     true),
new Trash("Pesticide_Container", "Plastic",     true),

// --- Glass (1) ---
new Trash("Motor",            "Metal",        false),
new Trash("AffaldsContainer", "Plastic",      false),
new Trash("Filter",           "Synthetic",    false),
new Trash("Metalramme",       "Metal",        false),
new Trash("Solpanel",         "Electronics",  false),
new Trash("Banana_Peel",         "Organic",     false),

// --- Electronics (1) ---
new Trash("Old_Phone",           "Electronics", true),

// --- Batteries (2) ---
new Trash("AA_Battery",          "Batteries",   true),
new Trash("Car_Battery",         "Batteries",   true),

// --- Textile (1) ---
new Trash("Old_TShirt",          "Textile",     false),

// --- Wood (1) ---
new Trash("Wood_Plank",          "Wood",        false)
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
    else {
      Random rng = new Random();
      int randomNumber = rng.Next(0, trashList.Length);
      availableTrash = trashList[randomNumber];
      Console.Write(MakeMaps(exits)); // change to other method
      Console.WriteLine("Trash: "+availableTrash.Name);
    }
    Console.WriteLine("You are now at "+name);
    Console.WriteLine("Current exits are:");
    foreach (String exit in exits) {
      Console.WriteLine(" - "+exit);
    }

    if (name == "Cleaning Machine")
    {
      CleaningMachine machine = new CleaningMachine();
      Inventory playerInventory = new Inventory();

      Console.WriteLine("Type the name of an item to add (or 'leave' to leave):");
      string input = Console.ReadLine() ?? "";


      if (!string.IsNullOrWhiteSpace(input) && input.ToLower() != "leave")
      {
        string result = machine.AddMaterial(input, playerInventory);
        Console.WriteLine(result);
      }
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



