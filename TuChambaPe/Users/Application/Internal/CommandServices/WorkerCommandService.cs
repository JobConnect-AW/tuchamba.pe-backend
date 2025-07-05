using TuChambaPe.Users.Domain.Model.Aggregates;
using TuChambaPe.Users.Domain.Model.Commands;
using TuChambaPe.Users.Domain.Repositories;
using TuChambaPe.Users.Domain.Services;
using TuChambaPe.Shared.Domain.Repositories;

namespace TuChambaPe.Users.Application.Internal.CommandServices;

/**
 * <summary>
 *     The worker command service
 * </summary>
 * <remarks>
 *     This service is used to handle worker commands
 * </remarks>
 */
public class WorkerCommandService(IWorkerRepository workerRepository, IUnitOfWork unitOfWork) : IWorkerCommandService
{
    /**
     * <summary>
     *     Handle create worker command
     * </summary>
     * <param name="command">The create worker command</param>
     * <returns>The created worker</returns>
     */
    public async Task<Worker> Handle(CreateWorkerCommand command)
    {
        var worker = new Worker(command.Uid, command.FirstName, command.LastName, 
            command.Phone, command.ProfileType, command.Location, command.Bio, command.Skills, 
            command.Experience, command.Certifications, false, command.Avatar);
        
        await workerRepository.AddAsync(worker);
        await unitOfWork.CompleteAsync();
        return worker;
    }

    /**
     * <summary>
     *     Handle update worker command
     * </summary>
     * <param name="command">The update worker command</param>
     * <returns>The updated worker</returns>
     */
    public async Task<Worker> Handle(UpdateWorkerCommand command)
    {
        var worker = await workerRepository.FindByUidAsync(command.Uid);
        if (worker == null)
            throw new InvalidOperationException("Worker not found");

        // Update only non-null fields
        if (!string.IsNullOrEmpty(command.FirstName))
            worker.UpdateFirstName(command.FirstName);
        if (!string.IsNullOrEmpty(command.LastName))
            worker.UpdateLastName(command.LastName);
        if (!string.IsNullOrEmpty(command.Phone))
            worker.UpdatePhone(command.Phone);
        if (!string.IsNullOrEmpty(command.Avatar))
            worker.UpdateAvatar(command.Avatar);
        if (!string.IsNullOrEmpty(command.ProfileType))
            worker.UpdateProfileType(command.ProfileType);
        if (!string.IsNullOrEmpty(command.Location))
            worker.UpdateLocation(command.Location);
        if (!string.IsNullOrEmpty(command.Bio))
            worker.UpdateBio(command.Bio);
        if (command.Skills != null)
            worker.UpdateSkills(command.Skills);
        if (command.Experience.HasValue)
            worker.UpdateExperience(command.Experience.Value);
        if (command.Certifications != null)
            worker.UpdateCertifications(command.Certifications);
        if (command.Availability != null)
            worker.UpdateAvailability(command.Availability);
        if (command.YapeNumber != null || command.PlinNumber != null || command.BankAccountNumber != null)
            worker.UpdatePaymentInfo(command.YapeNumber, command.PlinNumber, command.BankAccountNumber);

        await unitOfWork.CompleteAsync();
        return worker;
    }
}