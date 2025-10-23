using RectangleApp;
using Xunit;

namespace RectangleApp.Tests;

public class RectangleTests
{
    [Fact]
    public void CalculateArea_ValidDimensions_ReturnsCorrectArea()
    {
        // AAA
        // Arrange (przygotowanie danych)
        var rectangle = new Rectangle(5, 3);

        // Act (wykonanie testowanej operacji)
        var area = rectangle.CalculateArea();

        // Assert (sprawdzenie wyniku)
        Assert.Equal(15, area);
    }

    [Fact]
    public void CalculateArea_LargeDimensions_ReturnsCorrectArea()
    {
        var rectangle = new Rectangle(1000, 2000);
        var area = rectangle.CalculateArea();
        Assert.Equal(2_000_000, area);
    }
}
