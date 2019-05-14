using GFT.Starter.Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
    public class ServiceOrderTest
    {
        private HttpClient client;
        private readonly string url = "http://localhost:50286/api/ServiceOrder";
        private readonly string urlService = "http://localhost:50286/api/Service";
        private readonly string urlCar = "http://localhost:50287/api/Car";
        private readonly string urlOwner = "http://localhost:50288/api/Owner";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestingIfTheGetMethodIsReturningAListOfServiceOrders()
        {
            //arrange
            client = new HttpClient();

            //act
            var response = await client.GetAsync($"{url}");
            var apiResponse = JsonConvert.DeserializeObject<Owner[]>(
                await response.Content.ReadAsStringAsync());

            //assert
            Assert.NotNull(apiResponse);
        }

        [Test]
        public async Task TestingIfThePostMethodIsSendingAServiceOrderObject()
        {
            //arrange
            client = new HttpClient();

            Service service = new Service();
            service.Id = Guid.NewGuid();
            service.Name = "Troca de Pneu";
            service.Description = "Troca de Pneu";
            service.Value = 100;

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

            ServiceOrder serviceOrder = new ServiceOrder();
            serviceOrder.Id = Guid.NewGuid();
            serviceOrder.VehicleId = car.Id;
            serviceOrder.ServiceId = service.Id;
            serviceOrder.Quantity = 1;

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
            var contentCar = new StringContent(objCar, System.Text.Encoding.UTF8, "application/json");
            var postCar = await client.PostAsync($"{urlCar}", contentCar);

            var getCar = await client.GetAsync($"{urlCar}/{car.Id.ToString()}");
            var apiResponseCar = JsonConvert.DeserializeObject<Car>(
                await getCar.Content.ReadAsStringAsync());

            ///Post do Service
            string objService = JsonConvert.SerializeObject(service);
            var contentService = new StringContent(objService, System.Text.Encoding.UTF8, "application/json");
            var postService = await client.PostAsync($"{urlService}", contentService);

            var getService = await client.GetAsync($"{urlService}/{service.Id.ToString()}");
            var apiResponseService = JsonConvert.DeserializeObject<Service>(
                await getService.Content.ReadAsStringAsync());

            ///Post do ServiceOrder
            string objServiceOrder = JsonConvert.SerializeObject(serviceOrder);
            var content = new StringContent(objServiceOrder, System.Text.Encoding.UTF8, "application/json");
            var postServiceOrder = await client.PostAsync($"{url}", content);

            var getServiceOrder = await client.GetAsync($"{url}/{serviceOrder.Id.ToString()}");
            var apiResponse = JsonConvert.DeserializeObject<ServiceOrder>(
                await getServiceOrder.Content.ReadAsStringAsync());

            //assert
            Assert.AreEqual(serviceOrder.Id, apiResponse.Id);
            Assert.AreEqual(serviceOrder.VehicleId, apiResponse.VehicleId);
            Assert.AreEqual(serviceOrder.ServiceId, apiResponse.ServiceId);
            Assert.AreEqual(serviceOrder.Quantity, apiResponse.Quantity);
        }

        [Test]
        public async Task TestingIfTheDeleteMethodIsDeletingTheServiceOrderCreated()
        {
            //arrange
            client = new HttpClient();

            Service service = new Service();
            service.Id = Guid.NewGuid();
            service.Name = "Troca de Pneu";
            service.Description = "Troca de Pneu";
            service.Value = 100;

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

            ServiceOrder serviceOrder = new ServiceOrder();
            serviceOrder.Id = Guid.NewGuid();
            serviceOrder.VehicleId = car.Id;
            serviceOrder.ServiceId = service.Id;
            serviceOrder.Quantity = 1;

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
            var contentCar = new StringContent(objCar, System.Text.Encoding.UTF8, "application/json");
            var postCar = await client.PostAsync($"{urlCar}", contentCar);

            var getCar = await client.GetAsync($"{urlCar}/{car.Id.ToString()}");
            var apiResponseCar = JsonConvert.DeserializeObject<Car>(
                await getCar.Content.ReadAsStringAsync());

            ///Post do Service
            string objService = JsonConvert.SerializeObject(service);
            var contentService = new StringContent(objService, System.Text.Encoding.UTF8, "application/json");
            var postService = await client.PostAsync($"{urlService}", contentService);

            var getService = await client.GetAsync($"{urlService}/{service.Id.ToString()}");
            var apiResponseService = JsonConvert.DeserializeObject<Service>(
                await getService.Content.ReadAsStringAsync());

            ///Post do ServiceOrder
            string objServiceOrder = JsonConvert.SerializeObject(serviceOrder);
            var content = new StringContent(objServiceOrder, System.Text.Encoding.UTF8, "application/json");
            var postServiceOrder = await client.PostAsync($"{url}", content);

            var getServiceOrder = await client.GetAsync($"{url}/{serviceOrder.Id.ToString()}");
            var apiResponse = JsonConvert.DeserializeObject<ServiceOrder>(
                await getServiceOrder.Content.ReadAsStringAsync());

            ///Delete
            var deleteServiceOrder = await client.DeleteAsync($"{url}/{serviceOrder.Id.ToString()}");

            var getServiceOrderAfterDelete = await client.GetAsync($"{url}/{serviceOrder.Id.ToString()}");
            var apiResponseAfterDelete = JsonConvert.DeserializeObject<ServiceOrder>(
                await getServiceOrderAfterDelete.Content.ReadAsStringAsync());

            //assert
            Assert.IsNull(apiResponseAfterDelete);
        }
    }
}