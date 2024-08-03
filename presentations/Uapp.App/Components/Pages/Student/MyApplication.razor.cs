using Microsoft.AspNetCore.Components;
using Uapp.Services.Application.ApplicationList.ApplicationServices;
using Uapp.Services.Application.ApplicationList.Models;

namespace Uapp.App.Components.Pages.Student
{
    public partial class MyApplication
    {
        [Inject] IApplicationService applicationService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        public List<ApplicationListViewModel> Models = new List<ApplicationListViewModel>();

        //card colour
        private string GetCardClass(long statusId)
        {
            return statusId == 6 ? "bg-effbfa" : "bg-fcf3f3";
        }
        private string GetstausClass(long statusId)
        {
            return statusId == 6 ? "statusicon" : "statusicon-cancell";
        }
        protected override async Task OnInitializedAsync()
        {
            Models.Clear();
            var res = await applicationService.GetbyStudentAsync();
            Models.AddRange(res);
        }

        // Navigations
        private void NavigateToHome()
        {
            NavigationManager.NavigateTo("home");
        }
        private void NavigateToDetails(long applicationId)
        {
            NavigationManager.NavigateTo($"applicatiodetils/{applicationId}");
        }
    }
}
