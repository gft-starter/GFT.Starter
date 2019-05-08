using GFT.Starter.Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
    public class CarTest
    {
        private HttpClient client;
        private readonly string url = "http://localhost:5000/api/Car";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestIfTheCarRequestIsWorking()
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
    }
}