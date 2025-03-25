using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

// Class to provide authentication state of the user
public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly AuthStateService _authState;

    public CustomAuthenticationStateProvider(AuthStateService authState)
    {
        _authState = authState;
    }
    // Method to get the authentication state of the user based on the username and role stored in the local storage
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var username = await _authState.GetUsername();
        var role = await _authState.GetRole();

        if (string.IsNullOrEmpty(username))
        {
            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
            return new AuthenticationState(anonymous);
        }

        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        }, "FakeAuthType");

        var user = new ClaimsPrincipal(identity);
        return new AuthenticationState(user);
    }
    // Method to notify the authentication state has changed needs to be called when the user logs in or logs out
    public void NotifyAuthenticationChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
