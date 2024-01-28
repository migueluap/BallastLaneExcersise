using BallastLane.Domain.Commands;

namespace BallastLane.Domain.Validations;

public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand>
{
    public RegisterNewCustomerCommandValidation()
    {
        ValidateName();
        ValidateBirthDate();
        ValidateEmail();
    }
}