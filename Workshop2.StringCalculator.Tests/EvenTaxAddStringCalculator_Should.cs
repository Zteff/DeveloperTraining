using Moq;
using Xunit;

namespace Workshop2.StringCalculator.Tests;

public class EvenTaxAddStringCalculator_Should
{
    private readonly Mock<ITaxable> _mockTaxable;
    private readonly EvenTaxAddStringCalculator _sut;

    public EvenTaxAddStringCalculator_Should()
    {
        _mockTaxable = new Mock<ITaxable>();
        _sut = new EvenTaxAddStringCalculator(_mockTaxable.Object);
    }
    
    [Fact]
    public void ReturnInt_When_AddCalledWithStringOfNumber()
    {
        // Arrange.
        const int number = 1;
        
        // Act.
        var result = _sut.Add(number.ToString());
        
        // Assert.
        Assert.IsType<int>(result);
    }
    
    [Fact]
    public void ReturnNumber_When_AddCalledWithStringOfNumber()
    {
        // Arrange.
        const int number = 1;
        
        _mockTaxable
            .Setup(x => x.IsTaxable(number))
            .Returns(IsEven(number));
        
        // Act.
        var result = _sut.Add(number.ToString());
        
        // Assert.
        var expectedSum = GetTaxedSum(number);
        Assert.Equal(expectedSum, result);
    }
    
    [Fact]
    public void ThrowArgumentException_When_AddCalledWithStringOfNonNumber()
    {
        // Act. Assert.
        Assert.Throws<ArgumentException>(() => _sut.Add("foo"));
    }
    
    [Fact]
    public void AddNumbers_When_AddCalledWithTwoNumbersAsString()
    {
        // Arrange.
        const int number1 = 1;
        const int number2 = 2;
        const int sum = number1 + number2;
        
        _mockTaxable
            .Setup(x => x.IsTaxable(sum))
            .Returns(IsEven(sum));
        
        // Act.
        var result = _sut.Add($"{number1},{number2}");
        
        // Assert.
        var expectedSum = GetTaxedSum(number1, number2);
        Assert.Equal(expectedSum, result);
    }
    
    [Fact]
    public void AddNumbers_When_AddCalledWithThreeNumbersAsString()
    {
        // Arrange.
        const int number1 = 1;
        const int number2 = 2;
        const int number3 = 3;
        const int sum = number1 + number2 + number3;
        
        _mockTaxable
            .Setup(x => x.IsTaxable(sum))
            .Returns(IsEven(sum));
        
        // Act.
        var result = _sut.Add($"{number1},{number2},{number3}");
        
        // Assert.
        var expectedSum = GetTaxedSum(number1, number2, number3);
        Assert.Equal(expectedSum, result);
    }
    
    [Fact]
    public void Return0_When_CalledWithEmptyString()
    {
        // Act.
        var result = _sut.Add($"");
        
        // Assert.
        Assert.Equal(0, result);
    }
    
    [Fact]
    public void IgnoreNegative_When_AddCalledWithSomeNegative()
    {
        // Arrange.
        const int number1 = 1;
        const int number2 = 2;
        const int negativeNumber = -3;
        const int sum = number1 + number2; // Ignore negative, as per business rules.
        
        _mockTaxable
            .Setup(x => x.IsTaxable(sum))
            .Returns(IsEven(sum));
        
        // Act.
        var result = _sut.Add($"{number1},{number2},{negativeNumber}");
        
        // Assert.
        var expectedSum = GetTaxedSum(number1, number2, negativeNumber);
        Assert.Equal(expectedSum, result);
    }
    
    [Fact]
    public void WorkAsExpected_When_AddCalledWithStringEndingInComma()
    {
        // Arrange.
        const int number1 = 1;
        const int number2 = 2;
        const int number3 = 3;
        const int sum = number1 + number2 + number3;
        
        _mockTaxable
            .Setup(x => x.IsTaxable(sum))
            .Returns(IsEven(sum));
        
        // Act.
        var result = _sut.Add($"{number1},{number2},{number3},");

        // Assert.
        var expectedSum = GetTaxedSum(number1, number2, number3);
        Assert.Equal(GetTaxedSum(expectedSum), result);
    }
    
    private static bool IsEven(int sum)
    {
        return sum % 2 == 0;
    }

    private static int GetTaxedSum(params int[] numbers)
    {
        var finalNumbersForSum = numbers
            .Where(number => number >= 0)
            .ToList();

        var sum = finalNumbersForSum.Sum();
        
        var expectedTaxedSum = IsEven(sum) ? sum + sum / 2 : sum;

        return expectedTaxedSum;
    }
}