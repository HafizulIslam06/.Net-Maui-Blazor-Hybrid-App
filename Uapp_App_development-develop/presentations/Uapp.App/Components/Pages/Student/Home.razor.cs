using Microsoft.AspNetCore.Components;
using Uapp.Shared.Responses;

namespace Uapp.App.Components.Pages.Student
{
    public partial class Home
    {
        private bool isOptionsVisible;
        private bool isSearchOptionVisible;
        private string transitionClass = "";
        private string overlayClass = "";
        private string Token = "";
        public LoginResponse UserInfo = new();
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;

        // Navigations
        private void NavigateBackToIndex()
        {
            NavigationManager.NavigateTo("/");
        }
        private void NavigateToNotifications()
        {
            NavigationManager.NavigateTo("/notifications");
        }
        private void NavigateToProfile(long id)
        {
            NavigationManager.NavigateTo($"profile/{id}");
        }
        private void NavigateToReferFriend()
        {
            NavigationManager.NavigateTo("/referfriend");
        }
        private void NavigateToChatDashboard()
        {
            NavigationManager.NavigateTo("/chatdashboard");
        }
        private void NavigateToMyApplication()
        {
            NavigationManager.NavigateTo("/applications");
        }
        private void NavigateToSearchAndApply()
        {
            NavigationManager.NavigateTo("/search&apply");
        }

        // Sliding Option
        private void ShowOptions()
        {
            transitionClass = "slide-in-left";
            isOptionsVisible = true;
            overlayClass = "show";
            StateHasChanged();
        }
        private void HideOptions()
        {
            transitionClass = "slide-out-left";
            StateHasChanged();
            Task.Delay(500); // Match the animation duration
            isOptionsVisible = false;
            overlayClass = "";
            StateHasChanged();
        }

        private void ShowSearchOptions()
        {
            transitionClass = "slide-in-right";
            isSearchOptionVisible = true;
            overlayClass = "show";
            StateHasChanged();
        }
        private async Task HideSearchOptions()
        {
            transitionClass = "slide-out-right";
            StateHasChanged();
            await Task.Delay(500); // Match the animation duration
            isSearchOptionVisible = false;
            overlayClass = "";
            StateHasChanged();
        }
        protected override async Task OnInitializedAsync()
        {
            Token = await tokenservice.GetAccessToken();
            var res = await authService.GetCurrentUserAsync();
            if (res != null)
                UserInfo = res;
        }
        private async Task BeginLogout()
        {
            await authService.LogoutAsync(true);
        }
    }
}
