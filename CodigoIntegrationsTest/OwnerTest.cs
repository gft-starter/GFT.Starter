using GFT.Starter.Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
    public class OwnerTest
    {
        private HttpClient client;
        private readonly string url = "http://localhost:51445/api/Owner";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestIfTheOwnerRequestIsWorking()
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