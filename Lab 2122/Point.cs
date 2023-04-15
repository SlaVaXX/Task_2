using System.Numerics;

namespace Lab_2122;

public class Point
{
    protected Vector2 FirstCoordinates;

    public Point()
    {
    }

    public Point(Vector2 coordinates)
    {
        FirstCoordinates = coordinates;
    }
}