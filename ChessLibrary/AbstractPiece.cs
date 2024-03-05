namespace ChessLibrary;

public abstract class AbstractPiece : IPiece
{
    protected Position _position;
    protected ConsoleColor _color;

    protected bool _hasMoved = false;

    protected AbstractPiece()
    {
        _position = new Position(-1, -1);
    }

    protected AbstractPiece(Position position, ConsoleColor color)
    {
        _position = position;
        _color = color;
    }

    public abstract PieceTypes Type { get; }

    public abstract char Icon { get; }

    public Position Position
    {
        get
        {
            return _position;
        }
    }

    public ConsoleColor Color
    {
        get
        {
            return _color;
        }
    }

    // TODO: provide opponent pieces
    public abstract IList<Position> GetLegalMoves();


    public void Move(Position newPosition)
    {
        if (newPosition.IsValid)
        {
            _hasMoved = true;
            _position = newPosition;
        }
    }
}