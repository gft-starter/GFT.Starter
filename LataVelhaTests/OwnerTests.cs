using GFT.Starter.Application.Singleton;
using NUnit.Framework;
using System;

namespace Tests
{
    public class OwnerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenCreateOwner_ThenICanReadItsProperties()
        {
            //arrange
            var name = "Gondolin";
            var cpf = "123456789";
            var gender = 'M';
            var birthdate = DateTime.Parse("01-01-2019");

            //act
            var owner = Singleton.OwnerFactory.Create(name, cpf, gender, birthdate);

            //assert
            Assert.AreEqual(name, owner.Name);
            Assert.AreEqual(cpf, owner.CPF);
            Assert.AreEqual(gender, owner.Gender);
            Assert.AreEqual(birthdate, owner.BirthDate);
        }

        [Test]
        public void WhenCreateOwner_AndUpdateOwnerProperties_ThenICanSeeNewPropertiesValues()
        {

        }
    }
}