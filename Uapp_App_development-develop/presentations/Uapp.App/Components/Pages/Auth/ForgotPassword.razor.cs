using Microsoft.AspNetCore.Components;
using Uapp.Services.Auth.Models;
using Uapp.Services.Auth;

namespace Uapp.App.Components.Pages.Auth
{
    public partial class ForgotPassword
    {
        private PasswordRecoveryModel passwordRecoveryModel = new PasswordRecoveryModel();
        [Inject] public IPasswordRecoveryService passwordRecoveryService { get; set; }
        string ErrorMessage = string.Empty;
        bool IsLoading { get; set; } = false;
        private async Task Submit()
        {
            IsLoading = true;
            var res = await passwordRecoveryService.SendPasswordRecoveryEmailAsync(passwordRecoveryModel.Email);
            IsLoading = false;
            if (!res.IsSuccess)
            {
                ErrorMessage = res.Message;
            }
        }
    }
}
