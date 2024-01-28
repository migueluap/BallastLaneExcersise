using BallastLane.Domain.Commands;

namespace BallastLane.Domain.Validations;

public class RemoveCustomerCommandValidation : CustomerValidation<RemoveCustomerCommand>
{
    public RemoveCustomerCommandValidation()
    {
        ValidateId();
    }
}