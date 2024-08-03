using Microsoft.AspNetCore.Components;
using Uapp.Services.Application.ApplicationList.ApplicationServices;
using Uapp.Services.Application.Models;
using Uapp.Services.Funding.Model;
using Uapp.Services.Funding;
using Uapp.Services.StudentProfile.Models;
using Uapp.Services.StudentProfile;
using Uapp.Shared.Constants;

namespace Uapp.App.Components.Pages.Student
{
    public partial class Profile
    {
        [Parameter]
        public long id { get; set; }
        private bool isPersonalInformationVisible;
        private bool isContactInformationVisible;
        private string transitionClass = "";
        private string overlayClass = "";
        private string preferredCountry = "";
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] IStudentProfileService studentProfileService { get; set; }
        [Inject] IFundingService fundingService { get; set; }
        [Inject] IApplicationService applicationService { get; set; }
        bool IsLoaderProfileInfo = true;
        bool IsLoaderApplication = true;
        bool IsLoaderFund = true;
        bool IsLoaderDoc = true;

        private string ProfileImageUrl => ApiConstants.ApiRoot + studentProfile.ProfileImage?.FileUrl ?? "/assets/images/icons/icon-profile.svg";

        private StudentProfileViewModel studentProfile = new StudentProfileViewModel();
        private ApplicationOverviewViewModel applicationOverviewViewModel = new ApplicationOverviewViewModel();
        private FundingModel fundingModel = new FundingModel();
        private List<ApplicationDocumentViewModel> profileDocumentModel { get; set; } = new List<ApplicationDocumentViewModel>();

        protected override async Task OnInitializedAsync()
        {
            studentProfile = await studentProfileService.GetStudentProfileAsync(id);
            IsLoaderProfileInfo = false;
            StateHasChanged(); // Force UI update

            applicationOverviewViewModel = await applicationService.GeApplicationOverview(id);        
            IsLoaderApplication = false;
            StateHasChanged(); // Force UI update

            fundingModel = await fundingService.GetByStudentId(id);              
            IsLoaderFund = false;
            StateHasChanged(); // Force UI update

            profileDocumentModel.Clear();
            var profileDocument = await studentProfileService.GeProfileDocument(id);
            profileDocumentModel.AddRange(profileDocument);   
            IsLoaderDoc = false;
            StateHasChanged(); // Force UI update

        }

        // Navigations
        private void NavigateToHome()
        {
            NavigationManager.NavigateTo("home");
        }

        //// Show Personal Information Options
        //private void ShowPersonalInformationOptions()
        //{
        //    isPersonalInformationVisible = true;
        //    transitionClass = "slide-in-up";
        //    overlayClass = "show";
        //    StateHasChanged();
        //}

        //private async Task HidePersonalInformationOptions()
        //{
        //    transitionClass = "slide-out-down";
        //    StateHasChanged();
        //    await Task.Delay(500); // Ensure the animation completes
        //    isPersonalInformationVisible = false;
        //    overlayClass = "";
        //    StateHasChanged();
        //}

        //// Show Contact Options
        //private void ShowContactlInformation()
        //{
        //    isContactInformationVisible = true;
        //    transitionClass = "slide-in-up";
        //    overlayClass = "show";
        //    StateHasChanged();
        //}

        //private async Task HideContactInformation()
        //{
        //    transitionClass = "slide-out-down";
        //    StateHasChanged();
        //    await Task.Delay(500); // Ensure the animation completes
        //    isContactInformationVisible = false;
        //    overlayClass = "";
        //    StateHasChanged();
        //}       
    }
}
