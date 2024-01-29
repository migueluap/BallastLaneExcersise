namespace BallastLane.Domain.Commands.Tests;

[TestClass()]
public class RegisterNewCustomerCommandTest
{
    [TestMethod]
    [TestCategory("Domain")]
    public void IsValid_ShouldReturnTrue_WhenCommandIsValid()
    {
        // Arrange
        string name = "Renato Souza";
        string email = "renato.souza@example.com";
        DateTime birthDate = new DateTime(1990, 1, 1);

        RegisterNewCustomerCommand command = new RegisterNewCustomerCommand(name, email, birthDate);

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
        string name = "Renato Souza";
        string invalidEmail = "invalid_email"; // Invalid email format
        DateTime birthDate = new DateTime(1990, 1, 1);

        RegisterNewCustomerCommand command = new RegisterNewCustomerCommand(name, invalidEmail, birthDate);

        // Act
        bool isValid = command.IsValid();

        // Assert
        Assert.IsFalse(isValid);
        Assert.IsNotNull(command.ValidationResult); // ValidationResult should not be null for an invalid command
        Assert.IsTrue(command.ValidationResult.Errors.Count > 0); // There should be validation errors
    }
}

