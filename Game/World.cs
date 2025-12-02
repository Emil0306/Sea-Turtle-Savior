/* World class for modeling the entire in-game world
 */

namespace SeaTurtleSavior;

class World {
    Space entry;

    public World () {
        Space harbor          = new Space("Harbor");
        Space cleaningMachine = new Space("Cleaning Machine");
        Space wasteStation    = new Space("WasteStation");
        Space water1          = new Space("Southwestern waters");
        Space water2          = new Space("Southern waters");
        Space water3          = new Space("Southeastern waters");
        Space water4          = new Space("Western waters");
        Space water5          = new Space("Middle of the ocean");
        Space water6          = new Space("Eastern waters");
        Space water7          = new Space("Northwestern waters");
        Space water8          = new Space("Northern waters");
        Space water9          = new Space("Northeastern waters");

        harbor.AddEdge("east", cleaningMachine);
        harbor.AddEdge("west", wasteStation);
        cleaningMachine.AddEdge("west", harbor);
        wasteStation.AddEdge("east", harbor);
        harbor.AddEdge("north", water2);
        water1.AddEdge("east", water2);
        water1.AddEdge("north", water4);
        water2.AddEdge("east", water3);
        water2.AddEdge("west", water1);
        water2.AddEdge("north", water5);
        water2.AddEdge("south", harbor);
        water3.AddEdge("west", water2);
        water3.AddEdge("north", water6);
        water4.AddEdge("east", water5);
        water4.AddEdge("north", water7);
        water4.AddEdge("south", water1);
        water5.AddEdge("north", water8);
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