using GFT.Starter.Application;
using GFT.Starter.Application.Factories;
using GFT.Starter.Core.Models;
using NUnit.Framework;
using System;

namespace UnitTests
{
    public class OwnerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenCreateOwner_ThenICanReadItsProperties()
        {
            //arrange
            var id = Guid.Empty;
            var name = "Joazinho";
            var cpf = "123.456.789-12";
            var gender = 'M';

            var ownerFactory = Singleton.OwnerFactory;

            //act
            var owner = ownerFactory.Create();

            //assert
            Assert.AreEqual(owner.Id, id);
            Assert.AreEqual(owner.Name, name);
            Assert.AreEqual(owner.CPF, cpf);
            Assert.AreEqual(owner.Gender, gender);



        }
        [Test]
        public void WhenCreateCar_AndAssignAnOwner_ThenICanFindTheOwner()
        {
            //arrange
            var model = "Palio";
            var year = 2008;
            var brand = "Fiat";
            var color = "Preto";
            var plate = "DZY-0412";
            var ownerFactory = new OwnerFactory();
            var carFactory = new CarFactory();
            var owner = ownerFactory.Create();

            //act
            var car = carFactory.Create(model,year, brand, color, plate, owner.Id);

            //assert
            Assert.AreEqual(car.OwnerId, owner.Id);

        }
        [Test]
        public void WhenCreateCar_AndCreateOwner_AndAssignOwner_AndUpdateCarProperties_ThenICanFindTheOwner()
        {
            //arrange
            var model = "Palio";
            var year = 2008;
            var brand = "Fiat";
            var color = "Preto";
            var plate = "DZY-0412";
            var ownerFactory = new OwnerFactory();
            var carFactory = new CarFactory();

            var newModel = "Ford KA";
            var newYear = 2017;
            var newBrand = "Ford";
            var newColor = "White";
            var newPlate = "ABC-1234";
            

            //act
            var owner = ownerFactory.Create();
            var car = carFactory.Create(model, year, brand, color, plate, owner.Id);
            var updateCar = carFactory.Update(car, newModel, newYear, newBrand, newColor, newPlate, owner.Id);

            Assert.AreEqual(updateCar.Model, newModel);
            Assert.AreEqual(updateCar.Year, newYear);
            Assert.AreEqual(updateCar.Brand, newBrand);
            Assert.AreEqual(updateCar.Color, newColor);
            Assert.AreEqual(updateCar.Plate, newPlate);


            Assert.AreNotEqual(updateCar.Model, car.Model);
            Assert.AreNotEqual(updateCar.Year, car.Year);
            Assert.AreNotEqual(updateCar.Brand, car.Brand);
            Assert.AreNotEqual(updateCar.Color, car.Color);
            Assert.AreNotEqual(updateCar.Plate, car.Plate);


            Assert.IsNotInstanceOf(typeof(Owner), updateCar);
            Assert.IsInstanceOf(typeof(Car), updateCar);

        }
    }
}