using Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;

namespace IntegrationTests
{
    public class OwnerTest
    {

        private const string url = "http://localhost:54451/api/owner";
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async void WhenRequestOwnerControllerUsingGet_ThenICanReceiveOwnersObjects()
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
    }
}