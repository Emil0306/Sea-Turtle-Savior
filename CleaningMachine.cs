public class CleaningMachine
{
    private int progress = 0;

    private string[] constructionList=
    {
        "Strong metal body to hold everything together",
        "Floating parts to help it stay on the water",
        "Trash collector to scoop up plastic and metal",
        "Filter to clean out dirty or chemical water",
        "Storage boxes for the collected trash",
        "Battery or solar power to keep it running",
        "Simple control panel to steer and start it"
    };

    public int GetProgress()
    {
        return progress;
    }

    public string[] GetConstructionList()
    {
        return constructionList;
    }

    public void SetProgress(int newProgress)
    {
        if (newProgress < 0) progress = 0;
        else if (newProgress >= 100) progress = 100;
        else progress = newProgress;
    }
}
