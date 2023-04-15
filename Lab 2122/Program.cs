using System.Numerics;

namespace Lab_2122 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            Ellipse ellipse = new Ellipse();
            for (int i = 0;;)
            {
                string temp;
                PrintMainMenu();
                temp = Console.ReadLine().ToLower();
                if (temp == "new")
                {
                    try
                    {
                        SetEllipseCoordinates(ref ellipse);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }

                    i++;
                }
                else if (temp == "check" && i > 0)
                {
                    if (ellipse.CheckIfEllipse())
                    {
                        Console.WriteLine("\nДана фігура є еліпсом");
                    }
                    else
                    {
                        Console.WriteLine("\nДана фігура не є еліпсом");
                    }
                }
                else if (temp == "coordinates" && i > 0)
                {
                    PrintCoordinates(ref ellipse);
                }
                else if (temp == "eccentricity" && i > 0)
                {
                    Console.WriteLine($"\nЕксцентриситет еліпса = {ellipse.GetEccentricity}");
                }
                else if (temp == "major" && i > 0)
                {
                    Console.WriteLine($"\nДовжина великої півосі = {ellipse.GetRadiusX}\nПовна довжина великої осі = {ellipse.GetFullRadiusX}");
                }
                else if (temp == "minor" && i > 0)
                {
                    Console.WriteLine($"\nДовжина малої півосі = {ellipse.GetRadiusY}\nПовна довжина малої осі = {ellipse.GetFullRadiusY}");
                }
                else if (temp == "focuslength" && i > 0)
                {
                    Console.WriteLine($"\nФокальна відстань = {ellipse.GetLineLength}");
                }
                else if (temp == "area" && i > 0)
                {
                    Console.WriteLine($"\nПлоща еліпса = {ellipse.GetEllipseArea}");
                }
                else if (temp == "clear")
                {
                    Console.Clear();
                }
                else if (temp == "end")
                {
                    Console.Clear();
                    break;
                }
            } //end for
        }

        static void SetEllipseCoordinates(ref Ellipse ellipse)
        {
            Vector2 leftFocus, rightFocus, topCoordinates, bottomCoordinates;
            Ellipse tempEllipse;
            try
            {
                //лівий фокус
                Console.Write("\nВведіть координату X лівого фокуса: ");
                leftFocus.X = Single.Parse(Console.ReadLine());
                Console.Write("Введіть координату Y лівого фокуса: ");
                leftFocus.Y = Single.Parse(Console.ReadLine());

                //правий фокус
                Console.Write("Введіть координату X правого фокуса: ");
                rightFocus.X = Single.Parse(Console.ReadLine());
                Console.Write("Введіть координату Y правого фокуса: ");
                rightFocus.Y = Single.Parse(Console.ReadLine());

                //верхня координата
                Console.Write("Введіть координату X верхньої вершини малої вісі: ");
                topCoordinates.X = Single.Parse(Console.ReadLine());
                Console.Write("Введіть координату Y верхньої вершини малої вісі: ");
                topCoordinates.Y = Single.Parse(Console.ReadLine());

                //нижня координата 
                Console.Write("Введіть координату X нижньої вершини малої вісі: ");
                bottomCoordinates.X = Single.Parse(Console.ReadLine());
                Console.Write("Введіть координату Y нижньої вершини малої вісі: ");
                bottomCoordinates.Y = Single.Parse(Console.ReadLine());
                tempEllipse = new Ellipse(leftFocus, rightFocus, topCoordinates, bottomCoordinates);
                if (!tempEllipse.CheckIfEllipse())
                {
                    Console.Clear();
                    Console.WriteLine("\nДана фігура не є еліпсом!\n");
                    SetEllipseCoordinates(ref ellipse);
                }
                else
                {
                    ellipse = tempEllipse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nНекоректні дані координат!");
                SetEllipseCoordinates(ref ellipse);
            }
        }

        static void PrintCoordinates(ref Ellipse ellipse)
        {
            Console.WriteLine($"\nКоординати лівої вершини велокої осі еліпса = {ellipse.GetLeftCoordinates}\n" +
                              $"Координати правої вершини велокої осі еліпса = {ellipse.GetRightCoordinates}\n" +
                              $"Координати верхньої вершини малої осі еліпса = {ellipse.GetTopCoordinates}\n" +
                              $"Координати нижньої вершини малої осі еліпса = {ellipse.GetBottomCoordinates}\n" +
                              $"Координати центра еліпса = {ellipse.GetCenter}");
        }

        static void PrintMainMenu()
        {
            Console.WriteLine("\nВведіть доступну команду:\n" +
                              "(new - створити/заново створити еліпс)\n" +
                              "(check - перевірка, чи є фігура еліпсом)\n" +
                              "(coordinates - координати вершин еліпса та його цента)\n" +
                              "(eccentricity - ексцентриситет еліпса)\n"+
                              "(major - довжина великої півосі еліпса)\n" +
                              "(minor - довжина малої півосі еліпса)\n" +
                              "(FocusLength - фокальна відстань)\n" +
                              "(area - площа еліпса)\n" +
                              "(clear - почистити консоль)\n" +
                              "(end - завершити веконання програми)\n");
        }
    }
}