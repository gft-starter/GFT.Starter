using Application.Factories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LataNova.UnitTests
{
    public class ServiceOrderTest
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void WhenCreateServiceOrder_AndAssignService_AndAssignVehicle_ThenICanReadItsProperties()
        {
            // Arrange
            var quantity = 2;
            var service = Factories.Service.Create();
            var vehicle = Factories.Vehicle.Create();

            // Act
            var serviceOrder = Factories.ServiceOrder.Create(service.Id, vehicle.Id, quantity);

            // Assert
            Assert.AreEqual(serviceOrder.ServiceId, service.Id);
            Assert.AreEqual(serviceOrder.VehicleId, vehicle.Id);
            Assert.AreEqual(serviceOrder.Quantity, quantity);
        }
    }
}
