//using GFT.Starter.Core.Models;
//using Newtonsoft.Json;
//using NUnit.Framework;
//using System;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//namespace Tests
//{
//    public class OwnerTest
//    {
//        private const string url = "https://localhost:44343/";
//        private  HttpClient client;
//        [SetUp]
//        public void Setup()
//        {
//        }

//        [Test]
//        public async Task WhenRequestOwnerControllerUsingGet_ThenICanReceiveOwnersObjects()
//        {
//            //arrange
//            client = new HttpClient();

//            //act
//            var response = await client.GetAsync($"{url}");
//            var apiResponse = JsonConvert.DeserializeObject<Owner[]>(
//                await response.Content.ReadAsStringAsync());

//            //assert
//            Assert.NotNull(apiResponse);


//        }
//        [Test]

//        public async Task WhenRequestOwnerControllerUsingPost_ThenIcanRequestOwnerObject()
//        {
//            // arange
//            client = new HttpClient();
//            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
//            Owner owner = new Owner();
//            owner.Name = "Paulo";
//            owner.Gender = 'M';
//            owner.CPF = "654654654";
//            owner.BirthDate = DateTime.Now;


//            //act
//            var jsonContent = JsonConvert.SerializeObject(owner); // Converte o owner para json, e converte as informações para json
//            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json"); // cria a variavent content, configura o jason dentro dela com o enconding UTF8 e ela vai receber o json
//            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"); // ele tem dentro um json
//            var postResponse = await client.PostAsync($"{url}", content); // pega resposta inteira da api
//            var postApiResponse = JsonConvert.DeserializeObject<Owner>(await postResponse.Content.ReadAsStringAsync()); // ele pega o json e coloca tudo numa mesma string
//            var getResponse = await client.GetAsync($"{url}/{postApiResponse.Id}"); // pega oowner pegando ID dele e passando pro get
//            var getApiResponse = JsonConvert.DeserializeObject<Owner>(await getResponse.Content.ReadAsStringAsync());



//            //assert
//            Assert.IsNotNull(postApiResponse);
//            Assert.IsInstanceOf<Owner>(postApiResponse);
//            Assert.AreEqual(owner.Name, getApiResponse.Name);
//            Assert.AreEqual(owner.CPF, getApiResponse.CPF);
//            Assert.AreEqual(owner.Gender, getApiResponse.Gender);
//            Assert.AreEqual(owner.BirthDate, getApiResponse.BirthDate);





//        }
//    }
//}