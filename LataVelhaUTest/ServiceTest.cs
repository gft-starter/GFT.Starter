using Application.Factories;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenCreateService_thenICanReadItsProperties()
        {
            //arrange
            var id = Guid.Empty;
            var name = "Trocar pneus";
            var description = "troca do conjunto de pneus do veiculo";
            var value = 580.00;
            var allFactory = new AllFactory();
            var serviceFactory = allFactory.Create("service");
            //act
            var service = serviceFactory.Create();

            //assert
            Assert.AreEqual(service.Id, id);
            Assert.AreEqual(service.Name, name);
            Assert.AreEqual(service.Description, description);
            Assert.AreEqual(service.Value, value);
            
        }

    }
}