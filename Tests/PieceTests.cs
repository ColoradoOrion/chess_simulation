namespace Tests;

using ChessLibrary;

public class PieceTests
{
    [SetUp]
    public void Setup()
    {
    }


    [Test]
    public void Moves()
    {
        var legalNext = new List<Position>(){
            new("D5"),
            new("E5"),
            new ("E4"),
            new ("E3"),
            new ("D3"),
            new ("C3"),
            new ("C4"),
            new ("C5")
        };

        var start = new Position("D4");
        var king = PieceFactory.CreatePiece(PieceTypes.King, start, PieceColors.Blue);

        Assert.That(king, Is.Not.Null);

        var positions = king.GetLegalMoves();

        CollectionAssert.AreEquivalent(legalNext, positions);
    }

    [Test]
    public void KingTopLeftCorner()
    {
        var legalNext = new List<Position>(){
            new("H7"),
            new("G7"),
            new ("G8")
        };

        var start = new Position("H8");
        var king = PieceFactory.CreatePiece(PieceTypes.King, start, PieceColors.Blue);

        Assert.That(king, Is.Not.Null);

        var positions = king.GetLegalMoves();

        CollectionAssert.AreEquivalent(legalNext, positions);
    }
}