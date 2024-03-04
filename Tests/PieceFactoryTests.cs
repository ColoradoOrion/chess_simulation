using ChessLibrary;

public class PieceFactoryTests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void CreatePieces()
    {
        foreach (PieceTypes type in Enum.GetValues(typeof(PieceTypes)))
        {
            var piece = PieceFactory.CreatePiece(type, new Position("A1"), PieceColors.Blue);
            if (type == PieceTypes.Undefined)
            {
                Assert.IsNull(piece);
            }
            else
            {
                Assert.IsNotNull(piece);
                Assert.That(piece.Position, Is.EqualTo(new Position("A1")));
                break; // TODO: remove once we have the other pieces
            }
        }
    }
}