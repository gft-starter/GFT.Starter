using GFT.Starter.Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class ServiceTest
    {
        private const string url = "http://localhost:50435/api/service";
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task WhenRequestServiceControllerUsingGet_ThenICanReceiveServicesObjects()
        {
            //arrange
            client = new HttpClient();
            //act
            var response = await client.GetAsync($"{url}");
            var apiResponse = JsonConvert.DeserializeObject<Service[]>(await response.Content.ReadAsStringAsync());
            //assert
            Assert.NotNull(apiResponse);
        }

        [Test]
        public async Task WhenRequestOwnerControllerUsingPost_ThenVerifyIfThatOwnerExistsUsingGet()
        {
            //arrange
            client = new HttpClient();
            Service service = new Service()
            {
                Id = Guid.NewGuid(),
                Description = "Lavagem completa",
                Name = "Teste",
                Value = 50.00f
            };


            //act
            string objservice = JsonConvert.SerializeObject(service);
            var content = new StringContent(objservice, System.Text.Encoding.UTF8, "application/json");
            var post = await client.PostAsync($"{url}", content);

            var get = await client.GetAsync($"{url}/{service.Id.ToString()}");
            var apiResponse = JsonConvert.DeserializeObject<Service>(await get.Content.ReadAsStringAsync());

            //assert
            Assert.AreEqual(service.Id, apiResponse.Id);
            Assert.AreEqual(service.Description, apiResponse.Description);
            Assert.AreEqual(service.Name, apiResponse.Name);
            Assert.AreEqual(service.Value, apiResponse.Value);
        }

        [Test]
        public async Task WhenRequestingOwnerControllerUsingPut_ThenVerifyIfOwnerWasUpdated()
        {
            //arrange
            client = new HttpClient();
            Service service = new Service()
            {
                Id = Guid.NewGuid(),
                Description = "Lavagem completa",
                Name = "Teste",
                Value = 50.00f
            };

            //act
            var newService = new Service()
            {
                Id = service.Id,
                Description = "Lavagem rápida",
                Name = "Lava e seca",
                Value = 25.00f
            };

            string objServicePost = JsonConvert.SerializeObject(service);
            var contentPost = new StringContent(objServicePost, System.Text.Encoding.UTF8, "application/json");
            var post = await client.PostAsync($"{url}", contentPost);

            var get = await client.GetAsync($"{url}/{service.Id.ToString()}");
            var apiResponsePost = JsonConvert.DeserializeObject<Service>(await get.Content.ReadAsStringAsync());

            string objServicePut = JsonConvert.SerializeObject(newService);
            var contentPut = new StringContent(objServicePut, System.Text.Encoding.UTF8, "application/json");
            var put = await client.PutAsync($"{url}/{service.Id.ToString()}", contentPut);

            var newGet = await client.GetAsync($"{url}/{newService.Id.ToString()}");
            var apiResponsePut = JsonConvert.DeserializeObject<Service>(await newGet.Content.ReadAsStringAsync());


            //assert
            Assert.IsNotNull(apiResponsePost);

            Assert.AreEqual(service.Id, apiResponsePost.Id);
            Assert.AreEqual(service.Description, apiResponsePost.Description);
            Assert.AreEqual(service.Name, apiResponsePost.Name);
            Assert.AreEqual(service.Value, apiResponsePost.Value);

            Assert.IsNotNull(put);

            Assert.AreEqual(newService.Id, apiResponsePut.Id);
            Assert.AreEqual(newService.Description, apiResponsePut.Description);
            Assert.AreEqual(newService.Name, apiResponsePut.Name);
            Assert.AreEqual(newService.Value, apiResponsePut.Value);


        }

        [Test]
        public async Task WhenRequestingOwnerControllerUsingDelete_ThenVerifyIfOwnerWasDeleted()
        {
            //arrange
            client = new HttpClient();
            Service service = new Service()
            {
                Id = Guid.NewGuid(),
                Description = "Lavagem completa",
                Name = "Teste",
                Value = 50.00f
            };


            //act
            string objServicePost = JsonConvert.SerializeObject(service);
            var contentPost = new StringContent(objServicePost, System.Text.Encoding.UTF8, "application/json");
            var post = await client.PostAsync($"{url}", contentPost);

            var get = await client.GetAsync($"{url}/{service.Id.ToString()}");
            var apiResponsePost = JsonConvert.DeserializeObject<Service>(await get.Content.ReadAsStringAsync());

            var delete = await client.DeleteAsync($"{url}/{service.Id.ToString()}");

            var newGet = await client.GetAsync($"{url}/{service.Id.ToString()}");
            var apiResponseDelete = JsonConvert.DeserializeObject<Service>(await newGet.Content.ReadAsStringAsync());

            //assert
            Assert.IsNotNull(apiResponsePost);

            Assert.AreEqual(service.Id, apiResponsePost.Id);
            Assert.AreEqual(service.Description, apiResponsePost.Description);
            Assert.AreEqual(service.Name, apiResponsePost.Name);
            Assert.AreEqual(service.Value, apiResponsePost.Value);

            Assert.IsNull(apiResponseDelete);

        }


    }
}