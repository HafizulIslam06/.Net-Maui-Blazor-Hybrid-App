using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Uapp.Services.Auth;
using Uapp.Shared.Core.Services.auth;
using Uapp.Shared.Constants;

namespace Uapp.App.Components.Pages.Auth
{
    public partial class SignInSuccess
    {
        [Inject] public IAuthService _authService { get; set; }
        [Inject] public ITokenStorageService _storageService { get; set; }
        [Inject] public AuthenticationStateProvider _authenticationStateProvider { get; set; }
        [Inject] public NavigationManager _navigationManager { get; set; }

        string Token = string.Empty;
        protected override async Task OnInitializedAsync()
        {
            Token=await _storageService.GetAccessToken();
            var user = await _authService.GetCurrentUserAsync();
            if (user != null)
            {
                if (user.UserTypeId != UserTypeConstant.Student)
                {
                    _storageService.RemoveTokens();
                    var authProvider = (UappAuthStateProvider)_authenticationStateProvider;
                    authProvider.LogoutAuthenticationState();
                }
                else
                {
                    _navigationManager.NavigateTo("signin");
                }
            }
        }
    }
}
