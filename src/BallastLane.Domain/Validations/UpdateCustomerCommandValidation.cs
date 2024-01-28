using BallastLane.Domain.Commands;

namespace BallastLane.Domain.Validations;

public class UpdateCustomerCommandValidation : CustomerValidation<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidation()
    {
        ValidateId();
        ValidateName();
        ValidateBirthDate();
        ValidateEmail();
    }
}