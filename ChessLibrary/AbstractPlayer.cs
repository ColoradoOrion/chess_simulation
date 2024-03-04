namespace ChessLibrary;

public abstract class AbstractPlayer : IPlayer
{
    public abstract PlayerTypes Type { get; }


    /// <summary>
    /// The player takes a turn
    /// </summary>
    /// <returns>An IPiece if one is captured during the turn, null if not</returns>
    public IPiece? TakeTurn()
    {
        return null;
    }
}