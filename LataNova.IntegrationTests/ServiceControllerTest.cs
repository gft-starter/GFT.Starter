using Core.Models;
using LataNova.IntegrationTests.Helpers;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LataNova.IntegrationTests
{
    public class ServiceControllerTest
    {
        //private const string url = "https://localhost:44337/api/Service";
        private const string url = "https://latanovaservices.azurewebsites.net/api/Service";
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            client = new HttpClient();
        }

        [Test]
        public async Task WhenRequestServiceControllerusingGet_ThenICanReadTheResponseContent()
        {
            // Act
            var response = await client.GetAsync($"{url}");
            var servicesReceived = JsonConvert.DeserializeObject<Service[]>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.NotNull(servicesReceived);
        }

        [Test]
        public async Task WhenRequestServiceControllerUsingGetWithSpecificId_ThenIReceiveService()
        {
            // Arrange
            var service = ServiceHelper.CreateRandomService();

            // Act
            var post_response = await client.PostAsync($"{url}",
                new StringContent(JsonConvert.SerializeObject(service), Encoding.UTF8, "application/json"));
            Assert.AreEqual(post_response.StatusCode, System.Net.HttpStatusCode.OK);

            var response = await client.GetAsync($"{url}/{service.Id}");
            var serviceReceived = JsonConvert.DeserializeObject<Service>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.NotNull(serviceReceived);
            Assert.IsInstanceOf(typeof(Service), serviceReceived);
        }

        [Test]
        public async Task WhenRequestServiceControllerUsingPost_AndRequestServiceControllerUsingGetWithId_ThenICheckIfServiceWasAddedCorrectly()
        {
            // Arrange
            var service = ServiceHelper.CreateRandomService();

            // Act
            var post_response = await client.PostAsync($"{url}",
                new StringContent(JsonConvert.SerializeObject(service), Encoding.UTF8, "application/json"));
            Assert.AreEqual(post_response.StatusCode, System.Net.HttpStatusCode.OK);

            var get_response = await client.GetAsync($"{url}/{service.Id}");
            Assert.AreEqual(get_response.StatusCode, System.Net.HttpStatusCode.OK);
            ServiceHelper.AssertService(service, JsonConvert.DeserializeObject<Service>(await get_response.Content.ReadAsStringAsync()));
        }

        [Test]
        public async Task WhenRequestServiceControllerUsingPostWithServiceOnBody_AndRequestServiceControllerUsingGet_ThenVerifyIfServiceWasAdded_ThenRequestServiceControllerUsingPutWithUpdatedServiceOnBody_AndRequestServiceControllerUsingGet_ThenVerifyIfServiceWasUpdated()
        {
            // Arrange
            var service = ServiceHelper.CreateRandomService();
            var test = JsonConvert.SerializeObject(service);
            // Act
            var post_response = await client.PostAsync($"{url}",
                new StringContent(JsonConvert.SerializeObject(service), Encoding.UTF8, "application/json"));
            Assert.AreEqual(post_response.StatusCode, System.Net.HttpStatusCode.OK);

            var get_response = await client.GetAsync($"{url}/{service.Id}");
            Assert.AreEqual(get_response.StatusCode, System.Net.HttpStatusCode.OK);
            ServiceHelper.AssertService(service, JsonConvert.DeserializeObject<Service>(await get_response.Content.ReadAsStringAsync()));

            var updatedService = ServiceHelper.CreateRandomService();
            updatedService.Id = service.Id;
            var put_response = await client.PutAsync($"{url}/{service.Id}",
                new StringContent(JsonConvert.SerializeObject(updatedService), Encoding.UTF8, "application/json"));
            Assert.AreEqual(put_response.StatusCode, System.Net.HttpStatusCode.OK);

            get_response = await client.GetAsync($"{url}/{service.Id}");
            Assert.AreEqual(get_response.StatusCode, System.Net.HttpStatusCode.OK);
            var receivedService = JsonConvert.DeserializeObject<Service>(await get_response.Content.ReadAsStringAsync());
            ServiceHelper.AssertService(updatedService, receivedService);
        }

        [Test]
        public async Task WhenRequestServiceControllerUsingPostWithServiceOnBody_AndRequestServiceControllerUsingGet_ThenVerifyIfServiceWasAdded_ThenRequestServiceControllerUsingDelete_AndRequestServiceControllerUsingGet_ThenVerifyIfServiceWasDeleted()
        {
            // Arrange
            var service = ServiceHelper.CreateRandomService();

            // Act
            var post_response = await client.PostAsync($"{url}",
                new StringContent(JsonConvert.SerializeObject(service), Encoding.UTF8, "application/json"));
            Assert.AreEqual(post_response.StatusCode, System.Net.HttpStatusCode.OK);

            var get_response = await client.GetAsync($"{url}/{service.Id}");
            Assert.AreEqual(get_response.StatusCode, System.Net.HttpStatusCode.OK);
            ServiceHelper.AssertService(service, JsonConvert.DeserializeObject<Service>(await get_response.Content.ReadAsStringAsync()));

            var delete_response = await client.DeleteAsync($"{url}/{service.Id}");
            Assert.AreEqual(delete_response.StatusCode, System.Net.HttpStatusCode.OK);

            get_response = await client.GetAsync($"{url}/{service.Id}");
            Assert.AreEqual(get_response.StatusCode, System.Net.HttpStatusCode.NoContent);
        }
    }
}
