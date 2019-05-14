using GFT.Starter.Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
    public class CarTest
    {
        private HttpClient client;
        private readonly string url = "http://localhost:50287/api/Car";
        private readonly string urlOwner = "http://localhost:50288/api/Owner";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestingIfTheGetMethodIsReturningAListOfCars()
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
        public async Task TestingIfThePostMethodIsSendingACarObject()
        {
            //arrange
            client = new HttpClient();

            Owner owner = new Owner();
            owner.Id = Guid.NewGuid();
            owner.Name = "Vinicius";
            owner.CPF = "12345678952";
            owner.Gender = 'M';
            owner.BirthDate = new DateTime();

            Car car = new Car();
            car.Id = Guid.NewGuid();
            car.Plate = "ABC1324";
            car.Brand = "Fiat";
            car.Model = "Palio";
            car.Color = "Black";
            car.Year = 2000;
            car.OwnerId = owner.Id;

            //act
            ///Post do Owner
            string objOwner = JsonConvert.SerializeObject(owner);
            var contentOwner = new StringContent(objOwner, System.Text.Encoding.UTF8, "application/json");
            var postOwner = await client.PostAsync($"{urlOwner}", contentOwner);

            var getOwner = await client.GetAsync($"{urlOwner}/{owner.Id.ToString()}");
            var apiResponseOwner = JsonConvert.DeserializeObject<Owner>(
                await getOwner.Content.ReadAsStringAsync());

            ///Post do Car
            string objCar = JsonConvert.SerializeObject(car);
            var content = new StringContent(objCar, System.Text.Encoding.UTF8, "application/json");
            var postCar = await client.PostAsync($"{url}", content);

            var getCar = await client.GetAsync($"{url}/{car.Id.ToString()}");
            var apiResponse = JsonConvert.DeserializeObject<Car>(
                await getCar.Content.ReadAsStringAsync());

            //assert
            Assert.AreEqual(car.Id, apiResponse.Id);
            Assert.AreEqual(car.Plate, apiResponse.Plate);
            Assert.AreEqual(car.Brand, apiResponse.Brand);
            Assert.AreEqual(car.Model, apiResponse.Model);
            Assert.AreEqual(car.Color, apiResponse.Color);
            Assert.AreEqual(car.Year, apiResponse.Year);
            Assert.AreEqual(car.OwnerId, apiResponse.OwnerId);
        }

        [Test]
        public async Task TestingIfTheDeleteMethodIsDeletingTheCarCreated()
        {
            client = new HttpClient();

            Owner owner = new Owner();
            owner.Id = Guid.NewGuid();
            owner.Name = "Vinicius";
            owner.CPF = "12345678952";
            owner.Gender = 'M';
            owner.BirthDate = new DateTime();

            Car car = new Car();
            car.Id = Guid.NewGuid();
            car.Plate = "ABC1324";
            car.Brand = "Fiat";
            car.Model = "Palio";
            car.Color = "Black";
            car.Year = 2000;
            car.OwnerId = owner.Id;

            //act
            ///Post do Owner
            string objOwner = JsonConvert.SerializeObject(owner);
            var contentOwner = new StringContent(objOwner, System.Text.Encoding.UTF8, "application/json");
            var postOwner = await client.PostAsync($"{urlOwner}", contentOwner);

            var getOwner = await client.GetAsync($"{urlOwner}/{owner.Id.ToString()}");
            var apiResponseOwner = JsonConvert.DeserializeObject<Owner>(
                await getOwner.Content.ReadAsStringAsync());

            ///Post do Car
            string objCar = JsonConvert.SerializeObject(car);
            var content = new StringContent(objCar, System.Text.Encoding.UTF8, "application/json");
            var postCar = await client.PostAsync($"{url}", content);

            var getCar = await client.GetAsync($"{url}/{car.Id.ToString()}");
            var apiResponse = JsonConvert.DeserializeObject<Car>(
                await getCar.Content.ReadAsStringAsync());

            ///Delete
            var deleteCar = await client.DeleteAsync($"{url}/{car.Id.ToString()}");

            var getCarAfterDelete = await client.GetAsync($"{url}/{car.Id.ToString()}");
            var apiResponseAfterDelete = JsonConvert.DeserializeObject<Car>(
                await getCarAfterDelete.Content.ReadAsStringAsync());

            //assert
            Assert.IsNull(apiResponseAfterDelete);
        }
    }
}