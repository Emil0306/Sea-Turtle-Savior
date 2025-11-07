public class CleaningMachine
{
    private int progress = 0;

    private string[] constructionList=
    {
        "Hjul",
        "Iphone",
        "Bue",
        "Jernrør",
        "Bil",
    };

    public int GetProgress()
    {
        return progress;
    }

    public string[] GetConstructionList()
    {
        return constructionList;
    }

    public void SetProgress(int newProgress)
    {
        if (newProgress < 0) progress = 0;
        else if (newProgress >= 100) progress = 100;
        else progress = newProgress;
    }

    public void AddItemFromInventory(Inventory playerInventory) {

    Console.WriteLine("=== Cleaning Machine ===");
    Console.WriteLine("Progress: " + progress + "%");
    Console.WriteLine();

    string[] missingItems = new string[constructionList.Length];
    int missingCount = 0;

    for (int i = 0; i < constructionList.Length; i++) {
        string item = constructionList[i];
        bool found = false;

        // Hvis allerede tilføjet:
        int itemsAdded = progress / 20;
        if (i < itemsAdded) found = true;

        if (!found) {
            missingItems[missingCount] = item;
            missingCount++;
        }
    }

    if (missingCount == 0) {
        Console.WriteLine("The Cleaning Machine is fully built!");
        return;
    }

    Console.WriteLine("Required items:");
    for (int i = 0; i < missingCount; i++) {
        Console.WriteLine(" - " + missingItems[i]);
    }

    Console.WriteLine();
    Console.WriteLine("Your inventory:");
    playerInventory.GetInventory();

    Console.WriteLine();
    Console.WriteLine("Type the name of an item to add (or 'leave' to leave):");
    string input = Console.ReadLine();

    if (input == null || input.ToLower() == "leave") {
        return;
    }

    // Tjek om item er en del af listen
    bool isRequired = false;
    for (int i = 0; i < missingCount; i++) {
        if (missingItems[i] == input) {
            isRequired = true;
            break;
        }
    }

    if (!isRequired) {
        Console.WriteLine("That item is not required!");
        return;
    }

    // Tjek om spilleren har item
    Trash foundItem = playerInventory.FindObj(input);
    if (foundItem == null) {
        Console.WriteLine("You don't have that item!");
        return;
    }

    // Tilføj til maskine + progress
    playerInventory.RemoveTrash(foundItem);
    SetProgress(progress + 20); // each of 5 items = +20%
    Console.WriteLine(input + " added to Cleaning Machine! Progress is now " + progress + "%.");
    }
}


