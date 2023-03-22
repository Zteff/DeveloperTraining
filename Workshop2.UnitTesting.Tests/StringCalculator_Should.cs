using Moq;

namespace Workshop2.UnitTesting.Tests;

public class StringCalculator_Should
{
    
    [Fact]
    public void Return0_When_CalledEmptyString()
    {
        //Arrange
        var taxableMock = new Mock<ITaxable>();
        var sut = new StringCalculator(taxableMock.Object);
        var stringNumber = "";

        //Act
        var result = sut.Add(stringNumber);

        //Assert
        Assert.Equal(0,result);
    }
    
    [Fact]
    public void ReturnInt_When_CalledWithStringParameter()
    {
        //Arrange
        var taxableMock = new Mock<ITaxable>();
        var sut = new StringCalculator(taxableMock.Object);
        var stringNumber = "1";

        //Act
        var result = sut.Add(stringNumber);

        //Assert
        Assert.Equal(1,result);
        Assert.IsType<int>(result);
    }
    
    [Fact]
    public void ReturnSum_When_CalledWithPositiveCommaSeparatedStringParameter()
    {
        //Arrange
        var taxableMock = new Mock<ITaxable>();
        var sut = new StringCalculator(taxableMock.Object);
        var stringNumber = "1,2,3";

        //Act
        var result = sut.Add(stringNumber);

        //Assert
        Assert.Equal(6,result);
    }
    
    [Fact]
    public void ReturnSumOfOnlyPositiveNumber_When_CalledWithPositiveAndNegativeCommaSeparatedStringParameter()
    {
        //Arrange
        var taxableMock = new Mock<ITaxable>();
        var sut = new StringCalculator(taxableMock.Object);
        var stringNumber = "1,2,-3";

        //Act
        var result = sut.Add(stringNumber);

        //Assert
        Assert.Equal(3,result);
    }
    
    [Fact]
    public void ThrowArgumentException_When_CalledWithStringParameterThatIsNotANumber()
    {
        //Arrange
        var taxableMock = new Mock<ITaxable>();
        var sut = new StringCalculator(taxableMock.Object);
        var stringNumber = "bob";

        //Assert
        Assert.Throws<ArgumentException>(() => sut.Add(stringNumber));
    }
    
    [Fact]
    public void ReturnSum_When_CalledWithStringParameterThatEndsWithComma()
    {
        //Arrange
        var taxableMock = new Mock<ITaxable>();
        var sut = new StringCalculator(taxableMock.Object);
        var stringNumber = "1,2,3,";
        
        //Act
        var result = sut.Add(stringNumber);

        //Assert
        Assert.Equal(6,result);
    }
    
    [Fact]
    public void ReturnExactSum_When_SumIsOdd()
    {
        //Arrange
        var taxableMock = new Mock<ITaxable>();
        taxableMock.Setup(x => x.IsTaxable(It.IsAny<int>())).Returns(false);
        var sut = new StringCalculator(taxableMock.Object);
        var stringNumber = "1,2";

        //Act
        var result = sut.Add(stringNumber);

        //Assert
        Assert.Equal(3,result);
    }
    
    [Fact]
    public void ReturnSumAndAHalf_When_SumIsEven()
    {
        //Arrange
        var taxableMock = new Mock<ITaxable>();
        taxableMock.Setup(x => x.IsTaxable(It.IsAny<int>())).Returns(true);
        var sut = new StringCalculator(taxableMock.Object);
        var stringNumber = "1,2,3";

        //Act
        var result = sut.Add(stringNumber);

        //Assert
        Assert.Equal(9,result);
    }
}