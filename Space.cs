/* Space class for modeling spaces (rooms, caves, ...)
 */

namespace SeaTurtleSavior;

class Space : Node
{
    public Space(string name) : base(name)
    {
    }
    private static Trash[] trashList = new Trash[18]{
        new Trash("plastic_bottle", "plastic", false),
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
        new Trash("t-shirt", "textile", false),
        new Trash("wood_plank", "wood", false),
        new Trash("glass_bottle", "glass", false),
        new Trash("can", "metal", false)
    };
    private static InformationPrinter infoPrinter = new InformationPrinter();
    private static Trash availableTrash = new Trash("No trash here", "", false);
    private HashSet<string> exits;

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
            Console.WriteLine(MakeMaps(exits, context.GetPlayerX(), context.GetPlayerY()));
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
        
        // Almindelige rum, laver nyt trash
        else
        {
            if (!redraw) // hvis vi har tegnet rummet 1 gang, så skal der ikke komme et nyt stykke "trash"
            {
                Random rng = new Random();
                int randomNumber = rng.Next(0, trashList.Length);
                availableTrash = trashList[randomNumber];
            }
            Console.Write(MakeMaps(exits, context.GetPlayerX(), context.GetPlayerY()));
            
        }
        Console.WriteLine("Trash: " + availableTrash.GetName());
        Console.WriteLine("You are now at " + name);
    }

    public void Goodbye()
    {
    }

    public override Space FollowEdge(string direction)
    {
        return (Space)(base.FollowEdge(direction));
    }

    // Tegner mappet, med player position som parameter
    public string MakeMaps(HashSet<string> exits, int playerX, int playerY)
    {
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

                // Use dynamic player position instead of hardcoded (4,4)
                if (i == playerY && h == playerX) makemap += "🐢 ";
                else makemap += " ~ ";

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