/* Space class for modeling spaces (rooms, caves, ...)
 */

class Space : Node {
  public static Trash[] trashList = new Trash[16]{ // change to private and add getters
    new Trash("Plastic bottle",          "Plastic", false),
    new Trash("Plastic bag",             "Plastic", false),
    new Trash("Food wrapper",            "Plastic", false),
    new Trash("Fishing net",             "Other",   false),
    new Trash("Fishing line",            "Other",   false),
    new Trash("Styrofoam float",         "Other",   false),
    new Trash("Cigarette butts",         "Mixed",   false),
    new Trash("Disposable mask",         "Plastic", false),
    new Trash("Aluminum can",            "Metal",   false),
    new Trash("Glass bottle",            "Glass",   false),
    new Trash("Car tire",                "Other",   false),
    new Trash("Battery",                 "Toxic",   false),
    new Trash("Chemical drum",           "Toxic",   false),
    new Trash("Oil container",           "Toxic",   false),
    new Trash("Syringe",                 "Toxic",   false),
    new Trash("Pesticide container",     "Toxic",   false)
  };
  private static Trash availableTrash = new Trash("No trash here", "", false);

  public static Trash GetavailableTrash (){
    return availableTrash;
  }
  public static void SetavailableTrash (Trash trash){
    availableTrash = trash;
  }

  public Space (String name) : base(name)
  {
  }
  
  public void Welcome () {
    Console.Clear();
    HashSet<string> exits = edges.Keys.ToHashSet();
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

    if (name == "Cleaning Machine") {
        CleaningMachine machine = new CleaningMachine();
        Inventory playerInventory = new Inventory();

        machine.AddItemFromInventory(playerInventory);
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



