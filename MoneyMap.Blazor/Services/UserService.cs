using Microsoft.EntityFrameworkCore;
using MoneyMap.Blazor.Data;
using MoneyMap.Blazor.Models;

namespace MoneyMap.Blazor.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ApplicationUser> GetUserAsync(string userName)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.UserName.Equals(userName));
    }

    public async Task<List<Investment>> GetUserInvestments(string userName)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        if (user == null)
        {
            return new List<Investment>();
        }

        return await _context.Investments.Where(x => x.UserId.Equals(user.Id)).ToListAsync();
    }

    public async Task<bool> UpdateUserAsync(ApplicationUser user)
    {
        _context.Users.Update(user);
        var affectedCount = await _context.SaveChangesAsync();
        return affectedCount > 0;
    }
}