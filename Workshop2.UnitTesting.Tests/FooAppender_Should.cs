namespace Workshop2.UnitTesting.Tests;

public class FooAppender_Should
{
    [Fact]
    public void AppendFoo_When_AppendFooIsCalled()
    {
        // Arrange
        var sut = new FooAppender();
        var myString = "Some string";

        // Act
        var result = sut.AppendFoo(myString);

        // Assert
        Assert.Equal($"{myString}Foo", result);
    }
}