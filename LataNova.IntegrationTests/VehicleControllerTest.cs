using Core.Models;
using LataNova.IntegrationTests.Helpers;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LataNova.IntegrationTests
{
    public class VehicleControllerTest
    {
        //private const string url = "https://localhost:44347/api/Vehicle";
        private const string url = "https://latanovavehicles.azurewebsites.net/api/Vehicle";
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            client = new HttpClient();
        }

        [Test]
        public async Task WhenRequestVehicleControllerUsingGet_ThenICanReadTheResponseContent()
        {
            // Act
            var response = await client.GetAsync($"{url}");
            var apiResponse = JsonConvert.DeserializeObject<Vehicle[]>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.NotNull(apiResponse);
        }

        [Test]
        public async Task WhenRequestVehicleControllerUsingGetWithSpecificId_ThenIReceiveVehicle()
        {
            // Arrange
            var vehicle = VehicleHelper.CreateRandomVehicle();

            // Act
            var post_response = await client.PostAsync($"{url}",
                new StringContent(JsonConvert.SerializeObject(vehicle), Encoding.UTF8, "application/json"));
            Assert.AreEqual(post_response.StatusCode, System.Net.HttpStatusCode.OK);

            var response = await client.GetAsync($"{url}/{vehicle.Id}");
            var vehicleReceived = JsonConvert.DeserializeObject<Vehicle>(await response.Content.ReadAsStringAsync());

            // Assert
            Assert.NotNull(vehicleReceived);
            Assert.IsInstanceOf(typeof(Vehicle), vehicleReceived);
        }

        [Test]
        public async Task WhenRequestVehicleControllerUsingPost_AndRequestVehicleControllerUsingGetWithId_ThenICheckIfVehicleWasAddedCorrectly()
        {
            // Arrange
            var vehicle = VehicleHelper.CreateRandomVehicle();

            // Act
            var post_response = await client.PostAsync($"{url}",
                new StringContent(JsonConvert.SerializeObject(vehicle), Encoding.UTF8, "application/json"));
            Assert.AreEqual(post_response.StatusCode, System.Net.HttpStatusCode.OK);

            var get_response = await client.GetAsync($"{url}/{vehicle.Id}");
            Assert.AreEqual(get_response.StatusCode, System.Net.HttpStatusCode.OK);

            // Assert
            var vehicleReceived = JsonConvert.DeserializeObject<Vehicle>(await get_response.Content.ReadAsStringAsync());
            VehicleHelper.AssertVehicle(vehicle, vehicleReceived);
        }

        [Test]
        public async Task WhenRequestVehicleControllerUsingPostWithVehicleOnBody_AndRequestVehicleControllerUsingGet_ThenVerifyIfVehicleWasAdded_ThenRequestVehicleControllerUsingPutWithUpdatedVehicleOnBody_AndRequestVehicleControllerUsingGet_ThenVerifyIfVehicleWasUpdated()
        {
            // Arrange
            var vehicle = VehicleHelper.CreateRandomVehicle();

            // Act
            var post_response = await client.PostAsync($"{url}",
                new StringContent(JsonConvert.SerializeObject(vehicle), Encoding.UTF8, "application/json"));
            Assert.AreEqual(post_response.StatusCode, System.Net.HttpStatusCode.OK);

            var get_response = await client.GetAsync($"{url}/{vehicle.Id}");
            Assert.AreEqual(get_response.StatusCode, System.Net.HttpStatusCode.OK);
            VehicleHelper.AssertVehicle(vehicle, JsonConvert.DeserializeObject<Vehicle>(await get_response.Content.ReadAsStringAsync()));

            var updatedVehicle = VehicleHelper.CreateRandomVehicle();
            updatedVehicle.Id = vehicle.Id;
            var put_response = await client.PutAsync($"{url}/{vehicle.Id}",
                new StringContent(JsonConvert.SerializeObject(updatedVehicle), Encoding.UTF8, "application/json"));
            Assert.AreEqual(put_response.StatusCode, System.Net.HttpStatusCode.OK);

            get_response = await client.GetAsync($"{url}/{vehicle.Id}");
            Assert.AreEqual(get_response.StatusCode, System.Net.HttpStatusCode.OK);
            VehicleHelper.AssertVehicle(updatedVehicle, JsonConvert.DeserializeObject<Vehicle>(await get_response.Content.ReadAsStringAsync()));
        }

        [Test]
        public async Task WhenRequestVehicleControllerUsingPostWithVehicleOnBody_AndRequestVehicleControllerUsingGet_ThenVerifyIfVehicleWasAdded_ThenRequestVehicleControllerUsingDelete_AndRequestVehicleControllerUsingGet_ThenVerifyIfVehicleWasDeleted()
        {
            // Arrange
            var vehicle = VehicleHelper.CreateRandomVehicle();

            // Act
            var post_response = await client.PostAsync($"{url}",
                new StringContent(JsonConvert.SerializeObject(vehicle), Encoding.UTF8, "application/json"));
            Assert.AreEqual(post_response.StatusCode, System.Net.HttpStatusCode.OK);

            var get_response = await client.GetAsync($"{url}/{vehicle.Id}");
            Assert.AreEqual(get_response.StatusCode, System.Net.HttpStatusCode.OK);
            VehicleHelper.AssertVehicle(vehicle, JsonConvert.DeserializeObject<Vehicle>(await get_response.Content.ReadAsStringAsync()));

            var delete_response = await client.DeleteAsync($"{url}/{vehicle.Id}");
            Assert.AreEqual(delete_response.StatusCode, System.Net.HttpStatusCode.OK);

            get_response = await client.GetAsync($"{url}/{vehicle.Id}");
            Assert.AreEqual(get_response.StatusCode, System.Net.HttpStatusCode.NoContent);
        }
    }
}
