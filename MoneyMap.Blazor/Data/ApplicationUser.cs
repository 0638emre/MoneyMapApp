using Microsoft.AspNetCore.Identity;

namespace MoneyMap.Blazor.Data;

public class ApplicationUser: IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}