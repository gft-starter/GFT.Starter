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
    public class ServiceOrderControllerTest
    {
        //private const string url = "https://localhost:44337/api/ServiceOrder";
        private const string url = "https://latanovaservices.azurewebsites.net/api/ServiceOrder";
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            client = new HttpClient();
        }

        [Test]
        public async Task WhenRequestServiceOrderControllerUsingGet_ThenICanReadTheResponseContent()
        {
            // Act
            var response = await client.GetAsync($"{url}");
            var apiResponse = JsonConvert.DeserializeObject<ServiceOrder[]>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.NotNull(apiResponse);
        }

        [Test]
        public async Task WhenRequestServiceOrderControllerUsingGetWithSpecificId_ThenIReceiveServiceOrder()
        {
            // Arrange
            var serviceOrder = ServiceOrderHelper.CreateRandomServiceOrder();

            // Act
            var post_response = await client.PostAsync($"{url}",
                new StringContent(JsonConvert.SerializeObject(serviceOrder), Encoding.UTF8, "application/json"));
            Assert.AreEqual(post_response.StatusCode, System.Net.HttpStatusCode.OK);

            var response = await client.GetAsync($"{url}/{serviceOrder.Id}");
            var serviceOrderReceived = JsonConvert.DeserializeObject<ServiceOrder>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.NotNull(serviceOrderReceived);
            Assert.IsInstanceOf(typeof(ServiceOrder), serviceOrderReceived);
        }

        [Test]
        public async Task WhenRequestServiceOrderControllerUsingPost_AndRequestServiceOrderControllerUsingGetWithId_ThenICheckIfServiceOrderWasAddedCorrectly()
        {
            // Arrange
            var serviceOrder = ServiceOrderHelper.CreateRandomServiceOrder();

            // Act
            var post_response = await client.PostAsync($"{url}",
                new StringContent(JsonConvert.SerializeObject(serviceOrder), Encoding.UTF8, "application/json"));
            Assert.AreEqual(post_response.StatusCode, System.Net.HttpStatusCode.OK);

            var get_response = await client.GetAsync($"{url}/{serviceOrder.Id}");
            Assert.AreEqual(get_response.StatusCode, System.Net.HttpStatusCode.OK);

            // Assert
            var serviceOrderReceived = JsonConvert.DeserializeObject<ServiceOrder>(await get_response.Content.ReadAsStringAsync());
            ServiceOrderHelper.AssertService(serviceOrder, serviceOrderReceived);
        }

        [Test]
        public async Task WhenRequestServiceOrderControllerUsingPostWithServiceOrderOnBody_AndRequestServiceOrderControllerUsingGet_ThenVerifyIfServiceOrderWasAdded_ThenRequestServiceOrderControllerUsingPutWithUpdatedServiceOrderOnBody_AndRequestServiceOrderControllerUsingGet_ThenVerifyIfServiceOrderWasUpdated()
        {
            // Arrange
            var serviceOrder = ServiceOrderHelper.CreateRandomServiceOrder();

            // Act
            var post_response = await client.PostAsync($"{url}",
                new StringContent(JsonConvert.SerializeObject(serviceOrder), Encoding.UTF8, "application/json"));
            Assert.AreEqual(post_response.StatusCode, System.Net.HttpStatusCode.OK);

            var get_response = await client.GetAsync($"{url}/{serviceOrder.Id}");
            Assert.AreEqual(get_response.StatusCode, System.Net.HttpStatusCode.OK);
            ServiceOrderHelper.AssertService(serviceOrder, JsonConvert.DeserializeObject<ServiceOrder>(await get_response.Content.ReadAsStringAsync()));

            var updatedServiceOrder = ServiceOrderHelper.CreateRandomServiceOrder();
            updatedServiceOrder.Id = serviceOrder.Id;
            var put_response = await client.PutAsync($"{url}/{serviceOrder.Id}",
                new StringContent(JsonConvert.SerializeObject(updatedServiceOrder), Encoding.UTF8, "application/json"));
            Assert.AreEqual(put_response.StatusCode, System.Net.HttpStatusCode.OK);

            get_response = await client.GetAsync($"{url}/{serviceOrder.Id}");
            Assert.AreEqual(get_response.StatusCode, System.Net.HttpStatusCode.OK);
            ServiceOrderHelper.AssertService(updatedServiceOrder, JsonConvert.DeserializeObject<ServiceOrder>(await get_response.Content.ReadAsStringAsync()));
        }

        [Test]
        public async Task WhenRequestServiceOrderControllerUsingPostWithServiceOrderOnBody_AndRequestServiceOrderControllerUsingGet_ThenVerifyIfServiceOrderWasAdded_ThenRequestServiceOrderControllerUsingDelete_AndRequestServiceOrderControllerUsingGet_ThenVerifyIfServiceOrderWasDeleted()
        {
            // Arrange
            var serviceOrder = ServiceOrderHelper.CreateRandomServiceOrder();

            // Act
            var post_response = await client.PostAsync($"{url}",
                new StringContent(JsonConvert.SerializeObject(serviceOrder), Encoding.UTF8, "application/json"));
            Assert.AreEqual(post_response.StatusCode, System.Net.HttpStatusCode.OK);

            var get_response = await client.GetAsync($"{url}/{serviceOrder.Id}");
            Assert.AreEqual(get_response.StatusCode, System.Net.HttpStatusCode.OK);
            ServiceOrderHelper.AssertService(serviceOrder, JsonConvert.DeserializeObject<ServiceOrder>(await get_response.Content.ReadAsStringAsync()));

            var delete_response = await client.DeleteAsync($"{url}/{serviceOrder.Id}");
            Assert.AreEqual(delete_response.StatusCode, System.Net.HttpStatusCode.OK);

            get_response = await client.GetAsync($"{url}/{serviceOrder.Id}");
            Assert.AreEqual(get_response.StatusCode, System.Net.HttpStatusCode.NoContent);
        }
    }
}
