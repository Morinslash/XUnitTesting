namespace EventsAssertions;

public class TestingEvents
{
    [Fact]
    public void BasicEvent()
    {
        var eventPublisher = new EventPublisher();

        Assert.Raises<TestEventArgs>(
            handler => eventPublisher.TestEventFire += handler, // attach event handler
            handler => eventPublisher.TestEventFire -= handler, // detach event handler
            () => eventPublisher.StartTestEvent("hello!")); // invoke event
    }
    
    [Fact]
    public void BasicEvent_CheckArgs()
    {
        var eventPublisher = new EventPublisher();

        var args = Assert.Raises<TestEventArgs>(
            handler => eventPublisher.TestEventFire += handler, // attach event handler
            handler => eventPublisher.TestEventFire -= handler, // detach event handler
            () => eventPublisher.StartTestEvent("hello!")); // invoke event
        
        Assert.Equal("hello!", args.Arguments.Message);
    }
}