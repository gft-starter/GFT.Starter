using Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class CarTest
    {

        private const string url = "https://localhost:44308/api/car";
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
            var apiResponse = JsonConvert.DeserializeObject<Owner[]>(
                await response.Content.ReadAsStringAsync());

            //assert
            Assert.NotNull(apiResponse);
        }
    }
}