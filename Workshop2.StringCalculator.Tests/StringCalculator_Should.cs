using Xunit;

namespace Workshop2.StringCalculator.Tests;

public class StringCalculator_Should
{
    [Fact]
    public void ReturnInt_When_AddCalledWithStringOfNumber()
    {
        var sut = new StringCalculator();

        const int number = 1;
        var result = sut.Add(number.ToString());
        
        Assert.IsType<int>(result);
    }
    
    [Fact]
    public void ReturnNumber_When_AddCalledWithStringOfNumber()
    {
        var sut = new StringCalculator();

        const int number = 1;
        var result = sut.Add(number.ToString());
        
        Assert.Equal(number, result);
    }
    
    [Fact]
    public void ThrowArgumentException_When_AddCalledWithStringOfNonNumber()
    {
        var sut = new StringCalculator();

        Assert.Throws<ArgumentException>(() => sut.Add("foo"));
    }
    
    [Fact]
    public void AddNumbers_When_AddCalledWithTwoNumbersAsString()
    {
        var sut = new StringCalculator();

        const int number1 = 1;
        const int number2 = 2;
        var result = sut.Add($"{number1},{number2}");
        
        Assert.Equal(number1 + number2, result);
    }
    
    [Fact]
    public void AddNumbers_When_AddCalledWithThreeNumbersAsString()
    {
        var sut = new StringCalculator();

        const int number1 = 1;
        const int number2 = 2;
        const int number3 = 3;
        var result = sut.Add($"{number1},{number2},{number3}");
        
        Assert.Equal(number1 + number2 + number3, result);
    }
    
    [Fact]
    public void Return0_When_CalledWithEmptyString()
    {
        var sut = new StringCalculator();

        var result = sut.Add($"");
        
        Assert.Equal(0, result);
    }
    
    [Fact]
    public void IgnoreNegative_When_AddCalledWithSomeNegative()
    {
        var sut = new StringCalculator();

        const int number1 = 1;
        const int number2 = 2;
        const int negativeNumber = -3;
        var result = sut.Add($"{number1},{number2},{negativeNumber}");
        
        Assert.Equal(number1 + number2, result);
    }
    
    [Fact]
    public void WorkAsExpected_When_AddCalledWithStringEndingInComma()
    {
        var sut = new StringCalculator();

        const int number1 = 1;
        const int number2 = 2;
        const int number3 = 3;
        var result = sut.Add($"{number1},{number2},{number3},");
        
        Assert.Equal(number1 + number2 + number3, result);
    }
}