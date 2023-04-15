using System.Numerics;

namespace Lab_2122;

public class Line : Point
{
    protected Vector2 SecondCoordinates;
    protected float LineLength;

    public float GetLineLength => LineLength;

    public Line()
    {
        
    }
    public Line(Vector2 firstPoint, Vector2 secondPoint) : base(firstPoint)
    {
        SecondCoordinates = secondPoint;
        LineLength = CalculateLength(FirstCoordinates,SecondCoordinates);
    }
    protected float CalculateLength(Vector2 firstCoordinates, Vector2 secondCoordinates)
    {
        return (float)Math.Round(Math.Sqrt(Math.Pow(secondCoordinates.X - firstCoordinates.X, 2) + Math.Pow(secondCoordinates.Y - firstCoordinates.Y, 2)), 1);
    }
}