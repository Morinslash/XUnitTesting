namespace BasicAssertions;

public class TestingBooleans
{
    private readonly Func<int, int, bool> _areNumbersEqual = (a, b) => a == b;
    [Fact]
    public void Assert_Is_True()
    {
        Assert.True(_areNumbersEqual(2,2));
    }

    [Fact]
    public void Assert_Is_False()
    {
        Assert.False(_areNumbersEqual(1,2));
    }
}