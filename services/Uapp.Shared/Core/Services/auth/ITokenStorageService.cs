using Uapp.Shared.Responses;

namespace Uapp.Shared.Core.Services.auth;

public interface ITokenStorageService
{
    Task<string> GetAccessToken();
    Task SaveAccessToken(string token);
    Task<string> GetRefreshToken();
    //Task SaveRefreshToken(string token);
    Task SaveTokens(string accessToken);
    void RemoveTokens();
}
