using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Users.Domain.Model.Commands;

namespace TuChambaPe.Users.Domain.Services;

/**
 * <summary>
 *     The worker command service
 * </summary>
 * <remarks>
 *     This interface is used to handle worker commands
 * </remarks>
 */
public interface IWorkerCommandService
{
    Task<Worker> Handle(CreateWorkerCommand command);

    Task<Worker> Handle(UpdateWorkerCommand command);
}