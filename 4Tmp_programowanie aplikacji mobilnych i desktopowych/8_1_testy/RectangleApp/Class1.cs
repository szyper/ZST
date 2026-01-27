namespace RectangleApp;

public class Rectangle
{
    private readonly double _width;
    private readonly double _height;

    public Rectangle(double width, double height)
    {
        if (width <= 0 || height <= 0)
            throw new ArgumentException("Szerokośc i wysokość musi być liczbą dodatnią");

        _width = width;
        _height = height;
    }

    public double CalculateArea()
    {
        return _width * _height;
    }


}
