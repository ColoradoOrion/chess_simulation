namespace ChessLibrary;
/*
Chess convention has columns A through H running left to right 
and rows running 1 through 8 from bottom to top.

Internally to this application, we are running rows 0-7 top to bottom
and columns 0-7 left to right for easier math.
*/
public struct Position
{
    private int _row = 0;
    private int _column = 0;

    private string _stringRepresentation;

    public Position(int row, int column)
    {
        _row = row;
        _column = column;
    }

    public Position(string coordinate)
    {

    }

    public override string ToString()
    {
        return _stringRepresentation;
    }

    public int Row
    {
        get
        {
            return _row;
        }
    }

    public int Column
    {
        get
        {
            return _column;
        }
    }

    public static string ColumnRowToCoordinate(int row, int column){
        if(row < 0 || row > 7){

        }

        return null;
    }
}