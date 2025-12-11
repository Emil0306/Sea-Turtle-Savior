namespace SeaTurtleSavior;

public class CleaningMachine
{
    public CleaningMachine()
    {
        constructionList = new string[] {
            "motor",
            "container",
            "filter",
            "frame",
            "solar_panel",
            "bearing",
            "pipe",
            "microcontroller",
            "rubber",
            "pump"
        };
    }

    private static string[] constructionList =
    {
        "motor",
        "container",
        "filter",
        "frame",
        "solar_panel",
        "bearing",
        "pipe",
        "microcontroller",
        "rubber",
        "pump"

    };
    private double len = constructionList.Length;
    private double progress;
    
    public double GetProgress()
    {
        return progress;
    }

    public void SetProgress(double newProgress)
    {
        if (newProgress < 0) progress = 0;
        else if (newProgress >= 100) progress = 100;
        else progress = newProgress;
    }

    public string[] GetConstructionList()
    {
        return constructionList;
    }
    
    public string AddMaterial(string input, Inventory playerInventory)    // Used by CommandAddMaterial
    {
        // Checks if material is needed
        bool isRequired = false;
        for (int i = 0; i < constructionList.Length; i++)
        {
            if (constructionList[i] == input)
            {
                isRequired = true;
                break;
            }
        }
        if (!isRequired) return "That item is not required!";

        // Checks if player has item in inventory
        Trash? foundItem = playerInventory.FindObj(input);
        if (foundItem == null) return "";

        // Updates the construction list
        string[] temp = new string[constructionList.Length-1];
        int x = 0;
        for (int i = 0 ; i < constructionList.Length ; i++)
        {
            if (constructionList[i] != input)
            {
                temp[x] = constructionList[i];
                x++;
            }
        }
        constructionList = temp;
        if (progress == 60) {
            Console.WriteLine("Every piece of trash in the ocean adds up! Reducing ocean litter protects the sea turtles.");
        }
        playerInventory.RemoveTrash(foundItem);
        SetProgress(GetProgress() + (100.00/len));
        return $"{input} added to Cleaning Machine! Progress is now {GetProgress()}%.";
    }
}
