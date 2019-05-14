using Application.Factories;
using Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class OwnerTest
    {

        private const string url = "https://localhost:44362/api/Owner";
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

        [Test]
        public async Task WhenCreateOwnerUsingPost_thenICanPostOwnerObject()
        {
            //arrenge
            client = new HttpClient();
            var id = Guid.NewGuid();
            var cpf = "123.456.789-11";
            var name = "Joao";
            var gender = 'M';
            var birthDate = DateTime.Now;
            var allFactory = new AllFactory();
            var ownerFactory = allFactory.Create("owner");

            //act
            var owner = ownerFactory.Create(id,name, cpf, gender,  birthDate);
            string objOwner = JsonConvert.SerializeObject(owner);
            var ownercontent = new StringContent(objOwner, System.Text.Encoding.UTF8, "application/json");
            var postOwner = await client.PostAsync($"{url}", ownercontent);

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
    }
}

/////////////
//minha tentativa em test post
////arrenge
//client = new HttpClient();
//var id = Guid.NewGuid();
//var cpf = "123.456.789-11";
//var name = "Joao";
//var gender = 'M';
//var birthDate = DateTime.Now;
//var allFactory = new AllFactory();
//var ownerFactory = allFactory.Create("owner");

////act
//var owner = ownerFactory.Create();
//var response = client.PostAsync($"{url}", owner);
//var apiResponse = JsonConvert.DeserializeObject<Owner[]>(
//    await response.content.WriteAsStringAsync());

////assert
//Assert.IsTrue(apiResponse); 