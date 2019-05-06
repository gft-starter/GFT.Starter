using GFT.Starter.Application;
using GFT.Starter.Application.Factories;
using GFT.Starter.Core.Models;
using NUnit.Framework;
using System;

namespace UnitTests
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
            var id = Guid.Empty;
            var description = "Lavagem completa";
            var name = "LavCompl";
            var value = 50;

            var serviceFactory = Singleton.ServiceFactory;

            //act
            var service = serviceFactory.Create();

            //assert
            Assert.AreEqual(service.Id, id);
            Assert.AreEqual(service.Description, description);
            Assert.AreEqual(service.Name, name);
            Assert.AreEqual(service.Value, value);



        }
    }
}