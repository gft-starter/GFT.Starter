using Application.Factories;
using Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class ServiceTest
    {

        private const string url = "https://localhost:44303/api/service";
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task WhenRequestOwnerControllerUsingGet_ThenICanReceiveOwnersObjects()
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
        public async Task WhenCreateOwnerUsingPost_thenICanPostOwnerObject()
        {
            //arrenge
            client = new HttpClient();
            var id = Guid.NewGuid();
            var name = "Trocar pneus";
            var description = "troca do conjunto de pneus do veiculo";
            var value = 580.00;
            var allFactory = new AllFactory();
            var serviceFactory = allFactory.Create("service");

            //act
            var service = serviceFactory.Create(id, name, description, value);
            string objService = JsonConvert.SerializeObject(service);
            var servicecontent = new StringContent(objService, System.Text.Encoding.UTF8, "application/json");
            var postService = await client.PostAsync($"{url}", servicecontent);

            var getService = await client.GetAsync($"{url}/{service.Id.ToString()}");
            var apiResponse = JsonConvert.DeserializeObject<Service>(
                await getService.Content.ReadAsStringAsync());

            //assert
            Assert.AreEqual(service.Id, apiResponse.Id);
            Assert.AreEqual(service.Name, apiResponse.Name);
            Assert.AreEqual(service.Description, apiResponse.Description);
            Assert.AreEqual(service.Value, apiResponse.Value);
            
        }
    }
}