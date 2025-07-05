using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Users.Interfaces.REST.Resources;

namespace TuChambaPe.Users.Interfaces.REST.Transform;

public static class WorkerResourceFromEntityAssembler
{
    public static WorkerResource ToResourceFromEntity(Worker entity)
    {
        return new WorkerResource(entity.Uid, entity.FirstName, entity.LastName, entity.Phone, entity.Avatar, entity.ProfileType, entity.Location, entity.Bio, entity.Skills, entity.Experience, entity.Certifications, entity.Rating, entity.ReviewCount, entity.IsVerified, entity.Availability, entity.YapeNumber, entity.PlinNumber, entity.BankAccountNumber, entity.CreatedAt, entity.UpdatedAt);
    }
}