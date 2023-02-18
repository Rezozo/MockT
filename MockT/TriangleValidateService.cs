using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockT
{
    public class TriangleValidateService : ITriangleValidateService
    {
        private readonly ITriangleProvider triangleProvider;
        private readonly ITriangleService triangleService;

        public TriangleValidateService(ITriangleProvider triangleProvider, ITriangleService triangleService)
        {
            this.triangleProvider = triangleProvider;
            this.triangleService = triangleService;
        }
        public bool IsAllValid()
        {
            foreach (var triangle in triangleProvider.GetAll())
            {
                if (triangleService.IsValidTriangle(triangle.A, triangle.B, triangle.C) == false)
                {
                    return false;
                }

                if (triangleService.GetArea(triangle.A, triangle.B, triangle.C) != triangle.Area)
                {
                    return false;
                }

                if (triangleService.GetTypeSides(triangle.A, triangle.B, triangle.C) != triangle.Type
                    && triangleService.GetTypeCorners(triangle.A, triangle.B, triangle.C) != triangle.Type)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsValid(long id)
        {
            Triangle triangle = triangleProvider.GetById(id);

            if (triangleService.IsValidTriangle(triangle.A, triangle.B, triangle.C) == false)
            {
                return false;
            }

            if (triangleService.GetArea(triangle.A, triangle.B, triangle.C) != triangle.Area) {
                return false;
            }

            if (triangleService.GetTypeSides(triangle.A, triangle.B, triangle.C) != triangle.Type 
                && triangleService.GetTypeCorners(triangle.A, triangle.B, triangle.C) != triangle.Type)
            {
                return false;
            }

            return true;
        }

    }
}
