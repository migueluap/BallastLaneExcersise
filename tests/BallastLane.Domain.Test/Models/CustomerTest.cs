using BallastLane.Domain.Models;

namespace BallastLane.Domain.Test.Models;

[TestClass]
public class CustomerTest
{
    private readonly Customer _validCustomer = new Customer(Guid.NewGuid(), "Juan Perez", "juan@hotmail.com", new DateTime(2000,01,22));

    [TestMethod]
    [TestCategory("Domain")]
    public void Given_a_new_customer_he_needs_be_a_adult()
    {
        int ageValidCustomer = DateTime.Now.AddYears(-_validCustomer.BirthDate.Year).Year;
        bool isAdult = (ageValidCustomer >= 18) ? true : false;
        
        Assert.AreEqual(isAdult, true);
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Constructor_ShouldThrowException_WhenInvalidParametersProvided()
    {
        // Arrange
        Guid customerId = Guid.Empty;
        string name = "John Doe";
        string email = "invalid_email"; // Invalid email format
        DateTime birthDate = new DateTime(1990, 1, 1);

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => new Customer(customerId, name, email, birthDate));
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void Constructor_ShouldCreateInstanceOfCustomer_WhenValidParametersProvided()
    {
        // Arrange
        Guid customerId = Guid.NewGuid();
        string name = "John Doe";
        string email = "john.doe@example.com";
        DateTime birthDate = new DateTime(1990, 1, 1);

        // Act
        Customer customer = new Customer(customerId, name, email, birthDate);

        // Assert
        Assert.IsNotNull(customer);
        Assert.AreEqual(customerId, customer.Id);
        Assert.AreEqual(name, customer.Name);
        Assert.AreEqual(email, customer.Email);
        Assert.AreEqual(birthDate, customer.BirthDate);
    }
}
