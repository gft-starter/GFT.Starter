using Application.Factories;
using Core.Models;
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
        public void WhenCreateCar_thenICanReadItsProperties()
        {
            //arrange
            var id = Guid.Empty;
            var plate = "XBA-1122";
            var brand = "Palio";
            var model = "fire 1.0";
            var year = 2000;
            var color = "Preto";
            var allFactory = new AllFactory();
            var carFactory = allFactory.Create("car");
            //act
            var car = carFactory.Create();

            //assert
            Assert.AreEqual(car.Id, id);
            Assert.AreEqual(car.Plate, plate);
            Assert.AreEqual(car.Color, color);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.Year, year);
            Assert.AreEqual(car.Brand, brand);
        }
        //[Test]
        //public void whenCreateVehicle_AndAssingAndOwner_ThenICanFindTheOwner()
        //{

        //    //arrenge
        //    var model = "Palio";
        //    var year = 2008;
        //    var brand = "Fiat";
        //    var color = "Black";
        //    var plate = "DBZ-8000";
        //    var idowner = Guid.NewGuid(Owner);
        //    var ownerFactory = new OwnersFactory();
        //    var carFactory = new CarsFactory();
        //    var owner = ownerFactory.Create();

        //    //act
        //    var car = carFactory.Create( brand, plate, color, year,  model);

        //    //assert
        //    Assert.AreEqual(car.OwnerId, owner.Id);

        //}

    }
}