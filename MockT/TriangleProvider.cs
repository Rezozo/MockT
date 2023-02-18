using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MockT
{
    public class TriangleProvider : ITriangleProvider
    {

        private readonly IMongoCollection<Triangle> Collection;

        public TriangleProvider(IMongoCollection<Triangle> collection)
        {
            Collection = collection;
        }

        public Triangle GetById(long id)
        {
            return Collection.Find(t => t.Id == id).FirstOrDefault();
        }

        public List<Triangle> GetAll()
        {
            return Collection.Find(t => true).ToList();
        }

        public void Save(Triangle triangle)
        {
            Collection.InsertOne(triangle);
        }
    }
}
