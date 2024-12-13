using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using MoneyMap.Blazor.Data;

namespace MoneyMap.Blazor.Services;

public class ServerAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ServerAuthenticationStateProvider(SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContextAccessor)
    {
        _signInManager = signInManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var user = await _signInManager.ValidateSecurityStampAsync(_httpContextAccessor.HttpContext.User);
        if (user == null)
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        var identity = await _signInManager.CreateUserPrincipalAsync(user);
        return new AuthenticationState(identity);
    }
}