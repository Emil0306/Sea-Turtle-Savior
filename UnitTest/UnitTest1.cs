using SeaTurtleSavior;
namespace UnitTests;

public class Tests
{
    Inventory inv;

    [SetUp]
    public void Setup()
    {
        inv = new Inventory();
    }

    [Test]
    public void Test1()
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
}
