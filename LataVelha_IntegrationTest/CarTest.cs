using Application.Factories;
using Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class CarTest
    {

        private const string url = "https://localhost:5001/api/car";
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task WhenRequestCarControllerUsingGet_ThenICanReceiveCarsObjects()
        {
            //arrange
            client = new HttpClient();

            //act
            var response = await client.GetAsync($"{url}");
            var apiResponse = JsonConvert.DeserializeObject<Car[]>(
                await response.Content.ReadAsStringAsync());

            //assert 
            Assert.NotNull(apiResponse);
        }

        [Test]
        public async Task WhenCreateCarUsingPost_ThenICanPostOwnerObject()
        {
            //arrenge
            client = new HttpClient();

            var idO = Guid.NewGuid();
            var cpf = "123.456.789-11";
            var name = "Joao";
            var gender = 'M';
            var birthDate = DateTime.Now;
            var allFactory = new AllFactory();
            var ownerFactory = allFactory.Create("owner");


            var idC = Guid.NewGuid();
            var brand = "Nissan";
            var plate = "JBA5578";
            var model = "Skyline GT R34";
            var color = "Azul";
            var year = 2016;
            var idOwner = idO;
            var allFact = new AllFactory();
            var carFactory = allFact.Create("car");

            //act
            var owner = ownerFactory.Create(idO, name, cpf, gender, birthDate);
            var car = carFactory.Create(idC, brand, plate, color, year, model, idOwner);
            string objCar = JsonConvert.SerializeObject(car);
            var carcontent = new StringContent(objCar, System.Text.Encoding.UTF8, "application/json");
            var postCar = await client.PostAsync($"{url}", carcontent);

            var getCar = await client.GetAsync($"{url}/{car.Id.ToString()}");
            var apiResponse = JsonConvert.DeserializeObject<Car>(
                await getCar.Content.ReadAsStringAsync());

            //assert
            Assert.AreEqual(car.Id, apiResponse.Id);
            Assert.AreEqual(car.Brand, apiResponse.Brand);
            Assert.AreEqual(car.Plate, apiResponse.Plate);
            Assert.AreEqual(car.Model, apiResponse.Model);
            Assert.AreEqual(car.Color, apiResponse.Color);
            Assert.AreEqual(car.Year, apiResponse.Year);
            Assert.AreEqual(car.OwnerId, apiResponse.OwnerId);

        }

    }
}