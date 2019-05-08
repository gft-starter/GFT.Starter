using GFT.Starter.Application.Factories;
using GFT.Starter.Core.Models;
using NUnit.Framework;
using System;


namespace Tests
{
    public class CarTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenCreateCar_ThenICanReadItsProperties()
        {
            //arrange
            var factory = new CarFactory();
            var id = Guid.Empty;
            var model = "Palio";
            var year = 2008;
            var brand = "FIAT";
            var color = "Preto";
            var plate = "ABC1234";
            var allFactory = AllFactory.CarFactory;

            //act
            var car = allFactory.Create(); 

            //assert
            Assert.AreEqual(car.Id, id);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.Year, year);
            Assert.AreEqual(car.Brand, brand);
            Assert.AreEqual(car.Color, color);
            Assert.AreEqual(car.Plate, plate);
        }

        [Test]
        public void WhenCreateVehicle_AndAssignAnOwner_ThenICanFindTheOwner()
        {
            //arrange          
            var model = "Palio";
            var year = 2008;
            var brand = "FIAT";
            var color = "Preto";
            var plate = "ABC1234";
            var ownerFactory = new OwnerFactory();
            var carFactory = new CarFactory();
            var owner = ownerFactory.Create();

            //act
            var car = carFactory.Create(model, year,brand,color,plate,owner.Id);

            //assert
            Assert.AreEqual(car.OwnerId, owner.Id);
        }

        [Test]
        public void WhenCreateCar_AndCreateOwner_AndAssignOwner_AndUpdateCarProperties()
        {
            //arrange          
            var model = "Palio";
            var year = 2008;
            var brand = "FIAT";
            var color = "Preto";
            var plate = "ABC1234";

            var newModel = "Ford KA";
            var newYear = 2017;
            var newBrand = "Ford";
            var newColor = "branco";
            var newPlate = "DEI4567";

            var ownerFactory = new OwnerFactory();
            var carFactory = new CarFactory();

            //act
            var owner = ownerFactory.Create();
            var car = carFactory.Create(model, year, brand, color, plate, owner.Id);
            var updateCar = carFactory.Update(car, newModel, newYear, newBrand, newColor, newPlate, owner.Id);

            //assert
            Assert.AreEqual(updateCar.Model, newModel);
            Assert.AreEqual(updateCar.Year, newYear);
            Assert.AreEqual(updateCar.Brand, newBrand);
            Assert.AreEqual(updateCar.Color, newColor);
            Assert.AreEqual(updateCar.Plate, newPlate);
        }
    }
}