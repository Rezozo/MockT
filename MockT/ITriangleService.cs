using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockT
{
    public interface ITriangleService
    {
        bool IsValidTriangle(double a, double b, double c);
        TriangleType GetTypeSides(double a, double b, double c);
        TriangleType GetTypeCorners(double a, double b, double c);
        double GetArea(double a, double b, double c);
        void Save(long id, double a, double b, double c, TriangleType type, double area);
    }
}
