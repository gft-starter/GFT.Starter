using Application.Factories;
using NUnit.Framework;
using System;

namespace LataNova.UnitTests
{
    public class OwnerTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void WhenCreateOwner_ThenICanReadItsProperties()
        {
            // Arrange
            var cpf = "987654321";
            var gender = 'F';
            var name = "OwnerNome";
            var birthdate = DateTime.Now;

            // Act
            var owner = Factories.Owner.Create(name, cpf, gender, birthdate);

            // Assert
            Assert.AreEqual(owner.Name, name);
            Assert.AreEqual(owner.BirthDate, birthdate);
            Assert.AreEqual(owner.CPF, cpf);
            Assert.AreEqual(owner.Gender, gender);
        }
    }
}
