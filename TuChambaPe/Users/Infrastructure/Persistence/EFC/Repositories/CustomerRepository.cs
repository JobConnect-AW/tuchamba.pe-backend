using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Users.Domain.Repositories;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Configuration;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TuChambaPe.Users.Infrastructure.Persistence.EFC.Repositories;

/**
 * <summary>
 *     The customer repository
 * </summary>
 * <remarks>
 *     This repository is used to manage customers
 * </remarks>
 */
public class CustomerRepository(AppDbContext context) : BaseRepository<Customer>(context), ICustomerRepository
{

    public async Task<IEnumerable<Customer>> GetByLocationAsync(string location)
    {
        return await Context.Set<Customer>()
            .Where(customer => customer.Location.Contains(location))
            .ToListAsync();
    }

    public async Task<Customer?> FindByUserUidAsync(Guid userUid)
    {
        return await Context.Set<Customer>().FirstOrDefaultAsync(c => c.UserUid == userUid);
    }
}