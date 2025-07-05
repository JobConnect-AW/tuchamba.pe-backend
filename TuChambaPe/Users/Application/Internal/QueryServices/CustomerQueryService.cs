using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Users.Domain.Model.Queries;
using TuChambaPe.Users.Domain.Repositories;
using TuChambaPe.Users.Domain.Services;

namespace TuChambaPe.Users.Application.Internal.QueryServices;

/**
 * <summary>
 *     The customer query service
 * </summary>
 * <remarks>
 *     This service is used to handle customer queries
 * </remarks>
 */
public class CustomerQueryService(ICustomerRepository customerRepository) : ICustomerQueryService
{
    /**
     * <summary>
     *     Handle get customer by uid query
     * </summary>
     * <param name="query">The get customer by uid query</param>
     * <returns>The customer if found, null otherwise</returns>
     */
    public async Task<Customer?> Handle(GetCustomerByUidQuery query)
    {
        return await customerRepository.FindByUidAsync(query.Uid);
    }

    /**
     * <summary>
     *     Get all customers
     * </summary>
     * <returns>List of all customers</returns>
     */
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await customerRepository.ListAsync();
    }

    /**
     * <summary>
     *     Get customers by location
     * </summary>
     * <param name="location">The location to filter by</param>
     * <returns>List of customers in the specified location</returns>
     */
    public async Task<IEnumerable<Customer>> GetByLocationAsync(string location)
    {
        return await customerRepository.GetByLocationAsync(location);
    }

    /**
     * <summary>
     *     Get verified customers
     * </summary>
     * <returns>List of verified customers</returns>
     */
    public async Task<IEnumerable<Customer>> GetVerifiedCustomersAsync()
    {
        var allCustomers = await customerRepository.ListAsync();
        return allCustomers.Where(c => c.IsVerified);
    }
}