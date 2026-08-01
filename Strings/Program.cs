// Compute the total area of shapes.
// Each input string is one shape:
// - "C r"      Circle (radius r)
// - "R w h"    Rectangle (width w, height h)
// - "T b h"    Triangle (base b, height h), area = 0.5*b*h

// Use an abstract base class and an interface for Area.
// Return total area rounded to 2 decimals (AwayFromZero).

// Input: shapes (string[])
// Output: totalArea (double)

// Constraints:
// 0 <= shapes.Length <= 1e5
// 0 <= dimensions <= 1e6
class Program
{
    public static double TotalArea(string[] shapes)
    {
        double totalArea = 0;

        foreach (string shape in shapes)
        {
            string[] parts = shape.Split(' ');
            string shapeType = parts[0];

            switch (shapeType)
            {
                case "C":
                    double radius = double.Parse(parts[1]);
                    totalArea += Math.PI * radius * radius;
                    break;
                case "R":
                    double width = double.Parse(parts[1]);
                    double height = double.Parse(parts[2]);
                    totalArea += width * height;
                    break;
                case "T":
                    double baseLength = double.Parse(parts[1]);
                    double triangleHeight = double.Parse(parts[2]);
                    totalArea += 0.5 * baseLength * triangleHeight;
                    break;
            }
        }

        return Math.Round(totalArea, 2, MidpointRounding.AwayFromZero);
    }

    public static void Main()
    {
        string[] shapes = { "C 3", "R 4 5", "T 6 7" };
        Console.WriteLine(TotalArea(shapes));
    }
}