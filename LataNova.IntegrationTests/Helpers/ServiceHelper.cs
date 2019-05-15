using Application.Factories;
using Core.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LataNova.IntegrationTests.Helpers
{
    public static class ServiceHelper
    {
        public static Service CreateRandomService()
        {
            var description = Utils.RandomString(7);
            var name = Utils.RandomString(10);
            var value = (float)new Random().NextDouble();
            return Factories.Service.Create(description, name, value);
        }

        public static void AssertService(Service a, Service b)
        {
            Assert.AreEqual(a.Id, b.Id);
            Assert.AreEqual(a.Description, b.Description);
            Assert.AreEqual(a.Name, b.Name);
            Assert.AreEqual(a.Value, b.Value);
        }
    }
}
