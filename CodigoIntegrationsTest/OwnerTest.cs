using GFT.Starter.Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
    public class OwnerTest
    {
        private HttpClient client;
        private readonly string url = "http://localhost:50288/api/Owner";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestingIfTheGetMethodIsReturningAListOfOwners()
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

        [Test]
        public async Task TestingIfThePostMethodIsSendingAOwnerObject()
        {
            //arrange
            client = new HttpClient();
            Owner owner = new Owner();
            owner.Id = Guid.NewGuid();
            owner.Name = "Vinicius";
            owner.CPF = "12345678952";
            owner.Gender = 'M';
            owner.BirthDate = new DateTime();

            //act
            string objOwner = JsonConvert.SerializeObject(owner);
            var content = new StringContent(objOwner, System.Text.Encoding.UTF8, "application/json");
            var postOwner = await client.PostAsync($"{url}", content);

            var getOwner = await client.GetAsync($"{url}/{owner.Id.ToString()}");
            var apiResponse = JsonConvert.DeserializeObject<Owner>(
                await getOwner.Content.ReadAsStringAsync());

            //assert
            Assert.AreEqual(owner.Id, apiResponse.Id);
            Assert.AreEqual(owner.Name, apiResponse.Name);
            Assert.AreEqual(owner.CPF, apiResponse.CPF);
            Assert.AreEqual(owner.Gender, apiResponse.Gender);
            Assert.AreEqual(owner.BirthDate, apiResponse.BirthDate);
        }

        [Test]
        public async Task TestingIfTheDeleteMethodIsDeletingTheOwnerCreated()
        {
            //arrange
            client = new HttpClient();
            Owner owner = new Owner();
            owner.Id = Guid.NewGuid();
            owner.Name = "Teste";
            owner.CPF = "12345678952";
            owner.Gender = 'M';
            owner.BirthDate = new DateTime();

            //act
            string objOwner = JsonConvert.SerializeObject(owner);
            var content = new StringContent(objOwner, System.Text.Encoding.UTF8, "application/json");
            var postOwner = await client.PostAsync($"{url}", content);

            var getOwner = await client.GetAsync($"{url}/{owner.Id.ToString()}");
            var apiResponse = JsonConvert.DeserializeObject<Owner>(
                await getOwner.Content.ReadAsStringAsync());

            var deleteOwner = await client.DeleteAsync($"{url}/{owner.Id.ToString()}");

            var getOwnerAfterDelete = await client.GetAsync($"{url}/{owner.Id.ToString()}");
            var apiResponseAfterDelete = JsonConvert.DeserializeObject<Owner>(
                await getOwnerAfterDelete.Content.ReadAsStringAsync());

            //assert
            Assert.IsNull(apiResponseAfterDelete);
        }
    }
}