using BallastLane.Domain.Commands;

namespace BallastLane.Domain.Test.Commands;

[TestClass]
public class UpdateCustomerCommandTest
{
    [TestMethod]
    [TestCategory("Domain")]
    public void IsValid_ShouldReturnTrue_WhenCommandIsValid()
    {
        // Arrange
        Guid customerId = Guid.NewGuid();
        string name = "Renato Souza";
        string email = "renato.souza@example.com";
        DateTime birthDate = new DateTime(1990, 1, 1);

        UpdateCustomerCommand command = new UpdateCustomerCommand(customerId, name, email, birthDate);

        // Act
        bool isValid = command.IsValid();

        // Assert
        Assert.IsTrue(isValid);
        Assert.IsNull(command.ValidationResult); // ValidationResult should be null for a valid command
    }

    [TestMethod]
    [TestCategory("Domain")]
    public void IsValid_ShouldReturnFalse_WhenCommandIsInvalid()
    {
        // Arrange
        Guid customerId = Guid.NewGuid();
        string invalidEmail = "invalid_email"; // Invalid email format
        UpdateCustomerCommand command = new UpdateCustomerCommand(customerId, "Renato Souza", invalidEmail, DateTime.Now);

        // Act
        bool isValid = command.IsValid();

        // Assert
        Assert.IsFalse(isValid);
        Assert.IsNotNull(command.ValidationResult); // ValidationResult should not be null for an invalid command
        Assert.IsTrue(command.ValidationResult.Errors.Count > 0); // There should be validation errors
    }
}
