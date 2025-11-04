// WasteStation class for sorting and recycling trash in different containers. 
using System.Collections.Generic; 


class WasteStation 
{
	private Container[] containers;

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


	public void SortTrash(Inventory inv, Trash trash, int containerNumber, string sortingType)
	{
		
		
			if (trash.Material == sortingType && containers[containerNumber].SortingType == sortingType)
			{
				inv.RemoveTrash(trash);
				Console.WriteLine("This sorting type is being put into the correct container! And now its not in the inventory anymore!");
			}

			else 
			{
				Console.WriteLine(sortingType + " is not " + containers[containerNumber].SortingType);
				// Maybe we can add a penalty for sorting the wrong type of trash into the wrong container in the future. 
			}
		
	}


	public void RecyclingReward() //Unfinished
	{
		Console.WriteLine("Giving x amount of coins to player");
		//Add to the plyer coin amount. 

	}

	public void GoHabor()  //Unfinished
	{
		//For When the habor exits
		Console.WriteLine("You are now at he habor!");

	}
}















class Container //Container class which has a sorting type attribute. 
{

	public string SortingType {get;}

	public Container(string SortingType)
	{
		this.SortingType = SortingType;
	}


}
