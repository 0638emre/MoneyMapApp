using MoneyMap.Blazor.Data;
using MoneyMap.Blazor.Models;

namespace MoneyMap.Blazor.Services;

public interface IUserService
{
    Task<ApplicationUser> GetUserAsync(string userName);
    Task<List<Investment>> GetUserInvestments(string userName);
    Task<bool> UpdateUserAsync(ApplicationUser user);
}