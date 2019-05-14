using GFT.Starter.Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
    public class ServiceTest
    {
        private HttpClient client;
        private readonly string url = "http://localhost:50286/api/Service";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestingIfTheGetMethodIsReturningAListOfServices()
        {
            //arrange
            client = new HttpClient();

            //act
            var response = await client.GetAsync($"{url}");
            var apiResponse = JsonConvert.DeserializeObject<Service[]>(
                await response.Content.ReadAsStringAsync());

            //assert
            Assert.NotNull(apiResponse);
        }

        [Test]
        public async Task TestingIfThePostMethodIsSendingAServiceObject()
        {
            //arrange
            client = new HttpClient();
            Service service = new Service();
            service.Id = Guid.NewGuid();
            service.Name = "Troca de Pneu";
            service.Description = "Troca de Pneu";
            service.Value = 100;

            //act
            string objService = JsonConvert.SerializeObject(service);
            var content = new StringContent(objService, System.Text.Encoding.UTF8, "application/json");
            var postService = await client.PostAsync($"{url}", content);

            var getService = await client.GetAsync($"{url}/{service.Id.ToString()}");
            var apiResponse = JsonConvert.DeserializeObject<Service>(
                await getService.Content.ReadAsStringAsync());

            //assert
            Assert.AreEqual(service.Id, apiResponse.Id);
            Assert.AreEqual(service.Name, apiResponse.Name);
            Assert.AreEqual(service.Description, apiResponse.Description);
            Assert.AreEqual(service.Value, apiResponse.Value);
        }

        [Test]
        public async Task TestingIfTheDeleteMethodIsDeletingTheServiceCreated()
        {
            //arrange
            client = new HttpClient();
            Service service = new Service();
            service.Id = Guid.NewGuid();
            service.Name = "Troca de Pneu";
            service.Description = "Troca de Pneu";
            service.Value = 100;

            //act
            string objService = JsonConvert.SerializeObject(service);
            var content = new StringContent(objService, System.Text.Encoding.UTF8, "application/json");
            var postService = await client.PostAsync($"{url}", content);

            var getService = await client.GetAsync($"{url}/{service.Id.ToString()}");
            var apiResponse = JsonConvert.DeserializeObject<Service>(
                await getService.Content.ReadAsStringAsync());

            var deleteService = await client.DeleteAsync($"{url}/{service.Id.ToString()}");

            var getServiceAfterDelete = await client.GetAsync($"{url}/{service.Id.ToString()}");
            var apiResponseAfterDelete = JsonConvert.DeserializeObject<Service>(
                await getServiceAfterDelete.Content.ReadAsStringAsync());

            //assert
            Assert.IsNull(apiResponseAfterDelete);
        }
    }
}