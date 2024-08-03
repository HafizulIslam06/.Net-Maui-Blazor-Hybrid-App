using Uapp.Services.Auth.Models;
using Uapp.Shared.Responses;

namespace Uapp.Services.Auth;

public interface IAuthService : IBaseService
{
    Task<string> LoginAsync(LoginModel model);
    Task<LoginResponse> GetCurrentUserAsync();
    Task LogoutAsync(bool isredirect);
}
