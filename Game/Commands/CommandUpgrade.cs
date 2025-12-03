namespace SeaTurtleSavior.Commands;

class CommandUpgrade : BaseCommand, ICommand
{
    private int price = 5;
    private Inventory inv;

    public CommandUpgrade(Inventory inv)
    {
        this.inv = inv;
        description = "Upgrade your inventory capacity or get a shield which will protect you one time against toxic waste";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (GuardEq(parameters, 1))
        {
            FailedCommand();
            return;
        }

        if (parameters[0] == "inventory")
        {
            if (Game.GetCoins() < price)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You do not have enough coins to upgrade your inventory.");
                Console.WriteLine("Upgrading your inventory cost " + price + " coins");
                Console.ResetColor();
                return;
            }
            Game.SetCoins(Game.GetCoins() - price);
            inv.SetCapacity(inv.GetCapacity()+2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your inventory's capacity has been upgraded to " + inv.GetCapacity());
            Console.ResetColor();
        }
        else if (parameters[0] == "shield")
        {
            if (Game.GetCoins() < price)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You do not have enough coins to buy a shield");
                Console.WriteLine("Buying a shield cost " + price + " coins");
                Console.ResetColor();
                return;
            }
            Game.SetCoins(Game.GetCoins() - price);
            Game.SetShield(Game.GetShield() + 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You do now have "+Game.GetShield()+(Game.GetShield() == 1 ? " shield" : " shields"));
            Console.ResetColor();
        }
        else
        {
            FailedCommand();
        }
    }

    private void FailedCommand()
    {
        Console.WriteLine("To upgrade inventory capacity write: upgrade inventory");
        Console.WriteLine("To buy a shield write: upgrade shield");
    }
}