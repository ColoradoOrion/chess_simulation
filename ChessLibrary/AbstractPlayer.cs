namespace ChessLibrary;

public abstract class AbstractPlayer : IPlayer
{
    public abstract PlayerTypes Type { get; }
    private Dictionary<Position, IPiece> _pieces = [];


    /// <summary>
    /// The player takes a turn
    /// </summary>
    /// <returns>An IPiece if one is captured during the turn, null if not</returns>
    public IPiece? TakeTurn()
    {
        return null;
    }

    public IEnumerable<IPiece> Pieces
    {
        get
        {
            return _pieces.Values;
        }
    }

    public IPiece? GetPieceByPosition(Position position)
    {
        var query = _pieces.FirstOrDefault((piece) => piece.Value.Position == position);

        return query.Value.Position.IsValid ? query.Value : null;
    }
}