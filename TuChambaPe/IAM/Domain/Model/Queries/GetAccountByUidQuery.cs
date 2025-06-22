namespace TuChambaPe.IAM.Domain.Model.Queries;

/**
 * <summary>
 *     The get account by uid query
 * </summary>
 * <remarks>
 *     This query object includes the uid to get an account
 * </remarks>
 */
public record GetAccountByUidQuery(Guid Uid); 