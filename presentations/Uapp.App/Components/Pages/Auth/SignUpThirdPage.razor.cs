using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uapp.Services.Auth;
using Uapp.Services.Auth.Models;
using Uapp.Services.Dropdowns;
using Uapp.Shared.Models.Common;

namespace Uapp.App.Components.Pages.Auth
{
    public partial class SignUpThirdPage
    {
        [Inject] RegistrationStepThree StepThree { get; set; }
        [Inject] IRegistrationService registrationService { get; set; }
        [Inject] NavigationManager navigation { get; set; }
        string ErrorMessage = string.Empty;
        bool IsLoading { get; set; } = false;
        private async Task SubmitRegistration()
        {
            var is_submitable = ValidatePassword();
            if (is_submitable)
            {
                IsLoading = true;
                var res = await registrationService.SubmitForm();
                IsLoading = false;
                if (res.IsSuccess)
                    navigation.NavigateTo("congratulation");
                else
                    ErrorMessage = res.Message;
            }
        }
        private bool ValidatePassword()
        {
            bool isValid = true;
            if (StepThree.Password != StepThree.ConfirmPassword)
            {
                ErrorMessage = "Password does not match";
                return false;
            }
            if (StepThree.Password.Length < 6)
            {
                ErrorMessage = "Password should be at least 6 characters";
                return false;
            }
            return isValid;
        }
    }
}
