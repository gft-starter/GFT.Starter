using Core.Models;
using LataNova.IntegrationTests.Helpers;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LataNova.IntegrationTests
{
    public class OwnerControllerTest
    {
        //private const string url = "https://localhost:44394/api/Owner";
        private const string url = "https://ownerapi.azurewebsites.net/api/Owner";
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            client = new HttpClient();
        }

        [Test]
        public async Task WhenRequestOwnerControllerUsingGet_ThenICanReadTheResponseContent()
        {
            // Arrange
            client = new HttpClient();

            // Act
            var response = await client.GetAsync($"{url}");
            var apiResponse = JsonConvert.DeserializeObject<Owner[]>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.NotNull(apiResponse);
        }

        [Test]
        public async Task WhenRequestOwnerControllerUsingGetWithSpecificId_ThenIReceiveOwner()
        {
            // Arrange
            var owner = OwnerHelper.CreateRandomOwner();

            // Act
            var post_response = await client.PostAsync($"{url}",
                new StringContent(JsonConvert.SerializeObject(owner), Encoding.UTF8, "application/json"));

            var response = await client.GetAsync($"{url}/{owner.Id}");
            var ownerReceived = JsonConvert.DeserializeObject<Owner>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.NotNull(ownerReceived);
            Assert.IsInstanceOf(typeof(Owner), ownerReceived);
        }

        [Test]
        public async Task WhenRequestOwnerControllerUsingPost_ThenICheckIfOwnerWasAdded()
        {
            // Arrange
            var owner = OwnerHelper.CreateRandomOwner();

            // Act
            var response = await client.PostAsync($"{url}",
                new StringContent(JsonConvert.SerializeObject(owner), Encoding.UTF8, "application/json"));

            // Assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [Test]
        public async Task WhenRequestOwnerControllerUsingPostWithOwnerOnBody_AndRequestOwnerControllerUsingGet_ThenVerifyIfOwnerWasAdded_ThenRequestOwnerControllerUsingPutWithUpdatedOwnerOnBody_AndRequestOwnerControllerUsingGet_ThenVerifyIfOwnerWasUpdated()
        {
            // Arrange
            var owner = OwnerHelper.CreateRandomOwner();

            // Act
            var post_response = await client.PostAsync($"{url}",
                new StringContent(JsonConvert.SerializeObject(owner), Encoding.UTF8, "application/json"));
            Assert.AreEqual(post_response.StatusCode, System.Net.HttpStatusCode.OK);

            var get_response = await client.GetAsync($"{url}/{owner.Id}");
            Assert.AreEqual(get_response.StatusCode, System.Net.HttpStatusCode.OK);
            OwnerHelper.AssertOwner(owner, JsonConvert.DeserializeObject<Owner>(await get_response.Content.ReadAsStringAsync()));

            var updatedOwner = OwnerHelper.CreateRandomOwner();
            updatedOwner.Id = owner.Id;
            var put_response = await client.PutAsync($"{url}/{owner.Id}",
                new StringContent(JsonConvert.SerializeObject(updatedOwner), Encoding.UTF8, "application/json"));
            Assert.AreEqual(put_response.StatusCode, System.Net.HttpStatusCode.OK);

            get_response = await client.GetAsync($"{url}/{owner.Id}");
            Assert.AreEqual(get_response.StatusCode, System.Net.HttpStatusCode.OK);
            OwnerHelper.AssertOwner(updatedOwner, JsonConvert.DeserializeObject<Owner>(await get_response.Content.ReadAsStringAsync()));
        }

        [Test]
        public async Task WhenRequestOwnerControllerUsingPost_ThenVerifyIfOwnerWasCreatedUsingGetRequest_ThenISendDeleteRequestToOwnerController_ThenICantFindOwnerOnGet()
        {
            // Arrange
            var owner = OwnerHelper.CreateRandomOwner();

            client = new HttpClient();
            var insert_response = await client.PostAsync($"{url}",
                new StringContent(JsonConvert.SerializeObject(owner), Encoding.UTF8, "application/json"));
            var get_response = await client.GetAsync($"{url}/{owner.Id}");

            // Act
            var delete_response = await client.DeleteAsync($"{url}/{owner.Id}");
            get_response = await client.GetAsync($"{url}/{owner.Id}");

            var test = get_response.Content.ReadAsStringAsync();
            // Assert
            Assert.AreEqual(get_response.StatusCode, System.Net.HttpStatusCode.NoContent);
        }
    }
}