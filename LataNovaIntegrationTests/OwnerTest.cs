using GFT.Starter.Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class OwnerTest
    {
        private const string url = "http://localhost:50437/api/owner/";
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
            var apiResponse = JsonConvert.DeserializeObject<Owner[]>(await response.Content.ReadAsStringAsync());
            //assert
            Assert.NotNull(apiResponse);
        }

        [Test]
        public async Task WhenRequestOwnerControllerUsingPost_ThenVerifyIfThatOwnerExistsUsingGet()
        {
            //arrange
            client = new HttpClient();
            Owner owner = new Owner();
            owner.Id = Guid.NewGuid();
            owner.CPF = "1231561516";
            owner.Name = "Teste";
            owner.BirthDate = new DateTime();
            owner.Gender = 'M';

            //act
            string uri = "http://localhost:50437/api/owner/404C36E5-569E-4CAE-AC11-5FF62DD00909";
            string objOwner = JsonConvert.SerializeObject(owner);
            var content = new StringContent(objOwner, System.Text.Encoding.UTF8, "application/json");
            var post = await client.PostAsync($"{url}", content);

            var get = await client.GetAsync($"{uri}");
            var apiResponse = JsonConvert.DeserializeObject<Owner[]>(await get.Content.ReadAsStringAsync());

            //assert
            Assert.AreEqual(owner, apiResponse);
        }
    }
}