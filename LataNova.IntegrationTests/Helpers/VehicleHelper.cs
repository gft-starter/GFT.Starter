using Application.Factories;
using Core.Models;
using NUnit.Framework;
using System;

namespace LataNova.IntegrationTests.Helpers
{
    public static class VehicleHelper
    {
        public static Vehicle CreateRandomVehicle()
        {
            var plate = Utils.RandomString(7);
            var brand = Utils.RandomString(10);
            var model = Utils.RandomString(10);
            var color = Utils.RandomString(10);
            var year = new Random().Next(1920, 2020);
            var ownerId = new Guid("bec6bc69-cca7-41ed-bb43-074b4a3dfa97");
            return Factories.Vehicle.Create(brand, color, model, plate, year, ownerId);
        }

        public static void AssertVehicle(Vehicle a, Vehicle b)
        {
            Assert.AreEqual(a.Id, b.Id);
            Assert.AreEqual(a.Model, b.Model);
            Assert.AreEqual(a.OwnerId, b.OwnerId);
            Assert.AreEqual(a.Plate, b.Plate);
            Assert.AreEqual(a.Year, b.Year);
        }
    }
}
