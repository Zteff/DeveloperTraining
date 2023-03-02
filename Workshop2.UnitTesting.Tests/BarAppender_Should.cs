using Microsoft.Extensions.Logging;
using Moq;

namespace Workshop2.UnitTesting.Tests;

public class BarAppender_Should
{
    [Fact]
    public void AppendFoo_When_AppendBarIsCalled()
    {
        // Arrange
        var loggerMock = new Mock<ILogger>();
        var sut = new BarAppender(loggerMock.Object);
        var myString = "Some string";

        // Act
        var result = sut.AppendBar(myString);

        // Assert
        Assert.Equal($"{myString}Bar", result);
    }
    
    [Fact]
    public void CallLoggerOnce_When_AppendBarIsCalled()
    {
        // Arrange
        var loggerMock = new Mock<ILogger>();
        var sut = new BarAppender(loggerMock.Object);
        var myString = "Some string";

        // Act
        var result = sut.AppendBar(myString);

        // Assert
        loggerMock.Verify(x => x.Log(LogLevel.Information, $"Appending Bar to {myString}"));
    }
}