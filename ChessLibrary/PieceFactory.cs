namespace ChessLibrary;

public static class PieceFactory
{
    public static IPiece? CreatePiece(PieceTypes type, Position position, ConsoleColor color)
    {
        switch (type)
        {
            case PieceTypes.King:
                return new King(position, color);
            default:
                return null;
        }
    }
}