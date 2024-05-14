namespace Interest.Tests;

[TestFixture]
public class InterestTest
{
    [Test]
    public void PMT()
    {
        var actual = Interest.PMT(0.01, 360, 100000);
        Assert.That(actual, Is.EqualTo(-1028.6125969255042d));
    }

    [Test]
    public void IPMT()
    {
        var actual = Interest.IPMT(0.01, 1, 360, 100000, 30000);
        Assert.That(actual, Is.EqualTo(-1000));
    }

    [Test]
    public void PPMT()
    {
        var actual = Interest.PPMT(0.01, 1, 360, 100000);
        Assert.That(actual, Is.EqualTo(-28.612596925504249));
    }

    [Test]
    public void FV()
    {
        var actual = Interest.FV(0.02, 12, 100, 400);
        Assert.That(actual, Is.EqualTo(-1848.5056906377456));
    }
}
