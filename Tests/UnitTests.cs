using Data.Model;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
       public void CustomerClassTest()
        {
            // Arrange
            Customer customer = new Customer();
            customer.Id = 1;
            customer.Name = "John Doe";
            customer.Address = "123 Main St";
            customer.Phone = "Anyta234own";

            // Act
            string name = customer.Name;
            string address = customer.Address;
            string phone = customer.Phone;

            // Assert
            Assert.AreEqual("John Doe", name);
            Assert.AreEqual("123 Main St", address);
            Assert.AreEqual("Anyta234own", phone);
        }

        [TestMethod]
        public void TravelClassSest()
        {
            // Arrange
            Travel travel = new Travel();
            travel.Id = 1;
            travel.CustomerId = 1;
            travel.Destination = "Sliven";

            // Act
            int id = travel.Id;
            int customerId = travel.CustomerId;
            string destination = travel.Destination;

            // Assert
            Assert.AreEqual(1, id);
            Assert.AreEqual(1, customerId);
            Assert.AreEqual("Sliven", destination);

        }
    }
}