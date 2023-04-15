using System.Net.Security;
using System.Numerics;

namespace Lab_2122;

public class Ellipse : Line
{
    private Vector2 Center;

    //координати точок малої вісі
    private Vector2 TopCoordinates;
    private Vector2 BottomCoordinates;

    //координати точок великої вісі
    private Vector2 LeftCoordinates;
    private Vector2 RightCoordinates;

    //площа еліпса
    private float EllipseErea;

    //довжина великої півосі
    private float RadiusX;

    //довжина малої півосі
    private float RadiusY;


    private float FullRadiusX;
    private float FullRadiusY;

    //ексцентриситет
    private float Eccentricity;

    public float GetRadiusX => RadiusX;
    public float GetRadiusY => RadiusY;
    public float GetFullRadiusX => FullRadiusX;
    public float GetFullRadiusY => FullRadiusY;

    public float GetEllipseArea => EllipseErea;
    public float GetEccentricity => Eccentricity;
    public Vector2 GetCenter => Center;

    public Vector2 GetTopCoordinates => TopCoordinates;
    public Vector2 GetBottomCoordinates => BottomCoordinates;
    public Vector2 GetLeftCoordinates => LeftCoordinates;
    public Vector2 GetRightCoordinates => RightCoordinates;

    public Ellipse()
    {
    }

    public Ellipse(Vector2 firstFocus, Vector2 secondFocus, Vector2 topCoordinates, Vector2 bottomCoordinates) : base(firstFocus, secondFocus)
    {
        TopCoordinates = topCoordinates;
        BottomCoordinates = bottomCoordinates;
        SetCenter();
        SetRadii();
        SetEccentricity();
        SetEllipseArea();
        SetLeftAndRightXCoordinates();
    }

    private void SetCenter()
    {
        Center = new Vector2((float)Math.Round((SecondCoordinates.X + FirstCoordinates.X) / 2,1), (float)Math.Round((SecondCoordinates.Y + FirstCoordinates.Y) / 2,1));
    }

    private void SetEccentricity()
    {
        if (RadiusX > RadiusY)
        {
            Eccentricity = (float)Math.Round(Math.Sqrt(1 - Math.Pow(RadiusY / RadiusX, 2)), 1);
        }
        else
        {
            Eccentricity = (float)Math.Round(Math.Sqrt(1 - Math.Pow(RadiusX / RadiusY, 2)), 1);
        }
    }

    private void SetEllipseArea()
    {
        EllipseErea = (float)Math.Round((Math.PI * RadiusX * RadiusY), 1);
    }

    private void SetRadii()
    {
        RadiusY = CalculateLength(TopCoordinates, Center);
        float FocusToCenterLength = CalculateLength(FirstCoordinates, Center);
        RadiusX = (float)Math.Round(Math.Sqrt(Math.Pow(RadiusY, 2) + Math.Pow(FocusToCenterLength, 2)), 1);
        FullRadiusX = (float)Math.Round((RadiusX * 2),1);
        FullRadiusY = (float)Math.Round((RadiusY * 2),1);
    }

    private void SetLeftAndRightXCoordinates()
    {
        LeftCoordinates = new Vector2((float)Math.Round(Center.X - RadiusX,1), Center.Y);
        RightCoordinates = new Vector2((float)Math.Round(Center.X + RadiusX,1), Center.Y);
    }

    public bool CheckIfEllipse()
    {
        bool result = true;
        float LeftFoucsXLength = CalculateLength(FirstCoordinates, Center);
        float RightFocusXLength = CalculateLength(SecondCoordinates, Center);
        if (LeftFoucsXLength != RightFocusXLength) result = false;

        float TopRadiusYLength = CalculateLength(TopCoordinates, Center);
        float BottomRadiusYLength = CalculateLength(BottomCoordinates, Center);
        if (TopRadiusYLength != BottomRadiusYLength) result = false;

        return result;
    }
}