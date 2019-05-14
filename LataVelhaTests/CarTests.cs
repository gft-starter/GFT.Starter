using GFT.Starter.Application.Factories;
using GFT.Starter.Application.Singleton;
using GFT.Starter.Core.Models;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenCreateCar_ThenICanReadItsProperties()
        {
            //arrange
            var model = "Palio";
            var year = 2008;
            var brand = "FIAT";
            var color = "Preto";
            var plate = "ABC-1234";

            //act
            var car = Singleton.CarFactory.Create();

            //assert
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(year, car.Year);
            Assert.AreEqual(brand, car.Brand);
            Assert.AreEqual(color, car.Color);
            Assert.AreEqual(plate, car.Plate);
        }

        [Test]
        public void WhenCreateCar_AndAssignAnOwner_ThenICanFindTheOwner()
        {
            //arrange
            var plate = "ABC-1234";
            var brand = "Fiat";
            var model = "Uno";
            var color = "Preto";
            var year = 1993;

            //act
            var owner = Singleton.OwnerFactory.Create();
            var car = Singleton.CarFactory.Create(plate, brand, model, color, year, owner.Id, owner);

            //assert
            Assert.AreEqual(car.OwnerId, owner.Id);
            Assert.AreEqual(car.Owner, owner);
        }

        [Test]
        public void WhenCreateCar_AndCreateOwner_AndAssignOwner_AndUpdateCarProperties_ThenICanSeenNewPropertiesValues()
        {
            //arrange
            var plate = "ABC-1234";
            var brand = "Fiat";
            var model = "Uno";
            var color = "Preto";
            var year = 1993;
            var newPlate = "DEF-1234";
            var newBrand = "Chrevolet";
            var newModel = "Onyx";
            var newColor = "Prata";
            var newYear = 2016;

            //act
            var owner = Singleton.OwnerFactory.Create();
            var car = Singleton.CarFactory.Create(plate, brand, model, color, year, owner.Id, owner);
            var updatedCar = Singleton.CarFactory.Update(car, newPlate, newBrand, newModel, newColor, newYear, owner.Id);

            //assert
            Assert.AreEqual(updatedCar.Plate, newPlate);
            Assert.AreEqual(updatedCar.Brand, newBrand);
            Assert.AreEqual(updatedCar.Model, newModel);
            Assert.AreEqual(updatedCar.Color, newColor);
            Assert.AreEqual(updatedCar.Year, newYear);

            Assert.AreNotEqual(car.Model, updatedCar.Model);
            Assert.AreNotEqual(car.Plate, updatedCar.Plate);
            Assert.AreNotEqual(car.Brand, updatedCar.Brand);
            Assert.AreNotEqual(car.Color, updatedCar.Color);
            Assert.AreNotEqual(car.Year, updatedCar.Year);

            Assert.IsNotInstanceOf<Owner>(updatedCar);
            Assert.IsInstanceOf<Car>(updatedCar);
        }
    }
}