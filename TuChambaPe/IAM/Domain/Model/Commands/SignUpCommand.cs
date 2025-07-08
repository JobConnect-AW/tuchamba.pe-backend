namespace TuChambaPe.IAM.Domain.Model.Commands;

/**
 * <summary>
 *     The sign up command
 * </summary>
 * <remarks>
 *     This command object includes the email, password and role to sign up
 * </remarks>
 */
public record SignUpCommand(Guid Uid, string Email, string Password, string Role);