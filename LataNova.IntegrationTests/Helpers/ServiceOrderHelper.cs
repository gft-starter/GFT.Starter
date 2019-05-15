using Application.Factories;
using Core.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LataNova.IntegrationTests.Helpers
{
    public static class ServiceOrderHelper
    {
        public static ServiceOrder CreateRandomServiceOrder()
        {
            var vehicleId = new Guid("a371b1ca-e0f5-489a-9a81-1d139a7da6f1");
            var serviceId = new Guid("ce0c893c-b0ae-4a54-ac54-06b7a43d418d");
            var qnt = new Random().Next();
            return Factories.ServiceOrder.Create(serviceId, vehicleId, qnt);
        }

        public static void AssertService(ServiceOrder a, ServiceOrder b)
        {
            Assert.AreEqual(a.Id, b.Id);
            Assert.AreEqual(a.ServiceId, b.ServiceId);
            Assert.AreEqual(a.VehicleId, b.VehicleId);
            Assert.AreEqual(a.Quantity, b.Quantity);
        }
    }
}
