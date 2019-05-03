using GFT.Starter.Application.Factories;
using GFT.Starter.Core.Models;
using NUnit.Framework;
using System;


namespace Tests
{
    public class ServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenCreateService_ThenICanReadItsProperties()
        {
            //arrange
            var factory = new ServiceFactory();
            var id = Guid.Empty;
            var name = "Service";
            var description = "Descricao";
            var value = 100;
            var allFactory = AllFactory.ServiceFactory;

            //act
            var service = allFactory.Create(); 

            //assert
            Assert.AreEqual(service.Id, id);
            Assert.AreEqual(service.Name, name);
            Assert.AreEqual(service.Description, description);
            Assert.AreEqual(service.Value, value);
        }
    }
}