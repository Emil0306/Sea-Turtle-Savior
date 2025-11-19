public class LearningMsg
  {
    private int control = 3;
    Random rand = new Random();

    private static List<string> trashInfoMsg = new List<string>
    {
      "|ℹ️| Did you know microplastics in the ocean can accumulate in seafood making it risky for humans to consume?",
      "|ℹ️| Did you know you can reduce marine debris from your home by simply using fewer single-use plastic items? ",
      "|ℹ️| You picked up trash - good! Now remember the 4 R’s: Refuse, Reuse, Reduce, Recycle. Forget one, and a seaturtle will judge you!",
      "|ℹ️| Great! Now there is only 150 million tons of ocean trash left. You better start finishing the Cleaning Machine!",
      "|ℹ️| Did you know a single plastic bottle takes about 450 years to decompose? That means it would outlive your great-great-great-grandchildren!",
      "|ℹ️| Did you know glass bottles specifically do not decompose? They can last for over 1 million years in the environment if not crushed or recycled.",
      "|ℹ️| Sea turtles often mistake floating plastic bags for jellyfish, their favorite snack. Thanks for saving a turtle from a deadly mistake!",
      "|ℹ️| Seabirds often feed plastic to their chicks because it smells like food. By cleaning this up, you are helping the next generation of birds survive!",
      "|ℹ️| You are now officially a nicer person than people who litter. Keep up the good work, hero!",
      "|ℹ️| Did you know there is a patch of garbage in the Pacific Ocean that is estimated to be three times the size of France?",
      "|ℹ️| By cleaning this up, you are protecting the ocean's 'Blue Economy'.",
      "|ℹ️| Glitter is actually just tiny pieces of shiny plastic. When you wash it off, it can lead straight into the ocean."
    };

    private static List<string> sortInfoMsg = new List<string>
    {
      "|ℹ️| The Coffee Cup Myth: Most paper coffee cups are lined with a thin layer of plastic to keep them waterproof. This makes them very hard to recycle.",
      "|ℹ️| Composite Chaos: Chips tubes (like Pringles) are a nightmare for recyclers because they are made of metal, paper, and plastic fused together. They usually go to the landfill.",
      "|ℹ️| Did you know Sweden is so good at sorting and recycling that they actually run out of trash and have to import it from other countries to power their energy plants?",
      "|ℹ️| Fun fact: The first recorded instance of recycling was in 1031 in Japan, where the decline of the imperial court led to paper being reused and recycled."
    };
    public void TrashPickUpMsg()
    {
      if (control % 3 == 0)
      {
        int randomValue = rand.Next(trashInfoMsg.Count);
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.WriteLine(trashInfoMsg[randomValue]);
        Console.ResetColor();
        control += 1;
      }
      else
      {
        control += 1;
      }
    }
    public void SortingMsg()
    {
      if (control % 3 == 0)
      {
        int randomValue = rand.Next(sortInfoMsg.Count);
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.WriteLine(sortInfoMsg[randomValue]);
        Console.ResetColor();
        control += 1;
      }
      else
      {
        control += 1;
      }
    }
  }