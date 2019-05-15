using Application.Factories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LataNova.UnitTests
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
            // Arrange
            var value = 2.0f;
            var name = "Nome Serviço";
            var description = "Descrição Serviço";

            // Act
            var service = Factories.Service.Create(description, name, value);

            // Assert
            Assert.AreEqual(service.Value, value);
            Assert.AreEqual(service.Name, name);
            Assert.AreEqual(service.Description, description);
        }
    }
}
