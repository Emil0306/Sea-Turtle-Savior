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

	public void RemoveTrash(Trash trash)
	{
		
			inventoryList.Remove(trash); 
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
			Console.WriteLine($"{inventoryList[i].Name} af {inventoryList[i].Material}"); // Prints out the waste's name and material type.
		}

		
	}

	public static void Main()
	{	
		
		Inventory myInv = new Inventory();
		

		/* myInv.CollectTrash(new Trash("Dildo", "Plastic", false));
		myInv.CollectTrash(new Trash("Heineken", "Plastic", false));
		myInv.CollectTrash(new Trash("Træ", "Plastic", false));
		myInv.CollectTrash(new Trash("Køleskab", "Plastic", false));
		myInv.CollectTrash(new Trash("Bue", "Plastic", false));
		myInv.CollectTrash(new Trash("Pil", "Plastic", false));
		myInv.CollectTrash(new Trash("Hjul", "Plastic", false));
		myInv.CollectTrash(new Trash("Deo", "Plastic", false));
		myInv.CollectTrash(new Trash("Jernrør", "Plastic", false));
		myInv.CollectTrash(new Trash("Hammer", "Plastic", false));
		myInv.CollectTrash(new Trash("Spyd", "Plastic", false));
		myInv.CollectTrash(new Trash("Malerspand", "Plastic", false));
		myInv.CollectTrash(new Trash("Tang", "Plastic", false));
		myInv.CollectTrash(new Trash("Sten", "Plastic", false));
		myInv.CollectTrash(new Trash("Iphone", "Plastic", false));
		myInv.CollectTrash(new Trash("Bil", "Plastic", false));
		myInv.GetInventory();

		myInv.RemoveTrash(0);
		myInv.GetInventory(); 
		Console.WriteLine("Hello!");

		Trash trashTest = new Trash("Mikroovn", "Metal", false);
		myInv.CollectTrash(trashTest);
		myInv.GetInventory();

		WasteStation wStation = new WasteStation();
		wStation.SortTrash(myInv, trashTest, 3, "Metal");
		myInv.GetInventory();*/

	}


}