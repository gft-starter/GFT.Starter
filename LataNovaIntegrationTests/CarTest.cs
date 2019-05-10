using GFT.Starter.Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class CarTest
    {
        private const string url = "http://localhost:50436/api/car";
        private const string urlOwner = "http://localhost:50437/api/owner";
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
            var apiResponse = JsonConvert.DeserializeObject<Car[]>(await response.Content.ReadAsStringAsync());
            //assert
            Assert.NotNull(apiResponse);
        }

        [Test]
        public async Task WhenRequestCarControllerUsingPost_ThenVerifyIfThatCarExistsUsingGet()
        {
            //arrange
            client = new HttpClient();

            Owner owner = new Owner()
            {
                Id = Guid.NewGuid(),
                CPF = "15616156",
                Name = "Leonardo",
                BirthDate = new DateTime(),
                Gender = 'M'
            };

            Car car = new Car()
            {
                Id = Guid.NewGuid(),
                Plate = "HDJ-2407",
                Brand = "Chevrolet",
                Model = "Celta",
                Color = "Silver",
                Year = 2006,
                OwnerId = owner.Id
            };


            //act

            string objOwner = JsonConvert.SerializeObject(owner);
            var ownerContent = new StringContent(objOwner, System.Text.Encoding.UTF8, "application/json");
            var ownerPost = await client.PostAsync($"{urlOwner}", ownerContent);

            var ownerGet = await client.GetAsync($"{urlOwner}/{owner.Id.ToString()}");
            var ownerApiResponse = JsonConvert.DeserializeObject<Owner>(await ownerGet.Content.ReadAsStringAsync());

            string objCar = JsonConvert.SerializeObject(car);
            var carContent = new StringContent(objCar, System.Text.Encoding.UTF8, "application/json");
            var carPost = await client.PostAsync($"{url}", carContent);

            var carGet = await client.GetAsync($"{url}/{car.Id.ToString()}");
            var carApiResponse = JsonConvert.DeserializeObject<Car>(await carGet.Content.ReadAsStringAsync());

            //assert

            Assert.AreEqual(owner.Id, ownerApiResponse.Id);
            Assert.AreEqual(owner.CPF, ownerApiResponse.CPF);
            Assert.AreEqual(owner.Name, ownerApiResponse.Name);
            Assert.AreEqual(owner.BirthDate, ownerApiResponse.BirthDate);
            Assert.AreEqual(owner.Gender, ownerApiResponse.Gender);

            Assert.AreEqual(car.Id, carApiResponse.Id);
            Assert.AreEqual(car.Plate, carApiResponse.Plate);
            Assert.AreEqual(car.Brand, carApiResponse.Brand);
            Assert.AreEqual(car.Model, carApiResponse.Model);
            Assert.AreEqual(car.Color, carApiResponse.Color);
            Assert.AreEqual(car.Year, carApiResponse.Year);
            Assert.AreEqual(car.OwnerId, carApiResponse.OwnerId);
        }

        //[Test]
        //public async Task WhenRequestingOwnerControllerUsingPut_ThenVerifyIfOwnerWasUpdated()
        //{
        //    //arrange
        //    client = new HttpClient();
        //    Car car = new Car()
        //    {
        //        Id = Guid.NewGuid(),
        //        Plate = "HDJ-2407",
        //        Brand = "Chevrolet",
        //        Model = "Celta",
        //        Color = "Silver",
        //        Year = 2006
        //    };

        //    //act
        //    var newCar = new Car()
        //    {
        //        Id = car.Id,
        //        Plate = "ABS-1234",
        //        Brand = "Ford",
        //        Model = "Focus",
        //        Color = "Blue",
        //        Year = 2013
        //    };

        //    string objCarPost = JsonConvert.SerializeObject(car);
        //    var contentPost = new StringContent(objCarPost, System.Text.Encoding.UTF8, "application/json");
        //    var post = await client.PostAsync($"{url}", contentPost);

        //    var get = await client.GetAsync($"{url}/{car.Id.ToString()}");
        //    var apiResponsePost = JsonConvert.DeserializeObject<Car>(await get.Content.ReadAsStringAsync());

        //    string objCarPut = JsonConvert.SerializeObject(newCar);
        //    var contentPut = new StringContent(objCarPut, System.Text.Encoding.UTF8, "application/json");
        //    var put = await client.PutAsync($"{url}/{car.Id.ToString()}", contentPut);

        //    var newGet = await client.GetAsync($"{url}/{newCar.Id.ToString()}");
        //    var apiResponsePut = JsonConvert.DeserializeObject<Car>(await newGet.Content.ReadAsStringAsync());


        //    //assert
        //    Assert.IsNotNull(apiResponsePost);

        //    Assert.AreEqual(car.Id, apiResponsePost.Id);
        //    Assert.AreEqual(car.Plate, apiResponsePost.Plate);
        //    Assert.AreEqual(car.Brand, apiResponsePost.Brand);
        //    Assert.AreEqual(car.Model, apiResponsePost.Model);

        //    Assert.IsNotNull(put);

        //    Assert.AreEqual(newCar.Id, apiResponsePut.Id);
        //    Assert.AreEqual(newCar.Plate, apiResponsePut.Plate);
        //    Assert.AreEqual(newCar.Brand, apiResponsePut.Brand);
        //    Assert.AreEqual(newCar.Model, apiResponsePut.Model);


        //}

        [Test]
        public async Task WhenRequestingCarControllerUsingDelete_ThenVerifyIfCarWasDeleted()
        {
            //arrange
            client = new HttpClient();
            Owner owner = new Owner()
            {
                Id = Guid.NewGuid(),
                CPF = "15616156",
                Name = "Leonardo",
                BirthDate = new DateTime(),
                Gender = 'M'
            };

            Car car = new Car()
            {
                Id = Guid.NewGuid(),
                Plate = "HDJ-2407",
                Brand = "Chevrolet",
                Model = "Celta",
                Color = "Silver",
                Year = 2006
            };


            //act
            string objOwner = JsonConvert.SerializeObject(owner);
            var ownerContent = new StringContent(objOwner, System.Text.Encoding.UTF8, "application/json");
            var ownerPost = await client.PostAsync($"{urlOwner}", ownerContent);

            var ownerGet = await client.GetAsync($"{urlOwner}/{owner.Id.ToString()}");
            var ownerApiResponse = JsonConvert.DeserializeObject<Owner>(await ownerGet.Content.ReadAsStringAsync());

            string objCar = JsonConvert.SerializeObject(car);
            var carContent = new StringContent(objCar, System.Text.Encoding.UTF8, "application/json");
            var carPost = await client.PostAsync($"{url}", carContent);

            var carGet = await client.GetAsync($"{url}/{car.Id.ToString()}");
            var carApiResponse = JsonConvert.DeserializeObject<Car>(await carGet.Content.ReadAsStringAsync());

            var deleteOwner = await client.DeleteAsync($"{urlOwner}/{owner.Id.ToString()}");

            var ownerNewGet = await client.GetAsync($"{urlOwner}/{owner.Id.ToString()}");
            var ownerNewApiResponse = JsonConvert.DeserializeObject<Owner>(await ownerGet.Content.ReadAsStringAsync());

            var deleteCar = await client.DeleteAsync($"{url}/{car.Id.ToString()}");

            var carNewGet = await client.GetAsync($"{url}/{car.Id.ToString()}");
            var carNewApiResponse = JsonConvert.DeserializeObject<Car>(await carGet.Content.ReadAsStringAsync());

            //assert
            Assert.AreEqual(owner.Id, ownerApiResponse.Id);
            Assert.AreEqual(owner.CPF, ownerApiResponse.CPF);
            Assert.AreEqual(owner.Name, ownerApiResponse.Name);
            Assert.AreEqual(owner.BirthDate, ownerApiResponse.BirthDate);
            Assert.AreEqual(owner.Gender, ownerApiResponse.Gender);

            Assert.AreEqual(car.Id, carApiResponse.Id);
            Assert.AreEqual(car.Plate, carApiResponse.Plate);
            Assert.AreEqual(car.Brand, carApiResponse.Brand);
            Assert.AreEqual(car.Model, carApiResponse.Model);
            Assert.AreEqual(car.Color, carApiResponse.Color);
            Assert.AreEqual(car.Year, carApiResponse.Year);
            Assert.AreEqual(car.OwnerId, carApiResponse.OwnerId);

            Assert.IsNull(ownerNewApiResponse);

            Assert.IsNull(carNewApiResponse);

        }


    }
}