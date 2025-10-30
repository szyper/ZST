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

    [Theory]
    [InlineData(5, 3, 15)]
    [InlineData(10, 2, 20)]
    [InlineData(7.5, 4, 30)]
    [InlineData(0, 5, 0)]       // przypadek brzegowy
    [InlineData(-3, 2, -6)]     // przypadek z ujemną wartością
    public void CalculateArea_ValidDimensions_ReturnsCorrectArea_2(double width, double height, double expectedArea)
    {
      // Arrange
      var rectangle = new Rectangle(width, height);

      // Act
      var area = rectangle.CalculateArea();

      // Assert
      Assert.Equal(expectedArea, area);
    }

  [Fact]
  public void CalculateArea_ZeroWidthOrHeight_ReturnsZero()
  {
    var rectangle1 = new Rectangle(0, 5);
    var rectangle2 = new Rectangle(5, 0);

    Assert.Equal(0, rectangle1.CalculateArea());
    Assert.Equal(0, rectangle2.CalculateArea());
  }

  [Fact]
  public void Constructor_NegativeWidth_ThrowsArgumentException()
  {
    Assert.Throws<ArgumentException>(() => new Rectangle(-1, 5));
  }

  [Fact]
  public void Constructor_NegativeHeight_ThrowsArgumentException()
  {
    Assert.Throws<ArgumentException>(() => new Rectangle(5, -1));
  }
}
