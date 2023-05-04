namespace EventsAssertions;

public class TestEventArgs : EventArgs
{
    public string Message { get; }

    public TestEventArgs(string message)
    {
        Message = message;
    }
}