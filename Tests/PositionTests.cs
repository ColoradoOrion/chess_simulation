namespace Tests;

using ChessLibrary;

public class PositionTests
{

    [SetUp]
    public void Setup()
    {

    }


    [Test]
    public void ConstructionFromColumnAndRow()
    {
        var position = new Position(0, 0);
        Assert.NotNull(position.ToString());
        Assert.That(position.ToString(), Is.EqualTo("A1"));
    }

    [Test]
    public void InvalidFromColumnAndRow()
    {
        var position = new Position(-1, -1);
        Assert.IsNull(position.ToString());
    }

    [Test]
    public void ConstructionFromCoordinate()
    {
        for (var rowAndCol = 0; rowAndCol <= Position.MaxDimensionValue; ++rowAndCol)
        {
            var coordinate = $"{(char)(rowAndCol + Position.CharOffset)}{rowAndCol + 1}";
            var position = new Position(coordinate);
            Assert.IsTrue(position.IsValid, $"{rowAndCol}: {coordinate} - {position.Column}:{position.Row}");
            Assert.That(position.Column, Is.EqualTo(rowAndCol));
            Assert.That(position.Row, Is.EqualTo(rowAndCol));
            Assert.That(position.ToString(), Is.EqualTo(coordinate));
        }
    }

    [Test]
    public void ParseCoordinateValid()
    {
        var coord = Position.ParseCoordinate("A1");
        Assert.IsNotNull(coord);

        Assert.That(coord.Value.Item1, Is.EqualTo(0));
        Assert.That(coord.Value.Item2, Is.EqualTo(0));
    }

    [Test]
    public void ParseCoordinateEmpty()
    {
        var coord = Position.ParseCoordinate("");
        Assert.That(coord, Is.Null);
    }

    [Test]
    public void CheckHash()
    {
        var p1 = new Position("A1");
        var p2 = new Position("A1");

        Assert.That(p1.GetHashCode(), Is.EqualTo(p2.GetHashCode()));
    }

    [Test]
    public void CheckUnequalHash()
    {
        var p1 = new Position("A1");
        var p2 = new Position("B1");

        Assert.That(p1.GetHashCode(), Is.Not.EqualTo(p2.GetHashCode()));
    }

    [Test]
    public void AreEqual()
    {
        var p1 = new Position("A1");
        var p2 = new Position("A1");

        Assert.That(p1, Is.EqualTo(p2));
    }

    [Test]
    public void AreEqualSame()
    {
        var p1 = new Position("A1");
        var p2 = new Position("A1");

        bool test = p1.Equals(p2);
        Assert.That(test, Is.True);
    }

    [Test]
    public void AreEqualOperator()
    {
        var p1 = new Position("A1");
        var p2 = new Position("A1");

        bool test = p1 == p2;
        Assert.That(test, Is.True);
    }

    [Test]
    public void AreNotEqualOperator()
    {
        var p1 = new Position("A1");
        var p2 = new Position("B3");

        bool test = p1 != p2;
        Assert.That(test, Is.True);
    }

    [Test]
    public void AreEqualCaseInsensitive()
    {
        var p1 = new Position("A1");
        var p2 = new Position("a1");

        Assert.That(p1, Is.EqualTo(p2));
    }

    public void AreNotEqual()
    {
        var p1 = new Position("A1");
        var p2 = new Position("B1");

        Assert.That(p1, Is.Not.EqualTo(p2));
    }

    [Test]
    public void InvalidColumn()
    {
        var position = new Position("P8");
        Assert.IsFalse(position.IsValid);
        Assert.That(position.Column, Is.EqualTo(-1));
        Assert.That(position.Row, Is.EqualTo(-1));
        Assert.IsNull(position.ToString());
    }

    [Test]
    public void InvalidRowLow()
    {
        var position = new Position("H0");
        Assert.IsFalse(position.IsValid);
        Assert.That(position.Column, Is.EqualTo(-1));
        Assert.That(position.Row, Is.EqualTo(-1));
        Assert.IsNull(position.ToString());
    }
    [Test]
    public void InvalidRowHigh()
    {
        var position = new Position("H9");
        Assert.IsFalse(position.IsValid);
        Assert.That(position.Column, Is.EqualTo(-1));
        Assert.That(position.Row, Is.EqualTo(-1));
        Assert.IsNull(position.ToString());
    }


    [Test]
    public void CoordinateTooSmall()
    {
        var position = new Position("P");
        Assert.IsFalse(position.IsValid);
        Assert.That(position.Column, Is.EqualTo(-1));
        Assert.That(position.Row, Is.EqualTo(-1));
        Assert.IsNull(position.ToString());
    }

    [Test]
    public void CoordinateTooLarge()
    {
        var position = new Position("P44");
        Assert.IsFalse(position.IsValid);
        Assert.That(position.Column, Is.EqualTo(-1));
        Assert.That(position.Row, Is.EqualTo(-1));
        Assert.IsNull(position.ToString());
    }

    [Test]
    public void ValidRowsAndColumns()
    {
        for (var row = Position.MinDimensionValue; row < Position.MaxDimensionValue; ++row)
        {
            for (var column = Position.MinDimensionValue; column < Position.MaxDimensionValue; ++column)
            {
                Assert.IsTrue(Position.IsPositionValid(column, row));
            }
        }
    }

    [Test]
    public void ValidPosition()
    {
        for (var row = Position.MinDimensionValue; row < Position.MaxDimensionValue; ++row)
        {
            for (var column = Position.MinDimensionValue; column < Position.MaxDimensionValue; ++column)
            {
                Assert.IsTrue(Position.IsPositionValid(new Position(column, row)));
            }
        }
    }

    [Test]
    public void InvalidRows()
    {
        for (var row = Position.MinDimensionValue - 100; row < Position.MinDimensionValue - 1; ++row)
        {
            for (var column = Position.MinDimensionValue; column < Position.MaxDimensionValue; ++column)
            {
                Assert.IsFalse(Position.IsPositionValid(column, row));
            }
        }

        for (var row = Position.MaxDimensionValue + 1; row < Position.MaxDimensionValue + 100; ++row)
        {
            for (var column = Position.MinDimensionValue; column < Position.MaxDimensionValue; ++column)
            {
                Assert.IsFalse(Position.IsPositionValid(column, row));
            }
        }
    }

    [Test]
    public void InvalidColumns()
    {
        for (var row = Position.MinDimensionValue; row < Position.MaxDimensionValue; ++row)
        {
            for (var column = Position.MinDimensionValue - 100; column < Position.MinDimensionValue - 1; ++column)
            {
                Assert.IsFalse(Position.IsPositionValid(column, row));
            }
        }

        for (var row = Position.MinDimensionValue; row < Position.MaxDimensionValue; ++row)
        {
            for (var column = Position.MaxDimensionValue + 1; column < Position.MaxDimensionValue + 100; ++column)
            {
                Assert.IsFalse(Position.IsPositionValid(column, row));
            }
        }
    }
}