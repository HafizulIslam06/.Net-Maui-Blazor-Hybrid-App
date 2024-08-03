using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;

namespace Uapp.Shared.Core.Services.auth;

public class AuthInterceptor : DelegatingHandler
{
    private readonly ITokenStorageService _tokenStorageService;
    private readonly NavigationManager _navigation;

    public AuthInterceptor(ITokenStorageService tokenStorageService, NavigationManager navigation)
    {
        _tokenStorageService = tokenStorageService;
        _navigation = navigation;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // before request
        var accessToken = await _tokenStorageService.GetAccessToken();
        if (accessToken != null)
        {
            if (TokenHelper.IsExpired(accessToken))
                _navigation.NavigateTo("/");
        }


        if (!string.IsNullOrWhiteSpace(accessToken))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        var response = await base.SendAsync(request, cancellationToken);
        var reswss =await response.Content.ReadAsStringAsync();
        // after request
        return response;
    
    }
}
