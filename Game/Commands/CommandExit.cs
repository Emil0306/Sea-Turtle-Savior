/* Command for exiting program
 */

namespace SeaTurtleSavior.Commands;

class CommandExit : BaseCommand, ICommand {
    public CommandExit () {
        description = "Exit the game";
    }
    public void Execute (Context context, string command, string[] parameters) {
        Pollutionmeter.StopTimer();
        Game.SetWinLoss(false);
        context.SetDone(true);
    }
}