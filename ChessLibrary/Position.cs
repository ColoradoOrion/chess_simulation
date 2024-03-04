using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChessLibrary;
/*
Chess convention has columns A through H running left to right 
and rows running 1 through 8 from bottom to top.

Internally to this application, we are running rows 0-7 top to bottom
and columns 0-7 left to right for easier math.
*/
public class Position
{
    public static readonly int MinDimensionValue = 0;
    public static readonly int MaxDimensionValue = 7;

    /// <summary>
    /// The difference between the character code and it's integer value.
    /// </summary>
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
        coordinate = coordinate.ToUpper();
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
            return _column > -1 && _row > -1 && !string.IsNullOrEmpty(_stringRepresentation);
        }
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_column, _row);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Position right || obj.GetType() != GetType())
        {
            return false;
        }

        return right._column == _column
        && right._row == _row
        && right._stringRepresentation == _stringRepresentation;
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

    /// <summary>
    /// Generate a new Position based on the current position plus an offset
    /// </summary>
    /// <param name="columnOffset"></param>
    /// <param name="rowOffset"></param>
    /// <returns>A new position if it's valid. Null if it's not</returns>
    public Position Move(int columnOffset, int rowOffset)
    {
        return new Position(Column + columnOffset, Row + rowOffset);
    }

    public static bool IsColumnRowValid(int column, int row)
    {
        return row >= MinDimensionValue && row <= MaxDimensionValue && column >= MinDimensionValue && column <= MaxDimensionValue;
    }

    public static (int, int)? ParseCoordinate(string coordinate)
    {
        if (string.IsNullOrEmpty(coordinate))
        {
            return null;
        }

        if (coordinate.Length == 2)
        {
            int column = coordinate[0] - CharOffset;

            if (column >= MinDimensionValue && column <= MaxDimensionValue)
            {
                if (int.TryParse(coordinate.AsSpan(1, 1), out int row))
                {
                    --row; // To account for human-readable (one-based) to internal (zero-based) value convertion
                    if (row >= MinDimensionValue && row <= MaxDimensionValue)
                    {
                        return (column, row);
                    }
                }
            }
        }

        return null;
    }
}