using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockT
{
    public interface ITriangleProvider
    {
        Triangle GetById(long id);
        List<Triangle> GetAll();
        void Save(Triangle triangle);
    }
}
