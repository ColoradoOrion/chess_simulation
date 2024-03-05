namespace Tests;

using ChessLibrary;

public class KingTests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void KingInstance()
    {
        var position = new Position("D4");
        var king = new King(position, ConsoleColor.DarkBlue);

        Assert.That(king.Position, Is.EqualTo(position));
    }

    [Test]
    public void KingType()
    {
        var position = new Position("D4");
        var king = new King(position, ConsoleColor.DarkBlue);

        Assert.That(king.Type, Is.EqualTo(PieceTypes.King));
    }

    [Test]
    public void KingChar()
    {
        var king = new King(new Position("D4"), ConsoleColor.DarkBlue);
        Assert.That(king.Icon, Is.EqualTo('k'));
    }
}