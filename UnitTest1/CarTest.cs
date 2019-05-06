using GFT.Starter.Application;
using NUnit.Framework;
using System;

namespace UnitTests
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
            var id = Guid.Empty;
            var model = "Palio";
            var year = 2008;
            var brand = "Fiat";
            var color = "Preto";
            var plate = "DZY-0412";

            var carFactory = Singleton.CarFactory;

            //act
            var car = carFactory.Create();

            //assert
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.Year, year);
            Assert.AreEqual(car.Brand, brand);
            Assert.AreEqual(car.Color, color);
            Assert.AreEqual(car.Plate, plate);
        }
        
    }
}