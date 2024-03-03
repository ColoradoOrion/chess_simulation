using System.Text;

namespace ChessLibrary;
/*
Chess convention has columns A through H running left to right 
and rows running 1 through 8 from bottom to top.

Internally to this application, we are running rows 0-7 top to bottom
and columns 0-7 left to right for easier math.
*/
public struct Position
{
    public static readonly int MinDimensionValue = 0;
    public static readonly int MaxDimensionValue = 7;

    public static readonly int CharOffset = 65;

    private int _row = -1;
    private int _column = -1;

    private readonly string? _stringRepresentation = null;

    public Position(int column, int row)
    {
        if (IsColumnRowValid(column, row))
        {
            _row = row;
            _column = column;
            char character = (char)(_column + Position.CharOffset);
            _stringRepresentation = $"{character}{row + 1}";
        }
    }

    public Position(string coordinate)
    {
        var columnRow = ParseCoordinate(coordinate);
        if (columnRow.HasValue)
        {
            _column = columnRow.Value.Item1;
            _row = columnRow.Value.Item2;
            _stringRepresentation = coordinate;
        }
    }

    public bool IsValid
    {
        get
        {
            return _column > -1 && _row > -1 && !String.IsNullOrEmpty(_stringRepresentation);
        }

    }

    public override string? ToString()
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

    public static bool IsColumnRowValid(int column, int row)
    {
        return row >= MinDimensionValue && row <= MaxDimensionValue && column >= MinDimensionValue && column <= MaxDimensionValue;
    }

    public static (int, int)? ParseCoordinate(string coordinate)
    {
        if (coordinate.Length == 2)
        {
            int column = coordinate[0] - CharOffset;
            if (column >= MinDimensionValue && column <= MaxDimensionValue)
            {
                if (int.TryParse(coordinate.AsSpan(1, 1), out int row))
                {
                    --row; // To account for human-readable adjustment to internal value
                    if (row >= MinDimensionValue && row <= MaxDimensionValue)
                    {
                        return (column, row);
                    }
                }
            }
        }

        return null;
    }

    public static string? ColumnRowToCoordinate(int row, int column)
    {
        if (row < 0 && row > 7)
        {

        }

        return null;
    }
}