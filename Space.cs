/* Space class for modeling spaces (rooms, caves, ...)
 */

class Space : Node {
  public Space (String name) : base(name)
  {
  }
  
  public void Welcome () {
    Console.Clear();
    HashSet<string> exits = edges.Keys.ToHashSet();
    Console.WriteLine(MakeMaps(exits));
    Console.WriteLine("You are now at "+name);
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

  public string MakeMaps(HashSet<string> exits){ // to make variable positions make parameters like pos1 and pos 2
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

        if (i==4 && h==4) makemap += "🐢 "; // to make variable positions: i == pos1 && h == pos2
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
