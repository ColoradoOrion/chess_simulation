namespace ChessLibrary;

public class King : AbstractPiece
{
    /// <summary>
    /// A collection of potential moves defined as column/row relative to the current position.
    /// In this case, positions are one step away, starting "north" one square and going clockwise.
    /// </summary>
    /// <remarks>
    /// I don't intend to handle castling yet.
    /// </remarks>
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

    public King(Position position, ConsoleColor color) : base(position, color)
    {
    }

    public override char Icon => 'k';

    public override IList<Position> GetLegalMoves()
    {
        var nextCandidates = new List<Position>();
        foreach (var nextCandidate in _nextMoves)
        {
            if (Position.IsPositionValid(Position.Column + nextCandidate.Item1, Position.Row + nextCandidate.Item2))
            {
                nextCandidates.Add(new Position(Position.Column + nextCandidate.Item1, Position.Row + nextCandidate.Item2));
            }
        }

        return nextCandidates;
    }

    public override PieceTypes Type { get { return PieceTypes.King; } }
}