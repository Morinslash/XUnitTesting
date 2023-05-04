namespace EventsAssertions;

public class EventPublisher
{
    protected virtual void OnTestEvent(TestEventArgs eventArgs)
    {
        TestEventFire?.Invoke(this,eventArgs);
    }

    public event EventHandler<TestEventArgs>? TestEventFire;

    public void StartTestEvent(string message)
    {
        OnTestEvent(new TestEventArgs(message));
    }
}