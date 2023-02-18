using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockT
{
    public class TriangleService : ITriangleService
    {
        public bool IsValidTriangle(double a, double b, double c)
        {
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                return false;
            }
            return true;
        }

        public TriangleType GetTypeSides(double a, double b, double c)
        {
            if (!IsValidTriangle(a, b, c))
            {
                return 0;
            }
            else if (Math.Pow(a, 2) + Math.Pow(b, 2) < Math.Pow(c, 2) || Math.Pow(a, 2) + Math.Pow(c, 2) < Math.Pow(b, 2)
               || Math.Pow(b, 2) + Math.Pow(c, 2) < Math.Pow(a, 2))
            {
                return TriangleType.Obtuse;
            }
            else if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2) || Math.Pow(a, 2) + Math.Pow(c, 2) == Math.Pow(b, 2)
                      || Math.Pow(b, 2) + Math.Pow(c, 2) == Math.Pow(a, 2))
            {
                return TriangleType.Right;
            }
            else
            {
                return TriangleType.Oxygon;
            }
        }

        public TriangleType GetTypeCorners(double a, double b, double c)
        {
            if (!IsValidTriangle(a, b, c))
            {
                return 0;
            }
            else if (a == b && b == c)
            {
                return TriangleType.Equilateral;
            }
            else if (a == c || b == c || b == a)
            {
                return TriangleType.Isosceles;
            }
            else
            {
                return TriangleType.Scalene;
            }
        }

        public double GetArea(double a, double b, double c)
        {
            if (!IsValidTriangle(a, b, c))
            {
                return 0;
            }

            double p = (a + b + c) / 2.0;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return Math.Floor(s);
        }


        public void Save(long id, double a, double b, double c, TriangleType type, double area)
        {
            Triangle triangle = new Triangle(id, a, b, c, type, area);
        }
    }
}
