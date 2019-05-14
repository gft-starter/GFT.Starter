using GFT.Starter.Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class OwnerTest
    {
        private const string url = "https://oficinafaisca.azurewebsites.net/api/Owner";
        private HttpClient httpClient;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task WhenRequestOwnerControllerUsingGet_ThenICanReceiveOwnersObject()
        {
            //arrange
            httpClient = new HttpClient();

            //act
            var response = await httpClient.GetAsync($"{url}");
            var apiResponse = JsonConvert.DeserializeObject<List<Owner>>(await response.Content.ReadAsStringAsync());

            //assert
            Assert.IsNotNull(apiResponse);
        }

        [Test]
        public async Task WhenRequestOwnerControllerUsingPost_ThenICanRequestOwnerObject()
        {
            //arrange
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            Owner owner = new Owner();
            owner.Name = "Elwing";
            owner.Gender = 'F';
            owner.CPF = "123456789";

            //act
            var jsonContent = JsonConvert.SerializeObject(owner);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var postResponse = await httpClient.PostAsync($"{url}", contentString);
            var postApiResponse = JsonConvert.DeserializeObject<Owner>(await postResponse.Content.ReadAsStringAsync());
            var getResponse = await httpClient.GetAsync($"{url}/{postApiResponse.Id}");
            var getApiResponse = JsonConvert.DeserializeObject<Owner>(await getResponse.Content.ReadAsStringAsync());

            //assert
            Assert.IsNotNull(postApiResponse);
            Assert.IsInstanceOf<Owner>(postApiResponse);
            Assert.AreEqual(owner.Name, getApiResponse.Name);
            Assert.AreEqual(owner.Gender, getApiResponse.Gender);
            Assert.AreEqual(owner.CPF, getApiResponse.CPF);
            Assert.AreEqual(owner.BirthDate, getApiResponse.BirthDate);
        }

        [Test]
        public async Task WhenRequestOwnerControllerUsingPost_ThenICanGetAnOwnerObjectById()
        {
            //arrange
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            Owner owner = new Owner();
            owner.Name = "Feanor";
            owner.Gender = 'M';
            owner.CPF = "987654321";

            //act
            var jsonContent = JsonConvert.SerializeObject(owner);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var postResponse = await httpClient.PostAsync($"{url}", contentString);
            var postApiResponse = JsonConvert.DeserializeObject<Owner>(await postResponse.Content.ReadAsStringAsync());

            var response = await httpClient.GetAsync($"{url}/{postApiResponse.Id}");
            var apiResponse = JsonConvert.DeserializeObject<Owner>(await response.Content.ReadAsStringAsync());

            //assert
            Assert.IsInstanceOf<Owner>(apiResponse);
            Assert.AreEqual(postApiResponse.Id, apiResponse.Id);
            Assert.AreEqual(owner.Name, apiResponse.Name);
            Assert.AreEqual(owner.Gender, apiResponse.Gender);
            Assert.AreEqual(owner.CPF, apiResponse.CPF);
            Assert.AreEqual(owner.BirthDate, apiResponse.BirthDate);
        }

        [Test]
        public async Task WhenRequestOwnerControllerUsingPost_ThenICanUpdateAnOwnerObjectAndReceiveThatObject()
        {
            //arrange
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            Owner owner = new Owner();
            owner.CPF = "123";
            owner.BirthDate = DateTime.Now;
            owner.Gender = 'M';
            owner.Name = "Earendil";

            //act

            var jsonContent = JsonConvert.SerializeObject(owner);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var postResponse = await httpClient.PostAsync($"{url}", contentString);
            var postApiResponse = JsonConvert.DeserializeObject<Owner>(await postResponse.Content.ReadAsStringAsync());

            postApiResponse.Name = "Thorondor";

            jsonContent = JsonConvert.SerializeObject(postApiResponse);
            contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var putResponse = await httpClient.PutAsync($"{url}/{postApiResponse.Id}", contentString);
            var putApiResponse = JsonConvert.DeserializeObject<Owner>(await putResponse.Content.ReadAsStringAsync());

            var getResponse = await httpClient.GetAsync($"{url}/{postApiResponse.Id}");
            var getApiResponse = JsonConvert.DeserializeObject<Owner>(await getResponse.Content.ReadAsStringAsync());

            //assert
            Assert.IsInstanceOf<Owner>(getApiResponse);
            Assert.AreEqual(putApiResponse.Name, getApiResponse.Name);


        }

        [Test]
        public async Task WhenRequestOwnerControllerUsingPostAndGet_ThenICanDeleteAnOwnerObjectById()
        {
            //arrange
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            Owner owner = new Owner();
            owner.CPF = "123";
            owner.Gender = 'M';
            owner.Name = "Manwë";

            //act
            var jsonContent = JsonConvert.SerializeObject(owner);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var postResponse = await httpClient.PostAsync($"{url}", contentString);
            var postApiResponse = JsonConvert.DeserializeObject<Owner>(await postResponse.Content.ReadAsStringAsync());

            var getResponse = await httpClient.GetAsync($"{url}/{postApiResponse.Id}");
            var getApiResponse = JsonConvert.DeserializeObject<Owner>(await getResponse.Content.ReadAsStringAsync());

            var deleteResponse = await httpClient.DeleteAsync($"{url}/{getApiResponse.Id}");
            var deleteApiResponse = JsonConvert.DeserializeObject<Owner>(await deleteResponse.Content.ReadAsStringAsync());

            //assert
            Assert.IsInstanceOf<Owner>(deleteApiResponse);
            Assert.AreEqual(owner.Name, deleteApiResponse.Name);
            Assert.AreEqual(owner.CPF, deleteApiResponse.CPF);
            Assert.AreEqual(owner.Gender, deleteApiResponse.Gender);
            Assert.AreEqual(owner.BirthDate, deleteApiResponse.BirthDate);
        }
    }
}