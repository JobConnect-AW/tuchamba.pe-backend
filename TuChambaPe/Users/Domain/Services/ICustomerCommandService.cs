using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Users.Domain.Model.Commands;

namespace TuChambaPe.Users.Domain.Services;

/**
 * <summary>
 *     The customer command service
 * </summary>
 * <remarks>
 *     This interface is used to handle customer commands
 * </remarks>
 */
public interface ICustomerCommandService
{
    Task<Customer> Handle(CreateCustomerCommand command);

    Task<Customer> Handle(UpdateCustomerCommand command);
}