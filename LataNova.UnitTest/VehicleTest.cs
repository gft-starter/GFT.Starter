using Application.Factories;
using Core.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LataNova.UnitTests
{
    public class VehicleTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void WhenCreateVehicle_ThenICanReadItsProperties()
        {
            // Arrange
            var factory = new VehicleFactory();
            var id = Guid.Empty;
            var brand = "Marca";
            var color = "Cor";
            var model = "Modelo";
            var plate = "PLACA";
            var year = 1234;

            // Act
            var vehicle = Factories.Vehicle.Create();

            // Assert
            Assert.AreEqual(vehicle.Id, id);
            Assert.AreEqual(vehicle.Brand, brand);
            Assert.AreEqual(vehicle.Color, color);
            Assert.AreEqual(vehicle.Model, model);
            Assert.AreEqual(vehicle.Plate, plate);
            Assert.AreEqual(vehicle.Year, year);
        }

        [Test]
        public void WhenCreateVehicle_AndAssignAnOwnerThenICanFindTheOwner()
        {
            // Arrange
            var model = "Modelo";
            var year = 2019;
            var brand = "Marca";
            var color = "Cor";
            var plate = "ABC1234";
            var owner = Factories.Owner.Create();

            // Act
            var vehicle = Factories.Vehicle.Create(brand, color, model, plate, year, owner.Id);

            // Assert
            Assert.AreEqual(vehicle.OwnerId, owner.Id);
        }

        [Test]
        public void WhenCreateVehicle_AndCreateOwner_AndAssignOwner_AndUpdateVehicleProperties_ThenICanSeeNewPropertiesValues()
        {
            // Arrange
            var model = "Modelo";
            var year = 2019;
            var brand = "Marca";
            var color = "Cor";
            var plate = "ABC1234";

            var newModel = "Novo Modelo";
            var newYear = 2020;
            var newBrand = "Nova Marca";
            var newColor = "Nova Cor";
            var newPlate = "CBA4321";

            // Act
            var owner = Factories.Owner.Create();
            var vehicle = Factories.Vehicle.Create(brand, color, model, plate, year, owner.Id);
            var updatedVehicle = Factories.Vehicle.Update(vehicle, newBrand, newColor, newModel, newPlate, newYear, owner.Id);

            // Assert
            Assert.AreEqual(updatedVehicle.Brand, newBrand);
            Assert.AreEqual(updatedVehicle.Color, newColor);
            Assert.AreEqual(updatedVehicle.Model, newModel);
            Assert.AreEqual(updatedVehicle.Plate, newPlate);
            Assert.AreEqual(updatedVehicle.Year, newYear);

            Assert.AreNotEqual(updatedVehicle.Brand, vehicle.Brand);
            Assert.AreNotEqual(updatedVehicle.Color, vehicle.Color);
            Assert.AreNotEqual(updatedVehicle.Model, vehicle.Model);
            Assert.AreNotEqual(updatedVehicle.Plate, vehicle.Plate);
            Assert.AreNotEqual(updatedVehicle.Year, vehicle.Year);

            Assert.IsInstanceOf(typeof(Vehicle), updatedVehicle);
        }
    }
}
