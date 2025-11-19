using System.Collections.Generic;

public class Inventory
{
	private List<Trash> inventoryList = new List<Trash>();
	private int capacity = 15;
	Pollutionmeter pollutionmeter = new Pollutionmeter ();

	public bool CollectTrash(Trash trash)
	{
		
		if (inventoryList.Count < capacity)
		{
			inventoryList.Add(trash);
			Console.WriteLine($"{trash.Name} added to inventory.");

			pollutionmeter.DecreasePollution(5);

			return true;
		}
		else 
        {
            return false;
        }
	}

	public void RemoveTrash(Trash trash)
	{
		inventoryList.Remove(trash); 
	}
	
	public void GetInventory()
	{
		Console.ForegroundColor = ConsoleColor.Green; 
		Console.WriteLine("Inventory: ");
		Console.ForegroundColor = ConsoleColor.Gray;

		for (int i = 0 ; i < inventoryList.Count ; i++) 
		{
			Console.WriteLine($"{inventoryList[i].Name} made of {inventoryList[i].Material}"); // Prints out the waste's name and material type.
		}
	}

	public Trash FindObj(string name){
		for (int i = 0 ; i < inventoryList.Count ; i++) 
		{
			if (inventoryList[i].Name == name){
				return inventoryList[i];
			}

		}
		Console.WriteLine("Could not find " + name + " in the inventory");
		return null;
	}
}
