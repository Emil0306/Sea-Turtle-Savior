using System;
using System.Linq;

public class CleaningMachine
{
    private string[] constructionList =
    {
        "motor",
        "container",
        "filter",
        "metal_frame",
        "solar_panel"
    };

    private int progress;
    
    public int GetProgress() => progress;

    public void SetProgress(int newProgress)
    {
        if (newProgress < 0) progress = 0;
        else if (newProgress >= 100) progress = 100;
        else progress = newProgress;
    }

    public string[] GetConstructionList() => constructionList;


    // bruges af command 'add <material>'
    
    public string AddMaterial(string input, Inventory playerInventory)
    {
        // Checks if material is needed

        bool isRequired = false;
        for (int i = 0; i < constructionList.Length; i++)
        {
            if (constructionList[i] == input) { isRequired = true; break; }
        }
        if (!isRequired) return "That item is not required!";

        // Checks if player has item in inventory

        Trash foundItem = playerInventory.FindObj(input);
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
        
        playerInventory.RemoveTrash(foundItem);
        SetProgress(GetProgress() + 20);
        return $"{input} added to Cleaning Machine! Progress is now {GetProgress()}%.";
    }
}


