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
        private const string url = "http://localhost:50437/api/owner";
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
            string objOwner = JsonConvert.SerializeObject(owner);
            var content = new StringContent(objOwner, System.Text.Encoding.UTF8, "application/json");
            var post = await client.PostAsync($"{url}", content);

            var get = await client.GetAsync($"{url}/{owner.Id.ToString()}");
            var apiResponse = JsonConvert.DeserializeObject<Owner>(await get.Content.ReadAsStringAsync());

            //assert
            Assert.AreEqual(owner.Id, apiResponse.Id);
            Assert.AreEqual(owner.CPF, apiResponse.CPF);
            Assert.AreEqual(owner.Name, apiResponse.Name);
            Assert.AreEqual(owner.BirthDate, apiResponse.BirthDate);
            Assert.AreEqual(owner.Gender, apiResponse.Gender);
        }

        [Test]
        public async Task WhenRequestingOwnerControllerUsingPut_ThenVerifyIfOwnerWasUpdated()
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
            var newOwner = new Owner()
            {
                Id = owner.Id,
                CPF = "15616156",
                Name = "Leonardo",
                BirthDate = new DateTime(),
                Gender = 'M'
            };

            string objOwnerPost = JsonConvert.SerializeObject(owner);
            var contentPost = new StringContent(objOwnerPost, System.Text.Encoding.UTF8, "application/json");
            var post = await client.PostAsync($"{url}", contentPost);

            var get = await client.GetAsync($"{url}/{owner.Id.ToString()}");
            var apiResponsePost = JsonConvert.DeserializeObject<Owner>(await get.Content.ReadAsStringAsync());

            string objOwnerPut = JsonConvert.SerializeObject(newOwner);
            var contentPut = new StringContent(objOwnerPut, System.Text.Encoding.UTF8, "application/json");
            var put = await client.PutAsync($"{url}/{owner.Id.ToString()}", contentPut);

            var newGet = await client.GetAsync($"{url}/{newOwner.Id.ToString()}");
            var apiResponsePut = JsonConvert.DeserializeObject<Owner>(await get.Content.ReadAsStringAsync());


            //assert
            Assert.IsNotNull(apiResponsePost);

            Assert.AreEqual(owner.Id, apiResponsePost.Id);
            Assert.AreEqual(owner.CPF, apiResponsePost.CPF);
            Assert.AreEqual(owner.Name, apiResponsePost.Name);
            Assert.AreEqual(owner.BirthDate, apiResponsePost.BirthDate);
            Assert.AreEqual(owner.Gender, apiResponsePost.Gender);

            Assert.IsNotNull(put);

            Assert.AreEqual(newOwner.Id, apiResponsePut.Id);

            Assert.AreEqual(newOwner.CPF, apiResponsePut.CPF);
            Assert.AreEqual(newOwner.Name, apiResponsePut.Name);
            Assert.AreEqual(newOwner.BirthDate, apiResponsePut.BirthDate);
            Assert.AreEqual(newOwner.Gender, apiResponsePut.Gender);
        }

        
    }
}