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
    }
}