
namespace ChessLibrary;

public class Pawn : AbstractPiece
{
    /// <summary>
    /// A collection of potential moves defined as column/row relative to the current position.
    /// In this case, we can go 1 or two spaces forward, or attack diagonally,
    /// but only if another piece is there
    /// </summary>
    private static readonly List<ValueTuple<int, int>> _nextMoves = new List<ValueTuple<int, int>>()
    {
        (0, 1),
        (0, 2),
        (1, 1),
        (-1, 1)
    };
    public override PieceTypes Type => PieceTypes.Pawn;

    public override char Icon => 'i';

    public override IList<Position> GetLegalMoves()
    {
        throw new NotImplementedException();
    }
}