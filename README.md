# Simplified Chess

This project is a demonstration of using .NET Core to play chess. It's *mostly* accurate. See the Assumptions and Unimplemented Features below. When testing with WSL, it was found that setting the console's background color affected the text color, regardless of what ForegroundColor was used. Blue and Red pieces worked best on Black and White backgrounds. Hence the color scheme.

## Playing the game
1. Start the game.
1. Decide whether the first player is a human or computer player.
1. Decide whether the second player is a human or computer player.
1. Go
    1. Human players select a piece and choose a valid move
    1. Computer players randomly select a piece and a valid move
1. The game ends when the opposing king has been captured
1. Restart the game or quit.

## Assumptions
- Red always goes first.
- For the sake of simplicity, this exercise doesn't fully  determine legal moves. In this game, a move is valid if a potential move either:
    - ends on the board.
    - ends on a free space.
    - ends on an opponent's space.

That is, the program does't look to see if there are pieces blocking the path of the piece as it travels.

- Computer players will pause 1 second between turns.

## Unimplemented Features
- Check to see if there are other pieces in the way of a move.
- Different levels of computer opponent.
    - Random is implemented.
    - Aggressive is not. It's there to show a potential alternative and example of another derived class
- The ability to save the game.
- The ability to recall a game.
- Configuration beyond a hard-coded config file.

## Development TODO
- Factory to generate pieces
- render the board
- determine legal moves


### Structure

    Board
        Game
            BluePlayer
            RedPlayer
            ActivePlayer

            Play()
                ActivePlayer.Go()
                CheckWin
            Render()
            Initialize()
                [{"A1", Rook}, {"B1", Knight}, ...]


    IPlayer
    AbstractPlayer
        Pieces<position, IPiece>[]
    Player:HumanPlayer
    Player:ComputerPlayer
    Player:ComputerPlayer:RandomPlayer
    Player:ComputerPlayer:AgressivePlayer

    FindPieceByPosition()

    Go()
        ChoosePiece()
            By Coordinate (human) / Random (computer)
        GetPossibleMoves()
        ChooseMove()
        return captured piece = Move()

    Position
        _row 0, 7
        _column 0, 7

        ToString() - 1, 1, = "B2"
        FromCoordinate(string)


    IPiece
    AbstractPiece
        King
        Queen
        Rook
        Bishop
        Knight
        Pawn
