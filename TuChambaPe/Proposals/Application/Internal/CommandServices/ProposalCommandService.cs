using TuChambaPe.Proposals.Domain.Model.Aggregates;
using TuChambaPe.Proposals.Domain.Model.Commands;
using TuChambaPe.Proposals.Domain.Repositories;
using TuChambaPe.Proposals.Domain.Services;
using TuChambaPe.Shared.Domain.Repositories;

namespace TuChambaPe.Proposals.Application.Internal.CommandServices;

/**
 * <summary>
 *     The proposal command service
 * </summary>
 * <remarks>
 *     This class is used to handle proposal commands
 * </remarks>
 */
public class ProposalCommandService(
    IProposalRepository proposalRepository,
    IUnitOfWork unitOfWork)
    : IProposalCommandService
{
    /**
     * <summary>
     *     Handle create proposal command
     * </summary>
     * <param name="command">The create proposal command</param>
     * <returns>The created proposal</returns>
     */
    public async Task<Proposal> Handle(CreateProposalCommand command)
    {
        var proposal = new Proposal(command);
        try
        {
            await proposalRepository.AddAsync(proposal);
            await unitOfWork.CompleteAsync();
            return proposal;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating proposal: {e.Message}");
        }
    }

    /**
     * <summary>
     *     Handle update proposal command
     * </summary>
     * <param name="command">The update proposal command</param>
     */
    public async Task Handle(UpdateProposalCommand command)
    {
        var proposal = await proposalRepository.FindByUidAsync(command.Uid);
        if (proposal == null)
            throw new Exception($"Proposal with Uid {command.Uid} not found");

        // Update proposal properties
        // Note: Since properties are private set, we might need to add update methods to the Proposal entity
        // For now, we'll throw an exception indicating this needs to be implemented
        throw new NotImplementedException("Update functionality needs to be implemented in the Proposal entity");
    }

    /**
     * <summary>
     *     Handle delete proposal command
     * </summary>
     * <param name="command">The delete proposal command</param>
     */
    public async Task Handle(DeleteProposalCommand command)
    {
        var proposal = await proposalRepository.FindByUidAsync(command.Uid);
        if (proposal == null)
            throw new Exception($"Proposal with Uid {command.Uid} not found");

        try
        {
            proposalRepository.Remove(proposal);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while deleting proposal: {e.Message}");
        }
    }

    /**
     * <summary>
     *     Handle accept proposal command
     * </summary>
     * <param name="command">The accept proposal command</param>
     */
    public async Task Handle(AcceptProposalCommand command)
    {
        var proposal = await proposalRepository.FindByUidAsync(command.Uid);
        if (proposal == null)
            throw new Exception($"Proposal with Uid {command.Uid} not found");

        try
        {
            proposal.Accept();
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while accepting proposal: {e.Message}");
        }
    }

    /**
     * <summary>
     *     Handle reject proposal command
     * </summary>
     * <param name="command">The reject proposal command</param>
     */
    public async Task Handle(RejectProposalCommand command)
    {
        var proposal = await proposalRepository.FindByUidAsync(command.Uid);
        if (proposal == null)
            throw new Exception($"Proposal with Uid {command.Uid} not found");

        try
        {
            proposal.Reject();
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while rejecting proposal: {e.Message}");
        }
    }

    /**
     * <summary>
     *     Handle mark as in progress proposal command
     * </summary>
     * <param name="command">The mark as in progress proposal command</param>
     */
    public async Task Handle(MarkAsInProgressProposalCommand command)
    {
        var proposal = await proposalRepository.FindByUidAsync(command.Uid);
        if (proposal == null)
            throw new Exception($"Proposal with Uid {command.Uid} not found");

        try
        {
            proposal.MarkAsInProgress();
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while marking proposal as in progress: {e.Message}");
        }
    }

    /**
     * <summary>
     *     Handle complete proposal command
     * </summary>
     * <param name="command">The complete proposal command</param>
     */
    public async Task Handle(CompleteProposalCommand command)
    {
        var proposal = await proposalRepository.FindByUidAsync(command.Uid);
        if (proposal == null)
            throw new Exception($"Proposal with Uid {command.Uid} not found");

        try
        {
            proposal.CompleteProposal();
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while completing proposal: {e.Message}");
        }
    }
} 