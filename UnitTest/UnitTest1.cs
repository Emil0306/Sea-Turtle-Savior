using SeaTurtleSavior;
namespace UnitTests;

public class Tests
{
    Inventory inv;
    Pollutionmeter PMeter;
    
    [SetUp]
    public void Setup()
    {
        inv = new Inventory();
        PMeter = new Pollutionmeter();
    }

    [Test]
    public void CollectTrashTest()
    {
        // First 15 items of trash should return true
        for (int i = 0 ; i < 15 ; i++)
        {
            Assert.That(inv.CollectTrash(new Trash("filter", "plastic", false)), Is.EqualTo(true));
        }
        // the 16 item of trash should return false
        Assert.That(inv.CollectTrash(new Trash("filter", "plastic", false)), Is.EqualTo(false));
        Assert.Pass();
    }

    [Test]
    public void Test2()
    { 
        Console.WriteLine("Hello World!");
        
        //Testing if game ends when pollution meter hits max of 100%
        for (int i = 0; i <= 100; i++)
        {
            Assert.That(PMeter.ChangePollution(1), Is.EqualTo(true));
            
        }
        Assert.That(PMeter.ChangePollution(1), Is.EqualTo(false));
        Assert.Pass();
    }
}
