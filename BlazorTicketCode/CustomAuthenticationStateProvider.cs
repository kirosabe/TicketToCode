using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly AuthStateService _authState;

    public CustomAuthenticationStateProvider(AuthStateService authState)
    {
        _authState = authState;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var username = await _authState.GetUsername();
        var role = await _authState.GetRole();

        if (string.IsNullOrEmpty(username))
        {
            // Inte inloggad
            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
            return new AuthenticationState(anonymous);
        }

        // Skapa claims
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        }, "FakeAuthType");

        var user = new ClaimsPrincipal(identity);
        return new AuthenticationState(user);
    }

    public void NotifyAuthenticationChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
