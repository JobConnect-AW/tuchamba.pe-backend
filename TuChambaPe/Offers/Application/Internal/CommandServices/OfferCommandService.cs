using TuChambaPe.Offers.Domain.Model.Aggregates;
using TuChambaPe.Offers.Domain.Model.Commands;
using TuChambaPe.Offers.Domain.Repositories;
using TuChambaPe.Offers.Domain.Services;
using TuChambaPe.Shared.Domain.Repositories;

namespace TuChambaPe.Offers.Application.Internal.CommandServices;

/**
 * <summary>
 *     The offer command service
 * </summary>
 * <remarks>
 *     This class is used to handle offer commands
 * </remarks>
 */
public class OfferCommandService(
    IOfferRepository offerRepository,
    IUnitOfWork unitOfWork)
    : IOfferCommandService
{
    /**
     * <summary>
     *     Handle create offer command
     * </summary>
     * <param name="command">The create offer command</param>
     * <returns>The created offer</returns>
     */
    public async Task<Offer> Handle(CreateOfferCommand command)
    {
        var offer = new Offer(command);
        try
        {
            await offerRepository.AddAsync(offer);
            await unitOfWork.CompleteAsync();
            return offer;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating offer: {e.Message}");
        }
    }

    /**
     * <summary>
     *     Handle update offer command
     * </summary>
     * <param name="command">The update offer command</param>
     */
    public async Task Handle(UpdateOfferCommand command)
    {
        var offer = await offerRepository.FindByUidAsync(command.Id);
        if (offer == null)
            throw new Exception($"Offer with Uid {command.Id} not found");

        
        // Update offer properties
        // Note: Since properties are private set, we might need to add update methods to the Offer entity
        // For now, we'll throw an exception indicating this needs to be implemented
        throw new NotImplementedException("Update functionality needs to be implemented in the Offer entity");
    }

    /**
     * <summary>
     *     Handle delete offer command
     * </summary>
     * <param name="command">The delete offer command</param>
     */
    public async Task Handle(DeleteOfferCommand command)
    {
        var offer = await offerRepository.FindByUidAsync(command.Id);
        if (offer == null)
            throw new Exception($"Offer with Uid {command.Id} not found");

        try
        {
            offerRepository.Remove(offer);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while deleting offer: {e.Message}");
        }
    }
} 