using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Uapp.Services.Auth;
using Uapp.Services.Auth.Models;
using Uapp.Shared.Core.Services.auth;

namespace Uapp.App.Components.Pages.Auth
{
    public partial class SignIn
    {
        [Inject] public IAuthService _authService { get; set; }
        [Inject] public ITokenStorageService _storageService { get; set; }
        [Inject] public IUserStorageService _userStorageService { get; set; }
        [Inject] public AuthenticationStateProvider _authenticationStateProvider { get; set; }
        [Inject] public NavigationManager _navigationManager { get; set; }

        public LoginModel loginModel = new LoginModel();

        private string ErrorMessage = string.Empty;
        bool IsLoading { get; set; } = false;

        public async Task Submit()
        {
            IsLoading = true;

            var res = await _authService.LoginAsync(loginModel);

            IsLoading = false;

            ErrorMessage = res;
        }
    }

}