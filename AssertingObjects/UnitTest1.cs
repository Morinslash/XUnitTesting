namespace AssertingObjects;

public class UnitTest1
{
    [Fact]
    public void TestNumberFactory_Even()
    {
        var numberFactory = new NumberFactory();
        var result = numberFactory.WrapInType(2);
        Assert.IsType<Even>(result);
    }
    
    [Fact]
    public void TestNumberFactory_Odd()
    {
        var numberFactory = new NumberFactory();
        var result = numberFactory.WrapInType(3);
        Assert.IsType<Odd>(result);
    }
    
    [Fact]
    public void TestNumberFactory_Generic()
    {
        var numberFactory = new NumberFactory();
        var result = numberFactory.WrapInType(3);
        Assert.IsAssignableFrom<INumber>(result);
    }
    
    [Fact]
    public void TestNumberFactory_Odd_Unwrap()
    {
        var numberFactory = new NumberFactory();
        var result = numberFactory.WrapInType(3);
        var oddNumber = Assert.IsType<Odd>(result);
        Assert.Equal(3, oddNumber.Number);
    }
}

public class NumberFactory
{
    public INumber WrapInType(int number)
    {
        if (number%2==0)
        {
            return new Even(number);
        }

        return new Odd(number);
    }
}

public class Odd : INumber
{
    public readonly int Number;

    public Odd(int number)
    {
        Number = number;
    }
}

public class Even : INumber
{
    public readonly int Number;

    public Even(int number)
    {
        Number = number;
    }
}

public interface INumber
{
}