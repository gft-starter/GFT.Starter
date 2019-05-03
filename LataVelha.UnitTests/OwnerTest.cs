using GFT.Starter.Application.Factories;
using GFT.Starter.Core.Models;
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
        public void WhenCreateOwner_ThenICanReadItsProperties()
        {
            //arrange
            var id = Guid.Empty;
            var cpf = "123.456.789-12";
            var name = "Joaozinho";
            var gender = 'M';

            var allFactory = AllFactory.OwnerFactory;

            //var allFactory = new AllFactory();
            //var ownerFactory = allFactory.Create("owner");

            //act
            var owner = allFactory.Create();

            //assert
            Assert.AreEqual(owner.Id, id);
            Assert.AreEqual(owner.CPF, cpf);
            Assert.AreEqual(owner.Name, name);
            Assert.AreEqual(owner.Gender, gender);
        }
    }
}