using Cortex.Mediator;
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
    IUnitOfWork unitOfWork,
    IMediator notificationPublisher)
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
        var proposal = new Proposal(command.Uid, command.OfferUid, command.WorkerUid, command.Message, command.Price, command.CreatedAt, null, null, null, command.Status);
        try
        {
            await proposalRepository.AddAsync(proposal);
            await unitOfWork.CompleteAsync();
            // Publicar evento ProposalCreatedEvent
            var createdEvent = new Domain.Model.Events.ProposalCreatedEvent(proposal.Uid, proposal.OfferUid);
            await notificationPublisher.PublishAsync(createdEvent);
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
        
        proposal.updateProposal(new Proposal(
            command.Uid,
            proposal.OfferUid,
            proposal.WorkerUid,
            command.Message,
            command.Price,
            proposal.CreatedAt,
            DateTime.UtcNow,
            proposal.CreatedBy,
            command.UpdatedBy,
            command.Status
            ));

        await proposalRepository.UpdateAsync(proposal);
        await unitOfWork.CompleteAsync();
        // Publicar evento ProposalUpdatedEvent
        
        var updatedEvent = new Domain.Model.Events.ProposalAcceptedEvent(proposal.Uid, proposal.OfferUid);
        await notificationPublisher.PublishAsync(updatedEvent);
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
} 