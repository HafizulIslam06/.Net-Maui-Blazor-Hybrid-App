using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace Uapp.Shared.Core.Services.auth;

public class UappAuthStateProvider : AuthenticationStateProvider
{
    private readonly ITokenStorageService _tokenStorageService;
    private readonly HttpClient _httpClient;
    private ClaimsPrincipal anonymous = new ClaimsPrincipal(new ClaimsIdentity());

    public UappAuthStateProvider(ITokenStorageService tokenStorageService, HttpClient httpClient)
    {
        _tokenStorageService = tokenStorageService;
        _httpClient = httpClient;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var accessToken =await _tokenStorageService.GetAccessToken();

            if (string.IsNullOrWhiteSpace(accessToken))
                return await Task.FromResult(new AuthenticationState(anonymous));

            var identity = new ClaimsIdentity(ParseClaimsFromJwt(accessToken), "jwt");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken.Replace("\"", ""));

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
        catch (Exception)
        {
            return await Task.FromResult(new AuthenticationState(anonymous));
        }
    }

    public void LogoutAuthenticationState()
    {
        _tokenStorageService.RemoveTokens();
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
    }

    private byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }

    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer
            .Deserialize<Dictionary<string, object>>(jsonBytes);

        var claims = keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));

        return claims;
    }
}
