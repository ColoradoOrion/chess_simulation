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
        for (var c = 0; c <= Position.MaxDimensionValue; ++c)
        {
            var coordinate = $"{(char)(c + Position.CharOffset)}{c + 1}";
            var position = new Position(coordinate);
            Assert.IsTrue(position.IsValid, $"{c}: {coordinate} - {position.Column}:{position.Row}");
            Assert.That(position.Column, Is.EqualTo(c));
            Assert.That(position.Row, Is.EqualTo(c));
            Assert.That(position.ToString(), Is.EqualTo(coordinate));
        }
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
                Assert.IsTrue(Position.IsColumnRowValid(column, row));
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
                Assert.IsFalse(Position.IsColumnRowValid(column, row));
            }
        }

        for (var row = Position.MaxDimensionValue + 1; row < Position.MaxDimensionValue + 100; ++row)
        {
            for (var column = Position.MinDimensionValue; column < Position.MaxDimensionValue; ++column)
            {
                Assert.IsFalse(Position.IsColumnRowValid(column, row));
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
                Assert.IsFalse(Position.IsColumnRowValid(column, row));
            }
        }

        for (var row = Position.MinDimensionValue; row < Position.MaxDimensionValue; ++row)
        {
            for (var column = Position.MaxDimensionValue + 1; column < Position.MaxDimensionValue + 100; ++column)
            {
                Assert.IsFalse(Position.IsColumnRowValid(column, row));
            }
        }
    }
}