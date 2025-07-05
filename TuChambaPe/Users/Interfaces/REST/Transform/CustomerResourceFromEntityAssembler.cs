using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Users.Interfaces.REST.Resources;

namespace TuChambaPe.Users.Interfaces.REST.Transform;

public static class CustomerResourceFromEntityAssembler
{
    public static CustomerResource ToResourceFromEntity(Customer entity)
    {
        return new CustomerResource(entity.Uid, entity.FirstName, entity.LastName, entity.Phone, entity.ProfileType, entity.Location, entity.Bio, entity.IsVerified, entity.CreatedAt, entity.UpdatedAt);
    }
}