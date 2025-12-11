/* Help command
 */

namespace SeaTurtleSavior.Commands;

class CommandHelp : BaseCommand, ICommand {
    Registry registry;

    public CommandHelp (Registry registry) {
        this.registry = registry;
        this.description = "Display a help message";
    }

    public void Execute (Context context, string command, string[] parameters) {
        string[] commandNames = registry.GetCommandNames();
        Array.Sort(commandNames);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Trash is found in the ocean and marked by its corresponding material type. Eg. [M] for metal");
        Console.ResetColor();
        // find max length of command name
        int max = 0;
        foreach (String commandName in commandNames) {
            int length = commandName.Length;
            if (length>max) max = length;
        }

        // present list of commands
        Console.WriteLine("Commands:");
        foreach (String commandName in commandNames) {
            string description = registry.GetCommand(commandName).GetDescription();
            Console.WriteLine(" - {0,-"+max+"} "+description, commandName);
        }
    }
}