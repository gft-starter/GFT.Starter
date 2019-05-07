using Application.Factories;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ServiceOrderTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenCreateServiceOrder_thenICanReadItsProperties()
        {
            //arrange
            var id = Guid.Empty;
            var idCar = Guid.Empty;
            var idService = Guid.Empty;
            var quantity = 02;
            var allFactory = new AllFactory();
            var serviceOrdersFactory = allFactory.Create("serviceOrder");
            //act
            var serviceOrders = serviceOrdersFactory.Create();

            //assert
            Assert.AreEqual(serviceOrders.Id, id);
            Assert.AreEqual(serviceOrders.CarId, idCar);
            Assert.AreEqual(serviceOrders.ServiceId, idService);
            Assert.AreEqual(serviceOrders.Quantity, quantity);
            
        }

    }
}