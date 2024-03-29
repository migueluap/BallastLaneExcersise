﻿using BallastLane.Domain.Commands;

namespace BallastLane.Domain.Test.Commands;

[TestClass]
public class RemoveCustomerCommandTest
{
    [TestMethod]
    [TestCategory("Domain")]
    public void IsValid_ShouldReturnTrue_WhenCommandIsValid()
    {
        // Arrange
        Guid customerId = Guid.NewGuid();
        RemoveCustomerCommand command = new RemoveCustomerCommand(customerId);

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
        RemoveCustomerCommand command = new RemoveCustomerCommand(Guid.Empty); // Invalid empty Guid

        // Act
        bool isValid = command.IsValid();

        // Assert
        Assert.IsFalse(isValid);
        Assert.IsNotNull(command.ValidationResult); // ValidationResult should not be null for an invalid command
        Assert.IsTrue(command.ValidationResult.Errors.Count > 0); // There should be validation errors
    }
}
