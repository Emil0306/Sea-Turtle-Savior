/* Command registry
 */

using SeaTurtleSavior.Commands;

namespace SeaTurtleSavior;

class Registry {
    Context context;
    ICommand fallback;
    Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

    public Registry (Context context, ICommand fallback) {
        this.context = context;
        this.fallback = fallback;
    }

    public void Register (string name, ICommand command) {
        commands.Add(name, command);
    }

    public void Dispatch (string line) {
        line = line.ToLower(); // This line makes the game NOT caps sensitive
        string[] elements = line.Split(" ");
        string command = elements[0];
        string[] parameters = GetParameters(elements);
        
        if (command == "add" && parameters.Length >= 2)
        {
            string itemWithSpace = $"{parameters[0]} {parameters[1]}"; 
            string itemWithoutSpace = itemWithSpace.Replace(' ', '_'); 
            
            List<string> newParameterList = new List<string> {itemWithoutSpace};
            
            parameters = newParameterList.ToArray();
        }
        else if (command == "sort" && parameters.Length == 3)
        {
            string itemWithSpace = $"{parameters[0]} {parameters[1]}"; 
            string itemWithoutSpace = itemWithSpace.Replace(' ', '_'); 
            
            // Create a new parameter list: [combined_item, container]
            List<string> newParameterList = new List<string> {itemWithoutSpace};
            newParameterList.Add(parameters[2]); // Add the container ( eg. wood)
            
            parameters = newParameterList.ToArray();
        }
        (commands.ContainsKey(command) ? GetCommand(command) : fallback).Execute(context, command, parameters); // Looks if the command exists in the dictionary
    }

    public ICommand GetCommand (string commandName) {
        return commands[commandName];
    }

    public string[] GetCommandNames () {
        return commands.Keys.ToArray();
    }
    
    private string[] GetParameters (string[] input) {
        string[] output = new string[input.Length-1];
        for (int i=0 ; i<output.Length ; i++) {
            output[i] = input[i+1];
        }
        return output;
    }
}