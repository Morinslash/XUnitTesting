namespace BasicAssertions;

public class TestingNumerics
{
    private readonly Func<double, double, double> _add = (firstValue, secondValue) => firstValue + secondValue;

    [Fact]
    public void Equality()
    {
        Assert.Equal(3.5d, _add(2d, 1.5d));
    }

    [Fact]
    public void TestingRange()
    {
        var result = _add(2d, 1.5d);
        Assert.InRange(result, 3d, 4d);
        Assert.NotInRange(result, 5d, 8d);
        Assert.True(result is >= 3d and <= 4d, "Results is not in acceptable range");
        Assert.True(result >= 3d && result <= 4d);
    }

    [Fact]
    public void TestingPrecision()
    {
        Assert.Equal(4d, _add(2d, 1.5d), 0); 
    }
}