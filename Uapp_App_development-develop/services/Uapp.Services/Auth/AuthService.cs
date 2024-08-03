using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Uapp.Services.Auth.Models;
using Uapp.Shared.Constants;
using Uapp.Shared.Core.Services.auth;
using Uapp.Shared.Http;
using Uapp.Shared.Models;
using Uapp.Shared.Responses;

namespace Uapp.Services.Auth;

public class AuthService : IAuthService
{
    private IHttpService _httpClientService;
    private readonly ITokenStorageService _storageService;
    private readonly IUserStorageService _userStorageService;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly NavigationManager _navigationManager;

    public AuthService(IHttpService httpClientService, ITokenStorageService storageService, IUserStorageService userStorageService, AuthenticationStateProvider authenticationStateProvider, NavigationManager navigationManager)
    {
        _httpClientService = httpClientService;
        _storageService = storageService;
        _authenticationStateProvider = authenticationStateProvider;
        _navigationManager = navigationManager;
        _userStorageService = userStorageService;
    }

    public async Task<string> LoginAsync(LoginModel model)
    {
        try
        {
            _storageService.RemoveTokens();
            string message = string.Empty;
            var res = await _httpClientService.Request<AuthResponse, LoginModel>().Post($"{ApiConstants.ApiRoot}{ApiConstants.Login}", model);
            if (res.IsSuccess)
            {
                await _storageService.SaveTokens(res.Message);

                await _authenticationStateProvider.GetAuthenticationStateAsync();

                var user = await GetCurrentUserAsync();
                if (user != null)
                {
                    if (user.UserTypeId != UserTypeConstant.Student)
                    {
                        await LogoutAsync(false);
                        message = "App is available only for student currently";
                    }
                    else
                    {
                        //await _userStorageService.SetUserAsync(user);
                        _navigationManager.NavigateTo("home");
                    }
                }
                else
                {
                    message = "You are not allowed to login";
                }
            }
            else
            {
                message = res.Message;
            }
            return message;

        }
        catch (Exception ex)
        {
            return ex.Message;
        }

    }

    public async Task<LoginResponse> GetCurrentUserAsync()
    {
        var user = await _userStorageService.GetUserAsync();
        if (user == null)
        {
            var res = await _httpClientService.Request<LoginResponse>().Get($"{ApiConstants.ApiRoot}{ApiConstants.GetUser}");
            await _userStorageService.SetUserAsync(res);
        }
        return user;
    }

    public async Task LogoutAsync(bool isredirect)
    {
        _storageService.RemoveTokens();
        _userStorageService.RemoveUser();
        var authProvider = (UappAuthStateProvider)_authenticationStateProvider;
        authProvider.LogoutAuthenticationState();
        if (isredirect)
            _navigationManager.NavigateTo("/");
    }
}
