using System.Collections.Generic;

class Inventory
{
	private List<Trash> inventoryList = new List<Trash>();
	private int capacity = 15;

	public void CollectTrash(Trash trash)
	{
		
		if (inventoryList.Count < capacity)
		{
			inventoryList.Add(trash);
			Console.WriteLine($"{trash.Name} added to inventory.");
		}
		else 
        {
            FullCapacity(); 
        }
			
	}

	public void RemoveTrash(int item)
	{
			inventoryList.Remove(inventoryList[item]); 
	}

	public void FullCapacity() // Player Should then die, but will be added later on.
	{
			Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine("Inventory full! Cannot add more trash."); 
        	Console.ForegroundColor = ConsoleColor.Gray; 
	}



	public void GetInventory()
	{
		Console.ForegroundColor = ConsoleColor.Green; 
		Console.WriteLine("Inventory: ");
		Console.ForegroundColor = ConsoleColor.Gray;

		for (int i = 0 ; i < inventoryList.Count ; i++) 
		{
			Console.WriteLine($"{inventoryList[i].Name} af {inventoryList[i].Material}"); // Prints out the trash name and material type.
		}

		
	}

	/* public static void Main() // Dette er kun brugt til at teste om det virker da vi ikke har rum med trash endnu. 
	{	
		
		Inventory myInv = new Inventory();
		

		myInv.CollectTrash(new Trash("Dildo", "Plastic"));
		myInv.CollectTrash(new Trash("Heineken", "Plastic"));
		myInv.CollectTrash(new Trash("Træ", "Plastic"));
		myInv.CollectTrash(new Trash("Køleskab", "Plastic"));
		myInv.CollectTrash(new Trash("Bue", "Plastic"));
		myInv.CollectTrash(new Trash("Pil", "Plastic"));
		myInv.CollectTrash(new Trash("Hjul", "Plastic"));
		myInv.CollectTrash(new Trash("Deo", "Plastic"));
		myInv.CollectTrash(new Trash("Jernrør", "Plastic"));
		myInv.CollectTrash(new Trash("Hammer", "Plastic"));
		myInv.CollectTrash(new Trash("Spyd", "Plastic"));
		myInv.CollectTrash(new Trash("Malerspand", "Plastic"));
		myInv.CollectTrash(new Trash("Tang", "Plastic"));
		myInv.CollectTrash(new Trash("Sten", "Plastic"));
		myInv.CollectTrash(new Trash("Iphone", "Plastic"));
		myInv.CollectTrash(new Trash("Bil", "Plastic"));
		myInv.GetInventory();

		myInv.RemoveTrash(0);
		myInv.GetInventory();

	} */


}