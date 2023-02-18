using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockT
{
    [Flags]
    public enum TriangleType
    {
        Oxygon,
        Obtuse,
        Right,
        Scalene,
        Isosceles,
        Equilateral
    }
}
