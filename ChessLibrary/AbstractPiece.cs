namespace ChessLibrary;

public abstract class AbstractPiece : IPiece
{
    protected Position _position;
    protected PieceColors _color;

    public abstract PieceTypes Type { get; }

    protected AbstractPiece()
    {
        _position = new Position(-1, -1);
    }

    protected AbstractPiece(Position position, PieceColors color)
    {
        _position = position;
        _color = color;
    }

    public Position Position
    {
        get
        {
            return _position;
        }
    }

    public PieceColors Color
    {
        get 
        {
            return _color;
        }
    }

    public abstract IList<Position> GetLegalMoves();

    public static bool IsOnTheBoard(Position position, int columnAdjustment, int rowAdjustment)
    {
        return position.Column + columnAdjustment <= Position.MaxDimensionValue
        && position.Column + columnAdjustment >= Position.MinDimensionValue
        && position.Row + rowAdjustment <= Position.MaxDimensionValue
        && position.Row + rowAdjustment >= Position.MinDimensionValue;

    }
}