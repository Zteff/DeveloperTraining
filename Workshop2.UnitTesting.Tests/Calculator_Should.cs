namespace Workshop2.UnitTesting.Tests;

public class Calculator_Should
{
    [Fact]
    public void Return0_When_ArrayIsEmpty()
    {
        //Arrange
        var sut = new Calculator();
        var emptyArray = Array.Empty<int>();

        //Act
        var result = sut.Add(emptyArray);

        //Assert
        Assert.Equal(0, result);
    }
    
    [Fact]
    public void ReturnsNumber_When_ArrayOnlyContainsOneNumber()
    {
        //Arrange
        var sut = new Calculator();
        var number = 1;
        var numberArray = new int[] { number };

        //Act
        var result = sut.Add(numberArray);

        //Assert
        Assert.Equal(number, result);
    }
}