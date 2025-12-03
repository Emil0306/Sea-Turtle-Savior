/* Command for viewing a list of dangerous trash
 */

namespace SeaTurtleSavior.Commands;

class CommandDeadly : BaseCommand, ICommand {
    public CommandDeadly () {
        description = "View a list of lethal trash items to pick up";
    }

    public void Execute (Context context, string command, string[] parameters) {
        if (GuardEq(parameters, 0)) {
            string allParameters = command+" ";
            for (int i = 0 ; i<parameters.Length ; i++){
                if (i!=parameters.Length-1) allParameters += parameters[i]+" ";
                else allParameters += parameters[i];
            }
            Console.WriteLine("Woopsie, I don't understand '"+allParameters+"' 😕");
            return;
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("⚠️ Dangerous trash ⚠️");
        Console.ForegroundColor = ConsoleColor.Gray;
        for (int i = 0 ; i < Space.GetTrashList().Length ; i++){
            if(Space.GetTrashList()[i].GetForbiddenMaterial()==true){
                Console.WriteLine("   - "+Space.GetTrashList()[i].GetName());
            }
        }
        Console.WriteLine("Do NOT pick up any of these types of trash. They are deadly!");
    }
}