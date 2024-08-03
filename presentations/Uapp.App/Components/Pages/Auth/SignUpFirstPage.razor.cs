using Microsoft.AspNetCore.Components;
using Uapp.Services.Dropdowns;
using Uapp.Shared.Models.Common;

using Uapp.Services.Auth.Models;
namespace Uapp.App.Components.Pages.Auth
{
    public partial class SignUpFirstPage
    {
        [Inject] IUniversityCountryService UniversityCountryService { get; set; }

        [Inject] NavigationManager Navigation { get; set; }
        [Inject] RegistrationStepOne StepOne { get; set; }

        List<EntitySelect> preferedCountries { get; set; } = new List<EntitySelect>();
        bool IsLoading { get; set; } = false;
        bool DataLoading { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {            
            var so = StepOne;
            preferedCountries.Clear();
            DataLoading = true;
            var res = await UniversityCountryService.GetSelects();            
            preferedCountries.AddRange(res);
            DataLoading = false;
        }

        private int selectedDestination;

        private void SelectDestination(int destination)
        {
            selectedDestination = destination;
            StepOne.PreferedCountry = destination;
        }

        private string GetButtonClass(int destination)
        {
            return StepOne.PreferedCountry == destination ? "btn-key-checked btn-checked-primary active" : "btn-key-checked btn-checked-primary";
        }

        private void NavigateToSecondPage()
        {
            IsLoading = true;
            Navigation.NavigateTo("signupsecondpage", true);
            IsLoading = false;
        }
    }
}
