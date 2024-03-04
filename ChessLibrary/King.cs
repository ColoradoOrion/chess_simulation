namespace ChessLibrary;

public class King : AbstractPiece
{
    /// <summary>
    /// A collection of potential moves defined as column/row offsets from the current position.
    /// In this case, positions are one step away, starting "north" one square and going clockwise.
    /// </summary>
    private static readonly List<ValueTuple<int, int>> _nextMoves = new List<ValueTuple<int, int>>()
    {
        (0, 1),
        (1, 1),
        (1, 0),
        (1, -1),
        (0, -1),
        (-1, -1),
        (-1, 0),
        (-1, 1)
    };

    private King() : base() { }

    public King(Position position, PieceColors color) : base(position, color)
    {
    }

    public override IList<Position> GetLegalMoves()
    {
        var nextCandidates = new List<Position>();
        foreach (var nextCandidate in _nextMoves)
        {
            var nextPosition = Position.Move(nextCandidate.Item1, nextCandidate.Item2);
            if (nextPosition.IsValid)
            {
                nextCandidates.Add(nextPosition);
            }
        }
        return nextCandidates;
    }

    public override PieceTypes Type { get { return PieceTypes.King; } }
}