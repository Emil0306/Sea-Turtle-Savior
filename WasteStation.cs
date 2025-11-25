// WasteStation class for sorting and recycling trash in different containers. 

namespace SeaTurtleSavior;

class WasteStation 
{
    Pollutionmeter pollutionmeter = new Pollutionmeter(); //nyt pollutionmeter
    private Container[] containers;
	string[] sortingTypes = new string[] {"plastic", "glass", "metal", "paper", "organic", "electronics", "batteries", "textile", "wood"};

	public WasteStation() {
		//Making 9 predefined sorting types
		

		containers = new Container[sortingTypes.Length];

		for (int i = 0; i < sortingTypes.Length; i++)
		{
			containers[i] = new Container(sortingTypes[i]); //Adding the actual arrays here and giving each array a different sorting type.
		}
	}
	
	public void SortTrash(Inventory inv, Trash trash, string containerSortType)

	{
		if (trash == null){
			return;
		}
	    
		if (trash.GetMaterial() == containerSortType)
		{
			inv.RemoveTrash(trash);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"Successfully sorted the {trash.GetName()} into the {containerSortType} container!");
			Console.ResetColor();
 
			pollutionmeter.ChangePollution(-2);// Ved korrekt Sortering går Pollutionmeter % ned.

		

        }
		else
		{
            inv.RemoveTrash(trash);
            Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"Wrong container! {trash.GetMaterial()} does not belong in the {containerSortType} container.");
			Console.ResetColor();
            pollutionmeter.ChangePollution(+5); // Ved forkert  Sortering gÃ¸r Pollutionmeter % op.

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