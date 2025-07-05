using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Shared.Domain.Repositories;

namespace TuChambaPe.Users.Domain.Repositories;

public interface ICustomerRepository : IBaseRepository<Customer>
{

    Task<IEnumerable<Customer>> GetByLocationAsync(string location);
}