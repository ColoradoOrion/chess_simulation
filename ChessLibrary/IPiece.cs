namespace ChessLibrary;

public interface IPiece
{
    char Icon { get; }
    PieceTypes Type { get; }

    Position Position { get; }

    ConsoleColor Color { get; }

    IList<Position> GetLegalMoves();

    void Move(Position newPosition);
}
