namespace SeaTurtleSavior;

public class Inventory
{
	private List<Trash> inventoryList = new List<Trash>();
	private int capacity = 15;
	Pollutionmeter pollutionmeter = new Pollutionmeter (); //laver vores nye pollutionmeter så vi kan bruge den.

	public bool CollectTrash(Trash trash)
	{
		
		if (inventoryList.Count < capacity)
		{
			inventoryList.Add(trash);
			Console.WriteLine($"{trash.GetName()} added to inventory.");

			pollutionmeter.ChangePollution(-5); //Måske burde vi fjerne det.

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
			Console.WriteLine($"{inventoryList[i].GetName()} made of {inventoryList[i].GetMaterial()}"); // Prints out the waste's name and material type.
		}
	}

	public Trash FindObj(string name){
		for (int i = 0 ; i < inventoryList.Count ; i++) 
		{
			if (inventoryList[i].GetName() == name){
				return inventoryList[i];
			}

		}
		Console.WriteLine("Could not find " + name + " in the inventory");
		return null;
	}
}