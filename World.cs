/* World class for modeling the entire in-game world
 */

class World {
  Space entry;
  
  public World () {
    Space harbor          = new Space("Harbor");
    Space cleaningMachine = new Space("Cleaning Machine");
    Space wasteStation    = new Space("WasteStation");
    Space water1          = new Space("Water1");
    Space water2          = new Space("Water2");
    Space water3          = new Space("Water3");
    Space water4          = new Space("Water4");
    Space water5          = new Space("Water5");
    Space water6          = new Space("Water6");
    Space water7          = new Space("Water7");
    Space water8          = new Space("Water8");
    Space water9          = new Space("Water9");
    
    harbor.AddEdge("east", cleaningMachine);
    harbor.AddEdge("west", wasteStation);
    cleaningMachine.AddEdge("harbor", harbor);
    wasteStation.AddEdge("harbor", harbor);
    harbor.AddEdge("north", water2);
    water1.AddEdge("east", water2);
    water1.AddEdge("north", water4);
    water2.AddEdge("harbor", harbor);   // Delete when add harbor from everywhere
    water2.AddEdge("east", water3);
    water2.AddEdge("west", water1);
    water2.AddEdge("north", water5);
    water3.AddEdge("west", water2);
    water3.AddEdge("north", water6);
    water4.AddEdge("east", water5);
    water4.AddEdge("north", water7);
    water4.AddEdge("south", water1);
    water5.AddEdge("north", water7);
    water5.AddEdge("west", water4);
    water5.AddEdge("east", water6);
    water5.AddEdge("south", water2);
    water6.AddEdge("west", water5);
    water6.AddEdge("north", water9);
    water6.AddEdge("south", water3);
    water7.AddEdge("south", water4);
    water7.AddEdge("east", water8);
    water8.AddEdge("east", water9);
    water8.AddEdge("west", water7);
    water8.AddEdge("south", water5);
    water9.AddEdge("south", water6);
    water9.AddEdge("west", water8);


    this.entry = harbor;
  }
  
  public Space GetEntry () {
    return entry;
  }
}

