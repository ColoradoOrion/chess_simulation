using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChessLibrary;
/// <summary>
/// Chess convention has columns A through H running left to right 
/// and rows running 1 through 8 from bottom to top.
/// Internally to this application, we are running rows 0-7 top to bottom
/// and columns 0-7 left to right for easier math.
/// </summary>
/// <remarks>
/// Position is Immutable. We want the piece to get a new position so it can keep track
/// if it has moved in the past.
/// </remarks>
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

    private string? _stringRepresentation = null;

    public Position(int column, int row)
    {
        SetPosition(column, row);
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

    private bool SetPosition(int column, int row)
    {
        if (IsPositionValid(column, row))
        {
            _row = row;
            _column = column;
            char character = (char)(_column + CharOffset);
            _stringRepresentation = $"{character}{row + 1}";

            return true;
        }

        return false;
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

    public bool IsValid
    {
        get
        {
            return _column > -1 && _row > -1 && !string.IsNullOrEmpty(_stringRepresentation);
        }
    }

    public static bool IsPositionValid(int column, int row)
    {
        return row >= MinDimensionValue && row <= MaxDimensionValue && column >= MinDimensionValue && column <= MaxDimensionValue;
    }

    public static bool IsPositionValid(Position position)
    {
        return IsPositionValid(position.Column, position.Row);
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

    public override int GetHashCode()
    {
        return HashCode.Combine(_column, _row);
    }

    public override bool Equals(object? obj)
    {
        if (obj is Position right && obj.GetType() == GetType())
        {
            return right._column == _column
            && right._row == _row
            && right._stringRepresentation == _stringRepresentation;
        }

        return false;
    }

    public static bool operator ==(Position a, Position b)
    {
        // Examples show null checks. Not sure how null would be passed here,
        // So removing for simplicity
        return a.Equals(b);
    }

    public static bool operator !=(Position a, Position b)
    {
        return !(a == b);
    }

    public override string? ToString()
    {
        return _stringRepresentation;
    }
}