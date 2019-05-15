using Application.Factories;
using Core.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LataNova.IntegrationTests.Helpers
{
    public static class OwnerHelper
    {
        public static Owner CreateRandomOwner()
        {
            var name = Utils.RandomString(10);
            var cpf = Utils.RandomString(10);
            var gender = Utils.RandomString(1).ToCharArray()[0];
            var birthdate = DateTime.UtcNow;
            return Factories.Owner.Create(name, cpf, gender, birthdate);
        }

        public static void AssertOwner(Owner a, Owner b)
        {
            Assert.AreEqual(a.Id, b.Id);
            Assert.AreEqual(a.BirthDate, b.BirthDate);
            Assert.AreEqual(a.CPF, b.CPF);
            Assert.AreEqual(a.Gender, b.Gender);
            Assert.AreEqual(a.Name, b.Name);
        }
    }
}
