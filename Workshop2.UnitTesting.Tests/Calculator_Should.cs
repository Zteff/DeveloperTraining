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
    
    [Theory]
    [InlineData(new int[]{1,1}, 2)]
    [InlineData(new int[]{1,1,1}, 3)]
    public void ReturnsCorrectResults_When_ArrayOnlyContainsMoreThanOneNumber(int[] numbersToAdd, int expectedResult)
    {
        //Arrange
        var sut = new Calculator();

        //Act
        var result = sut.Add(numbersToAdd);

        //Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData(new int[]{-1,1}, 1)]
    public void ReturnsCorrectResults_When_ArrayContainsNegativeNumber(int[] numbersToAdd, int expectedResult)
    {
        //Arrange
        var sut = new Calculator();

        //Act
        var result = sut.Add(numbersToAdd);

        //Assert
        Assert.Equal(expectedResult, result);
    }
}