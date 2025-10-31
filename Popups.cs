  // Herfra starter POPUPS med (+ Location (int, int) : void og + LearningInfo (string) : void)

  using System;

  public class Popups
  {
      private string[] locations = { "Wastestation", "Ocean", "Harbor" };
      private string[] messages =
      {
          "Du er ved affaldsstationen – her sorteres alt det skrald, du har samlet ind, så havet kan ånde igen.",
          "Du befinder dig midt i havet. Strømmen fører både skrald og liv – find affaldet, før det gør skade.",
          "Du er i havnen. Fiskerbåde lægger til, og affald flyder mellem kajerne – gør området rent igen."
      };

      private string currentLocation = null; // gemmer sidste valgte lokation

      public void Location(string location)
      {
          currentLocation = location;
      }

      public void LearningInfo()
      {
          if (string.IsNullOrWhiteSpace(currentLocation))
          {
              Console.WriteLine("Lokation ukendt.");
              return;
          }

          for (int i = 0; i < locations.Length; i++)
          {
              if (currentLocation == locations[i])
              {
                  Console.WriteLine(messages[i]);
                  return;
              }
          }

          Console.WriteLine("Lokation ukendt.");
      }

  }
