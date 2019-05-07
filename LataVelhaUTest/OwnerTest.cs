using Application.Factories;
using NUnit.Framework;
using System;

namespace Tests
{
    public class OwnerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenCreateOwner_thenICanReadItsProperties()
        {
            //arrange
            var id = Guid.Empty;
            var cpf = "123.456.789-11";
            var name = "Joao";
            var gender = 'M';
            var birthDate = DateTime.Now;
            var allFactory = new AllFactory();
            var ownerFactory = allFactory.Create("owner");


            //act
            var owner = ownerFactory.Create();

            //assert
            Assert.AreEqual(owner.Id, id);
            Assert.AreEqual(owner.Name, name);
            Assert.AreEqual(owner.CPF, cpf);
            Assert.AreEqual(owner.BirthDate, birthDate);
            Assert.AreEqual(owner.Gender, gender);

        }

    }
}