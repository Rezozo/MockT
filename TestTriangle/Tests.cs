using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MockT;
using Moq;
using System.Collections.Generic;
using MongoDB.Driver;

namespace TestTriangle
{
    /*
    [TestClass]
    public class TriangleProviderIntegrationTest
    {
        private ITriangleProvider triangleProvider;
        private TriangleValidateService service;
        [TestInitialize]

        public void Init()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("triangle");
            var collection = database.GetCollection<Triangle>("Triangles");

            triangleProvider = new TriangleProvider(collection);
            service = new TriangleValidateService(triangleProvider, new TriangleService());
        }

        [TestMethod]
        public void TestGetByIdT()
        {
            triangleProvider.Save(new Triangle(1, 3, 4, 5, TriangleType.Scalene, 6));
            var actualTriangle = triangleProvider.GetById(1);

            Assert.IsTrue(service.IsValid(actualTriangle.Id));
        }
        [TestMethod]
        public void TestGetAllT()
        {
            triangleProvider.Save(new Triangle(2, 3, 4, 6, TriangleType.Scalene, 5));
            triangleProvider.Save(new Triangle(3, 6, 8, 6, TriangleType.Isosceles, 17));

            Assert.IsTrue(service.IsAllValid());
        }



        [TestMethod]
        public void TestGetByIdF()
        {
            triangleProvider.Save(new Triangle(2, 3213, 3214, 512, TriangleType.Scalene, 6));
            var actualTriangle = triangleProvider.GetById(2);

            Assert.IsFalse(service.IsValid(actualTriangle.Id));
        }


        [TestMethod]
        public void TestGetAllF()
        {
            triangleProvider.Save(new Triangle(3, 5, 5, 55, TriangleType.Right, 10));
            triangleProvider.Save(new Triangle(4, 6, 32, 6, TriangleType.Isosceles, 17));

            Assert.IsFalse(service.IsAllValid());
        }
    }
    */

        [TestClass]
        public class TriangleProviderTest
        {
            private TriangleValidateService service;
            private Mock<ITriangleProvider> mockProvider;

            [TestInitialize]
            public void TestInitialize()
            {
                mockProvider = new Mock<ITriangleProvider>();
                service = new TriangleValidateService(mockProvider.Object, new TriangleService());
            }

            [TestMethod]
            public void GetByIdTestFalse()
            {
                mockProvider.Setup(p => p.GetById(1)).Returns(new Triangle(1, 532, 5, 235, TriangleType.Equilateral, 0.0));
                Assert.IsFalse(service.IsValid(1));
            }
            [TestMethod]
            public void GetByIdTestTrue()
            {
                mockProvider.Setup(p => p.GetById(2)).Returns(new Triangle(2, 3, 3, 3, TriangleType.Equilateral, 3));
                Assert.IsTrue(service.IsValid(2));
            }

            [TestMethod]
            public void GetAllTestTrue()
            {
                mockProvider.Setup(p => p.GetAll()).Returns(new List<Triangle>
                {
                    new Triangle(1, 4, 4, 4, TriangleType.Equilateral, 6),
                    new Triangle(2, 10, 10, 10, TriangleType.Equilateral,  43),
                    new Triangle(3, 7, 24, 25, TriangleType.Right,  84)
                });
                Assert.IsTrue(service.IsAllValid());
            }

            [TestMethod]
            public void GetAllTestFalse()
            {
                mockProvider.Setup(p => p.GetAll()).Returns(new List<Triangle>
                {
                    new Triangle(1, 443, 214, 43, TriangleType.Equilateral, 0.0),
                    new Triangle(2, 1012, 4310, 1320, TriangleType.Equilateral, 0.0),
                    new Triangle(3, 7, 2434, 25, TriangleType.Equilateral, 0.0)
                });
                Assert.IsFalse(service.IsAllValid());
            }
        }
}
