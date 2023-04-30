namespace BasicAssertions;

public class TestingStrings
{
    private readonly Func<string, string, string> _concatStrings = (firstName, lastName) => $"{firstName} {lastName}";

    [Fact]
    public void Strict_Equality()
    {
        var firstName = "John";
        var lastName = "Doe";
        
        Assert.Equal("John Doe", _concatStrings(firstName, lastName));
    }

    [Fact]
    public void Equality_Ignore_Casing()
    {
        var firstName = "John";
        var lastName = "DOE";
        
        Assert.Equal("John Doe", _concatStrings(firstName, lastName), ignoreCase:true); 
    }

    [Fact]
    public void String_Starts_With()
    {
        var firstName = "John";
        var lastName = "Doe";
        
        Assert.StartsWith(firstName, _concatStrings(firstName, lastName)); 
    }
    
    [Fact]
    public void String_Ends_With()
    {
        var firstName = "John";
        var lastName = "Doe";
        
        Assert.EndsWith(lastName, _concatStrings(firstName, lastName));
    }

    [Fact]
    public void Contains_Sequence()
    {
        var firstName = "John";
        var lastName = "Doe";
        
        Assert.Contains("hn D", _concatStrings(firstName, lastName));  
    }

    [Fact]
    public void Assert_On_Regular_Expressions()
    {
        var firstName = "Jon";
        var lastName = "Toe";
        
        Assert.Matches("Jo(|h)n (T|D)oe", _concatStrings(firstName, lastName));
    }

    [Fact]
    public void Negations()
    {
        var firstName = "John";
        var lastName = "Doe";
        
        Assert.DoesNotContain("xyz", _concatStrings(firstName, lastName));   
        Assert.DoesNotContain("xyz", _concatStrings(firstName, lastName));
    }
}