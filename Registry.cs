/* Command registry
 */

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
        
        if (parameters.Length >= 2 && (command == "sort" || command == "collect"))
        {
            // This makes it so we can write food wrapper and it automatically converts it into an underscore for us
            string itemWithSpace = $"{parameters[0]} {parameters[1]}"; // f.eks. "food wrapper"
            string itemWithoutSpace = itemWithSpace.Replace(' ', '_'); // 
            
            List<string> newParameterList = new List<string> {itemWithoutSpace};
            newParameterList.AddRange(parameters.Skip(2)); //skips ex. wood and wrapper and adds whats left in parameters into the end of newParameterList
            parameters = newParameterList.ToArray(); // Makes it into an array as that is what the Execute command takes as a input
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