using Microsoft.AspNetCore.Components;
using Uapp.Services.Auth.Models;
using Uapp.Services.Dropdowns;
using Uapp.Shared.Models.Common;

namespace Uapp.App.Components.Pages.Auth
{
    public partial class SignUpSecondPart
    {
        [Inject] INameTitleService nameTitleService { get; set; }
        [Inject] NavigationManager Navigation { get; set; }
        [Inject] RegistrationStepTwo StepTwo { get; set; }

        List<EntitySelect> NameTitles { get; set; } = new List<EntitySelect>();
        bool IsLoading { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            NameTitles.Clear();
            var res = await nameTitleService.GetSelects();
            NameTitles.AddRange(res);
        }
        private void NavigateToThirdPage()
        {
            IsLoading = true;
            Navigation.NavigateTo("signupthirdpage", true);
        }
    }
}
