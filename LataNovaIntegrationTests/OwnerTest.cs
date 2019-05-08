using GFT.Starter.Core.Models;
using Microsoft.AspNetCore.Mvc;
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
        public void Test1()
        {
            Assert.Pass();
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
        public async Task WhenRequestOwnerControllerUsingPost_ThenICanCreateOwnersObject()
        {
            //arrange
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            Owner owner = new Owner();
            owner.Name = "Jonas";
            owner.Gender = 'M';
            owner.CPF = "123456789";
            owner.BirthDate = DateTime.Now;

            //act
            var jsonContent = JsonConvert.SerializeObject(owner);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await httpClient.PostAsync($"{url}", contentString);
            var postApiResponse = JsonConvert.DeserializeObject<Owner>(await response.Content.ReadAsStringAsync());

            var getResponse = await httpClient.GetAsync($"{url}/{postApiResponse.Id}");
            var getApiResponse = JsonConvert.DeserializeObject<Owner>(await response.Content.ReadAsStringAsync());

            //assert
            Assert.IsNotNull(postApiResponse);
            Assert.IsInstanceOf<Owner>(postApiResponse);
            Assert.AreNotEqual(owner, postApiResponse);
        }

        [Test]
        public async Task WhenRequestOwnerControllerUsingGetById_ThenICanReceiveAnOwnerObject()
        {
            //arrange
            httpClient = new HttpClient();
            Guid id = Guid.Parse("d388764d-c7cb-46a7-a16e-04e7dce940c4");

            //act
            var response = await httpClient.GetAsync($"{url}/{id}");
            var apiResponse = JsonConvert.DeserializeObject<Owner>(await response.Content.ReadAsStringAsync());

            //assert
            Assert.IsInstanceOf<Owner>(apiResponse);
            Assert.AreEqual(id, apiResponse.Id);
        }

        [Test]
        public async Task WhenRequestOwnerControllerUsingPutById_ThenICanUpdateAnOwnerObject()
        {
            //arrange
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            Owner owner = new Owner();
            Guid id = Guid.Parse("d388764d-c7cb-46a7-a16e-04e7dce940c4");
            owner.Id = id;
            owner.CPF = "123";
            owner.BirthDate = DateTime.Now;
            owner.Gender = 'M';
            owner.Name = "Lucas";

            //act
            var jsonContent = JsonConvert.SerializeObject(owner);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await httpClient.PutAsync($"{url}/{id}", contentString);
            var apiResponse = JsonConvert.DeserializeObject<Owner>(await response.Content.ReadAsStringAsync());

            //assert
            Assert.IsInstanceOf<Owner>(apiResponse);
            Assert.AreEqual(owner.Name, apiResponse.Name);
        }

        [Test]
        public async Task WhenRequestOwnerControllerUsingDeleteById_ThenICanDeleteAnOwnerObject()
        {
            //arrange
            httpClient = new HttpClient();
            Guid id = Guid.Parse("d388764d-c7cb-46a7-a16e-04e7dce940c4");

            //act
            var response = await httpClient.DeleteAsync($"{url}/{id}");
            var apiResponse = JsonConvert.DeserializeObject<Owner>(await response.Content.ReadAsStringAsync());

            //assert
            Assert.IsInstanceOf<Owner>(apiResponse);
        }
    }
}