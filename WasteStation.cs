// WasteStation class for sorting and recycling trash in different containers. 
using System.Collections.Generic; 


class WasteStation 
{
	private Container[] containers;
    private string[] sortingTypes;

	public WasteStation()
	{
		//Making 9 predefined sorting types
		string[] sortingTypes = {"Plastic", "Glass", "Metal", "Paper", "Organic", 
            "Electronics", "Batteries", "Textile", "Wood"};

        containers = new Container[sortingTypes.Length];

        for (int i = 0; i < sortingTypes.Length; i++)
        {
            containers[i] = new Container(sortingTypes[i]); //Adding the actual arrys here and giving each array a different sorting type.
        }

	}


	
public void SortTrash(Inventory inv, Trash trash, int containerNumber)
{
	if (trash == null){
		return;
	}
    // Safety check to prevent crashing if the number is invalid
    if (containerNumber < 0 || containerNumber >= containers.Length)
    {
        Console.WriteLine("That container doesn't exist!");
        return; 
    }

    // Get the specific container
    Container targetContainer = containers[containerNumber]; 

    // Compare the trash's material to the container's sorting type
    if (trash.Material == targetContainer.SortingType)
    {
        inv.RemoveTrash(trash);
       
        Console.WriteLine($"Successfully sorted {trash.Material} into the {targetContainer.SortingType} container!");
    }
    else 
    {
        Console.WriteLine($"Wrong container! {trash.Material} does not belong in the {targetContainer.SortingType} container.");
        // Maybe we can add a penalty that adds to the pollutionmeter for sorting the wrong type of trash.
    }
}

	public void RecyclingReward() //Unfinished
	{
		Console.WriteLine("Giving x amount of coins to player");
		//Add to the plyer coin amount. 

	}

    public string[] GetSortingTypes()
    {
        return sortingTypes;
    }
}





