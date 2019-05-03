using GFT.Starter.Application;
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
            var name = "Joazinho";
            var cpf = "123.456.789-12";
            var gender = 'M';

            var ownerFactory = Singleton.OwnerFactory;

            //act
            var owner = ownerFactory.Create();

            //assert
            Assert.AreEqual(owner.Id, id);
            Assert.AreEqual(owner.Name, name);
            Assert.AreEqual(owner.CPF, cpf);
            Assert.AreEqual(owner.Gender, gender);



        }
    }
}