namespace ChessLibrary;

public interface IPiece
{
    PieceTypes Type { get; }

    Position Position { get; }

    PieceColors Color { get; }

    IList<Position> GetLegalMoves();
}
