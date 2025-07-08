namespace TuChambaPe.IAM.Domain.Model.ValueObjects;

/// <summary>
///     Role value object
/// </summary>
public static class Role
{
    /// <summary>
    ///     Customer role
    /// </summary>
    public const string CUSTOMER = "customer";
    
    /// <summary>
    ///     Worker role
    /// </summary>
    public const string WORKER = "worker";
    
    /// <summary>
    ///     Admin role
    /// </summary>
    public const string ADMIN = "admin";
    
    /// <summary>
    ///     Check if the role is valid
    /// </summary>
    /// <param name="role">The role to validate</param>
    /// <returns>True if valid, false otherwise</returns>
    public static bool IsValid(string role)
    {
        return role switch
        {
            CUSTOMER => true,
            WORKER => true,
            ADMIN => true,
            _ => false
        };
    }
    
    /// <summary>
    ///     Get all valid roles
    /// </summary>
    /// <returns>Array of valid roles</returns>
    public static string[] GetAllRoles()
    {
        return new[] { CUSTOMER, WORKER, ADMIN };
    }
} 