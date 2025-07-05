using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Users.Domain.Model.Queries;

namespace TuChambaPe.Users.Domain.Services;

/**
 * <summary>
 *     The customer query service
 * </summary>
 * <remarks>
 *     This interface is used to handle customer queries
 * </remarks>
 */
public interface ICustomerQueryService
{
    Task<Customer?> Handle(GetCustomerByUidQuery query);

    Task<IEnumerable<Customer>> GetAllAsync();

    Task<IEnumerable<Customer>> GetByLocationAsync(string location);

    Task<IEnumerable<Customer>> GetVerifiedCustomersAsync();
}