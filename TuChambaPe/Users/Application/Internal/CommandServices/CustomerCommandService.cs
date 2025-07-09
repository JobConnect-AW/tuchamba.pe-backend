using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Users.Domain.Model.Commands;
using TuChambaPe.Users.Domain.Repositories;
using TuChambaPe.Users.Domain.Services;
using TuChambaPe.Shared.Domain.Repositories;

namespace TuChambaPe.Users.Application.Internal.CommandServices;

/**
 * <summary>
 *     The customer command service
 * </summary>
 * <remarks>
 *     This service is used to handle customer commands
 * </remarks>
 */
public class CustomerCommandService(ICustomerRepository customerRepository, IUserRepository userRepository, IUnitOfWork unitOfWork) : ICustomerCommandService
{
    /**
     * <summary>
     *     Handle create customer command
     * </summary>
     * <param name="command">The create customer command</param>
     * <returns>The created customer</returns>
     */
    public async Task<Customer> Handle(CreateCustomerCommand command)
    {
        var customer = new Customer(command.Uid, command.UserUid, command.FirstName, command.LastName, 
            command.Phone, command.ProfileType, command.Location, command.Bio);
        
        await customerRepository.AddAsync(customer);
        // Buscar y actualizar el User
        var user = await userRepository.FindByUidAsync(command.UserUid);
        if (user != null)
        {
            user.UpdateCustomerId(customer.Id);
            await userRepository.UpdateAsync(user);
        }
        await unitOfWork.CompleteAsync();
        return customer;
    }

    /**
     * <summary>
     *     Handle update customer command
     * </summary>
     * <param name="command">The update customer command</param>
     * <returns>The updated customer</returns>
     */
    public async Task<Customer> Handle(UpdateCustomerCommand command)
    {
        var customer = await customerRepository.FindByUidAsync(command.Uid);
        if (customer == null)
            throw new InvalidOperationException("Customer not found");

        // Update only non-null fields
        if (!string.IsNullOrEmpty(command.FirstName))
            customer.UpdateFirstName(command.FirstName);
        if (!string.IsNullOrEmpty(command.LastName))
            customer.UpdateLastName(command.LastName);
        if (!string.IsNullOrEmpty(command.Phone))
            customer.UpdatePhone(command.Phone);
        if (!string.IsNullOrEmpty(command.ProfileType))
            customer.UpdateProfileType(command.ProfileType);
        if (!string.IsNullOrEmpty(command.Location))
            customer.UpdateLocation(command.Location);
        if (!string.IsNullOrEmpty(command.Bio))
            customer.UpdateBio(command.Bio);

        await unitOfWork.CompleteAsync();
        return customer;
    }
}