public class CleaningMachine
{
    private readonly string[] constructionList =
    {
        "Strong metal", "Floating parts", "Trash collector",
        "Filter", "Storage boxes", "Battery", "Simple control panel"
    };

    private int addedCount = 0;
    private int progress = 0;

    public string AddMaterial(string material)
    {
        if (!constructionList.Contains(material))
            return $"'{material}' is not a valid part.";

        addedCount++;
        progress = addedCount * 100 / constructionList.Length;

        if (addedCount == constructionList.Length)
            return "🎉 Congratulations, the CleaningMachine is finished and working!";
        else
            return $"{material} added. ({progress}%)";

    }

    public int GetProgress() => progress;

    public string[] GetConstructionList() => constructionList;
}


