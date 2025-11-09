using System;
using System.Linq;

public class CleaningMachine
{
    private readonly string[] constructionList =
    {
        "Motor",
        "AffaldsContainer",
        "Filter",
        "Metalramme",
        "solpanel",
    };

    private int progress = 0;

    public int GetProgress() => progress;

    public void SetProgress(int newProgress)
    {
        if (newProgress < 0) progress = 0;
        else if (newProgress >= 100) progress = 100;
        else progress = newProgress;
    }

    public string[] GetConstructionList() => constructionList;


    // bruges af command 'add <material>'
    //
    public string AddMaterial(string input, Inventory playerInventory)
    {
        // find manglende dele

        string[] missingItems = new string[GetConstructionList().Length];
        int missingCount = 0;
        for (int i = 0; i < GetConstructionList().Length; i++)
        {
            int itemsAdded = GetProgress() / 20;
            if (i >= itemsAdded) missingItems[missingCount++] = GetConstructionList()[i];
        }
        if (missingCount == 0) return "The Cleaning Machine is fully built!";

        // Er Materialet krævet?

        bool isRequired = false;
        for (int i = 0; i < missingCount; i++)
        {
            if (missingItems[i] == input) { isRequired = true; break; }
        }
        if (!isRequired) return "That item is not required!";

        // Har spilleren Den i forevejen?

        Trash foundItem = playerInventory.FindObj(input);
        if (foundItem == null) return "You don't have that item!";

        // tilføj Materiale og SetProgress

        playerInventory.RemoveTrash(foundItem);
        SetProgress(GetProgress() + 20);
        Game.CheckWinCondition(); // tjekker om spilleren har vundet (0% pollution, 100% bygget maskine)
        return $"{input} added to Cleaning Machine! Progress is now {GetProgress()}%.";
    }
}


