using Microsoft.JSInterop;
using System.Threading.Tasks;
// Service to manage the authentication state of the user in the local storage with Javascript Interop
public class AuthStateService
{
    private readonly IJSRuntime _js;
    public event Action? AuthStateChanged;
    public AuthStateService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task SetAuth(string username, string role)
    {
        await _js.InvokeVoidAsync("localStorage.setItem", "username", username);
        await _js.InvokeVoidAsync("localStorage.setItem", "role", role);
        AuthStateChanged?.Invoke();
    }

    public async Task<string> GetUsername() =>
        await _js.InvokeAsync<string>("localStorage.getItem", "username");

    public async Task<string> GetRole() =>
        await _js.InvokeAsync<string>("localStorage.getItem", "role");

    public async Task Logout()
    {
        await _js.InvokeVoidAsync("localStorage.removeItem", "username");
        await _js.InvokeVoidAsync("localStorage.removeItem", "role");
        AuthStateChanged?.Invoke();
    }
}
