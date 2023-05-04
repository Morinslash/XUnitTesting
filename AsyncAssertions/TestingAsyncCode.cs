using Xunit.Sdk;

namespace AsyncAssertions;

public class TestingAsyncCode
{
    private Func<int, int, Task<int>> _asyncSum = async (a, b) =>
    {
        var sum = a + b;
        await Task.Delay(500);
        return sum;
    };
    
    [Fact]
    public async Task BasicAssertions()
    {
        var result = await _asyncSum(2,4);
        Assert.Equal(6,result);
    }
    
    // Bad test: blocking on an async method
    [Fact]
    public void TestBlockingAsyncMethod()
    {
        var resultTask = _asyncSum(2, 4);
        var result = resultTask.Result; // Blocks until the result is available
        Assert.Equal(6, result);
    }

    // Bad test: not using async/await
    [Fact]
    public void TestWithoutAsyncAwait()
    {
        var result = _asyncSum(2, 4).GetAwaiter().GetResult();
        Assert.Equal(6, result);
    }

    // Bad test: not waiting for the task to complete
    [Fact]
    public async Task TestWithoutWait()
    {
        var resultTask = _asyncSum(2, 4);
        Assert.Equal(6, await resultTask); // This may pass or fail depending on the timing
    }
}