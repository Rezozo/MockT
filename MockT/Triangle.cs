using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockT
{
    public class Triangle
    {
        public long Id { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public TriangleType Type { get; set; }
        public double Area { get; set; }

        public Triangle(long id, double a, double b, double c, TriangleType type, double area)
        {
            Id = id;
            A = a;
            B = b;
            C = c;
            Type = type;
            Area = area;
        }
    }
}
