/* Command for transitioning between spaces
 */

class CommandGo : BaseCommand, ICommand {
    public CommandGo () {
        description = "Follow an exit (e.g. go west)";
    }

    public void Execute (Context context, string command, string[] parameters) {
        if (GuardEq(parameters, 1)) {
            Console.WriteLine("I don't seem to know where that is 🤔");
            return;
        }
        HashSet<string> exits = context.GetCurrent().GetExits();

        if (exits.Contains(parameters[0])) 
        { 
            context.Transition(parameters[0]);
            return;
        }
        
        Console.WriteLine("I don't seem to know where '"+parameters[0]+"' is 🤔");
    }
}
