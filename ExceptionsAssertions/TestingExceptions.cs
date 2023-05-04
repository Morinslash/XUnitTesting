namespace ExceptionsAssertions;

public class TestingExceptions
{
    private Func<int, int> _badDivision = number => number / 0; 
    private Func<int, Task<int>> _badDivisionAsync = async (number)  =>
    {
        await Task.Delay(500);
        return number/0;
    }; 
    [Fact]
    public void Synchronous()
    {
        Assert.Throws<DivideByZeroException>(() => _badDivision(1));
    }
    
    [Fact]
    public async Task Asynchronous()
    {
        // It's important to add await before the assertion and make test method async, otherwise we might have false positive!
        await Assert.ThrowsAsync<DivideByZeroException>(async () => await _badDivisionAsync(1));
    }
    
    [Fact]
    public void CheckDerivedTypes()
    {
        Assert.ThrowsAny<ArithmeticException>(() => _badDivision(1)); 
    }
}