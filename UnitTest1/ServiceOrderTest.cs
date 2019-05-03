using GFT.Starter.Application;
using GFT.Starter.Application.Factories;
using GFT.Starter.Core.Models;
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
        public void WhenCreateServiceOrder_ThenICanReadItsProperties()
        {
            //arrange
            var id = Guid.Empty;
            var quantity = 10;

            var serviceOrderFactory = Singleton.ServiceOrderFactory;

            //act
            var serviceOrder = serviceOrderFactory.Create();

            //assert
            Assert.AreEqual(serviceOrder.Id, id);
            Assert.AreEqual(serviceOrder.Quantity, quantity);
        }
    }
}