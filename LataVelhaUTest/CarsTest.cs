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
        [Test]
        public void whenCreateVehicle_AndAssingAndOwner_ThenICanFindTheOwner()
        {

            //arrenge
            var idO = Guid.NewGuid();
            var cpf = "123.456.789-11";
            var name = "Joao";
            var gender = 'M';
            var birthDate = DateTime.Now;
            var allFactory = new AllFactory();
            var ownerFactory = allFactory.Create("owner");
            //act Owner
            var owner = ownerFactory.Create(idO, name, cpf, gender, birthDate);

            //arrenge car
            var id = Guid.NewGuid();
            var model = "Palio";
            var year = 2008;
            var brand = "Fiat";
            var color = "Black";
            var plate = "DBZ-8000";
            var idowner = idO ;
            var carFactory = new CarsFactory();

            //act
            
            var car = carFactory.Create( id, brand, plate, color, year,  model, idowner);

            //assert
            Assert.AreEqual(car.OwnerId, owner.Id);

        }

    }
}