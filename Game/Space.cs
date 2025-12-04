/* Space class for modeling spaces (rooms, caves, ...)
 */

namespace SeaTurtleSavior;

class Space : Node
{
    public Space(string name) : base(name)
    {
    }
    private static Trash[] trashList = new Trash[]{
        //"plastic", "glass", "metal", "paper", "organic", "electronics", "batteries", "textile", "wood"
        new Trash("bottle", "plastic", false),
        new Trash("bottle", "metal", false),
        new Trash("bottle", "glass", false),
        new Trash("food_wrapper", "plastic", false),
        new Trash("syringe", "plastic", true),
        new Trash("car_tire", "plastic", false),
        new Trash("pesticide_container", "plastic", true),
        new Trash("motor", "metal", false),
        new Trash("container", "plastic", false),
        new Trash("filter", "plastic", false),
        new Trash("metal_frame", "metal", false),
        new Trash("solar_panel", "electronics", false),
        new Trash("banana_peel", "organic", false),
        new Trash("phone", "electronics", true),
        new Trash("aa_battery", "batteries", true),
        new Trash("car_battery", "batteries", true),
        new Trash("shirt", "textile", false),
        new Trash("wood_plank", "wood", false),
        new Trash("can", "metal", false),
        new Trash("cloth", "plastic", false),
        new Trash("bottle_cap", "plastic", false),
        new Trash("fork", "metal", false),
        new Trash("knife", "metal", false),
        new Trash("straw", "plastic", false),
        new Trash("fishing_gear", "plastic", false),
        new Trash("bubblegum", "organic", false),
        new Trash("nylon_net", "textile", false),
        new Trash("cloth", "textile", false),
        new Trash("oil_clump", "chemical", true),
        new Trash("toxic_drum", "chemical", true),
        new Trash("medical_waste", "chemical", true),
        new Trash("plywood", "wood", false),
        new Trash("wire", "electronics", false),
        new Trash("charging_cable", "electronics", false),
        new Trash("container", "glass", false),
        new Trash("container", "metal", false),
        new Trash("flowerpot", "glass", false),
        
    };
    private static InformationPrinter infoPrinter = new InformationPrinter();
    private static Trash availableTrash = new Trash("No trash here", "", false);
    private HashSet<string> exits = new HashSet<string>();

    public struct TrashPosition
    {
        public int posX;
        public int posY;
    }

    private Dictionary<TrashPosition, Trash> trashInRoom = new Dictionary<TrashPosition, Trash>();
    private bool pickedUpTrash = false;
    
    public static Trash[] GetTrashList()
    {
        return trashList;
    }
    public static Trash GetavailableTrash()
    {
        return availableTrash;
    }
    public static void SetavailableTrash(Trash trash)
    {
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

    //Køre i starten, eller i nyt rum, Lav ny trash hvis ikke specielle rum, forklare spillet eller laver mappet
    //Denne funktion har næsten alt render logik af spillet
    public void Welcome(Context context,bool redraw)
    {
        Console.Clear();
        SetExits();

        Pollutionmeter pollution = new Pollutionmeter();
        Console.WriteLine(pollution.ShowPollution());

        // Hvis i specielle rum, lav ingen trash, lav scene
        if (name == "Harbor" || name == "Cleaning Machine" || name == "WasteStation")
        {
            availableTrash = new Trash("No trash here", "", false);
            Console.WriteLine(MakeMaps(exits, context.GetPlayerX(), context.GetPlayerY(), trashInRoom));
        }

        // Specielle rum instruktioner (WasteStation)
        if (name == "WasteStation")
        {
            infoPrinter.RoomInfoPrint("WasteStation");
        }
        // Specielle rum instruktioner (Harbor)
        else if (name == "Harbor")
        {
            infoPrinter.RoomInfoPrint("Harbor");
        }
        // Specielle rum instruktioner (Cleaning Machine)
        else if (name == "Cleaning Machine")
        {
            infoPrinter.RoomInfoPrint("CleaningMachine");
        }
        
        // Normal rooms make new trash
        else
        {
            if (!redraw) // If we have not drawed the room 1 time, there shouldt come new trash
            {
                Random rng = new Random();
                int trashNumber = rng.Next(5, 10);
                int[] spawnPoints = new int[] { 0, 1, 2, 6, 7, 8 };
                List<int> listX = new List<int>(spawnPoints);
                List<int> listY = new List<int>(spawnPoints);
                List<Trash> tempTrashList = new List<Trash>(trashList);
                int count = 0;
                for (int i = 0 ; i < trashNumber ; i++)
                {
                    
                    // make random numbers for the lists elements
                    int randomX = rng.Next(0, listX.Count);
                    int randomY = rng.Next(0, listY.Count);
                    
                    // make an instance of TrashPosition and set its values to the random numbers
                    TrashPosition pos = new TrashPosition();
                    pos.posX = listX.ElementAt(randomX);
                    pos.posY = listY.ElementAt(randomY);
                    
                    // remove an element from only 1 list
                    if (count % 2 == 0) listX.RemoveAt(randomX);
                    else listY.RemoveAt(randomY);
                    count++;
                    
                    // make random trash
                    int randomNumber = rng.Next(0, tempTrashList.Count);
                    trashInRoom.Add(pos, tempTrashList.ElementAt(randomNumber));
                    tempTrashList.RemoveAt(randomNumber);
                }
            }
            Console.Write(MakeMaps(exits, context.GetPlayerX(), context.GetPlayerY(), trashInRoom));
        }

        if (pickedUpTrash)
        {
            InformationPrinter printer = new InformationPrinter();
            printer.PrintInfoMsg(printer.GetTrashPrinter());
            pickedUpTrash = false;
        }
        Console.WriteLine("Trash: ");
        foreach (var item in trashInRoom)
        {
            Console.WriteLine(" - "+item.Value.GetName());
        }
        Console.Write("You are now at ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(name);
        Console.ResetColor();
    }

    public void Goodbye()
    {
        trashInRoom.Clear();
    }

    public override Space FollowEdge(string direction)
    {
        return (Space)(base.FollowEdge(direction));
    }

    // Tegner mappet, med player position som parameter
    public string MakeMaps(HashSet<string> exits, int playerX, int playerY, Dictionary<TrashPosition, Trash> showTrash)
    {
        Trash trash = new Trash("No trash here", "", false);
        int mapSize = 9;
        string makemap = "";
        if (exits.Contains("north"))
        {
            makemap += "                          North\n";
        }
        else
        {
            makemap += "\n";
        }
        makemap += Borders(mapSize);

        for (int i = 0; i < mapSize; i++)
        {
            for (int h = 0; h < mapSize; h++)
            {
                if (exits.Contains("west") && h == 0 && i == mapSize / 2)
                {
                    if (name == "Harbor") makemap += "WasteStation";
                    else if (name == "Cleaning Machine") makemap += "      Harbor";
                    else makemap += "        West";
                }
                else if (h == 0)
                {
                    makemap += "            ";
                }
                if (h == 0) makemap += " | ";


                makemap += " ~ ";
                bool turtleHere = false;
                if (i == playerY && h == playerX)
                {
                    makemap = makemap.Remove(makemap.Length - 3);
                    makemap += "𓆉  ";
                    turtleHere = true;
                }
                
                foreach (var item in showTrash)
                {
                    if (h == item.Key.posX && i == item.Key.posY && !turtleHere)
                    {
                        makemap = makemap.Remove(makemap.Length - 3);
                        if (item.Value.GetForbiddenMaterial()) makemap += " ☠︎︎️ ";
                        else if (item.Value.GetMaterial() == "plastic") makemap += " P ";
                        else if (item.Value.GetMaterial() == "glass") makemap += " G ";
                        else if (item.Value.GetMaterial() == "metal") makemap += " M ";
                        else if (item.Value.GetMaterial() == "paper") makemap += " P ";
                        else if (item.Value.GetMaterial() == "organic") makemap += " O ";
                        else if (item.Value.GetMaterial() == "electronics") makemap += " E ";
                        else if (item.Value.GetMaterial() == "batteries") makemap += " B ";
                        else if (item.Value.GetMaterial() == "textile") makemap += " T ";
                        else if (item.Value.GetMaterial() == "wood") makemap += " W ";
                    }
                    else if (h == item.Key.posX && i == item.Key.posY && turtleHere)
                    {
                        if (item.Value.GetForbiddenMaterial())
                        {
                            if (Game.GetShield() == 0)
                            {
                                Game.EndGame(false, "Cause of death: Picked up a deadly piece of trash");
                            }
                            else
                            {
                                Game.SetShield(Game.GetShield()-1);
                            }
                        }
                        
                        bool a = Game.GetInv().CollectTrash(item.Value);
                        trash = item.Value;
                        showTrash.Remove(item.Key);
                        
                        if (a == false)
                        {
                            Game.EndGame(false, "Cause of death: Inventory capacity exceeded");
                        }
                        pickedUpTrash = true;
                    }
                }

                if (h == mapSize - 1) makemap += " | ";

                if (exits.Contains("east") && i == mapSize / 2 && h == mapSize - 1)
                {
                    if (name == "Harbor") makemap += "Cleaning Machine";
                    else if (name == "WasteStation") makemap += "Harbor";
                    else makemap += "East";
                }
            }
            makemap += "\n";
        }
        makemap += Borders(mapSize);
        if (exits.Contains("south"))
        {
            if (name == "Southern waters") makemap += "                          Harbor\n";
            else makemap += "                          South\n";
        }
        else
        {
            makemap += "\n";
        }
        if (pickedUpTrash)
        {
            makemap += trash.GetName() + " added to inventory.";
            if (trash.GetForbiddenMaterial()) makemap += " You have used a shield to pick up a deadly piece of trash.";
            makemap += "\n";
        }
        return makemap;
    }

    // Tegner grænserne for mappet
    private string Borders(int mapSize)
    {
        string border = "             ";
        for (int i = 0; i < mapSize * 3 + 4; i++)
        {
            border += "-";
        }
        border += "\n";
        return border;
    }
}
