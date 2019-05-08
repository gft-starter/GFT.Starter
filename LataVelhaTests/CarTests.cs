using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void WhenCreateCar_AndAssignAnOwner_ThenICanFindTheOwner()
        {
            //arrange
            //var ownerFactory = new OwnerFactory();
            //var carFactory = new CarFactory();
            //var owner = ownerFactory.Create(); 

            //act
            //var car = carFactory.Create(); //colocar várias variáveis

            //assert
            //Assert.AreEqual(car.OwnerId, owner.Id);
        }

        [Test]
        public void WhenCreateCar_AndCreateOwner_AndAssignOwner_AndUpdateCarProperties_ThenICanSeenNewPropertiesValue()
        {
            //arrange
            //var ownerFactory = new OwnerFactory();
            //var carFactory = new CarFactory();


            //act
            //var owner = ownerFactory.Create();
            //var car = carFactory.Create(); //colocar várias variáveis
        }
    }
}