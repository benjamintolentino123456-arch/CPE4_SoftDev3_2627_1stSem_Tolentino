using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;

namespace CPE4_SoftDev3_2627_1stSem_Tolentino.Web.Services;


public class WebAuthStateProvider : RevalidatingServerAuthenticationStateProvider
{
    public WebAuthStateProvider(ILoggerFactory loggerFactory) : base(loggerFactory)
    {
    }
    protected override TimeSpan RevalidationInterval => TimeSpan.FromSeconds(1);

    protected override Task<bool> ValidateAuthenticationStateAsync(AuthenticationState authenticationState, CancellationToken cancellationToken)
    {
        //authenticationState.User.Claims.
        return Task.FromResult(true);
    }
}

