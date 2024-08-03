using Microsoft.AspNetCore.Components;
using System.Reflection.Metadata;
using Uapp.Services.Application.ApplicationList.ApplicationServices;
using Uapp.Services.Application.Models;

namespace Uapp.App.Components.Pages.Student;

public partial class ApplicationDetails
{
    [Parameter]
    public int Id { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] public IApplicationService ApplicationService { get; set; }
    public ApplicationDetailsModel Models { get; set; } = new ApplicationDetailsModel();
    public List<ApplicationDocumentViewModel> DocumentModels { get; set; } = new List<ApplicationDocumentViewModel>();
    public ApplicationAssesmentViewModel ApplicationAssesmentModel { get; set; } = new ApplicationAssesmentViewModel();
    private int ProgressValue;
    private ElementReference circularProgress;
    private int currentValue = 0;
    private string upIcon = "fa-solid fa-angle-up";
    private string rightIcon = "fa-solid fa-angle-right";
    private string downIcon = "fa-solid fa-angle-down";
    //progress details icon 
    private string succes = "fa-solid fa-circle-check";
    private string pending = "fa-solid fa-circle-exclamation";
    private string reject = "fa-solid fa-circle-minus";

    //icon colour

    private string succescolour = "#47B881";
    private string pendingcolour = "#FFAD0D";
    private string rejectedcolour = "#F64C4C";

    private bool document;
    private string CurrentIcon { get; set; } = "fa-solid fa-angle-right";
    private string CurrentIcon2 { get; set; } = "fa-solid fa-angle-down";
    protected override async Task OnInitializedAsync()
    {
        Models = await ApplicationService.GeApplicationDetails(Id);
        ApplicationAssesmentModel = await ApplicationService.GeApplicationAssesmentbyApplication(Id);

        DocumentModels = await ApplicationService.GeApplicationDocument(Id);

        //progressbar
        ProgressValue = 0;
        if (ApplicationAssesmentModel.ApplicationDetails == 3) ProgressValue += 20;
        if (ApplicationAssesmentModel.Profile == 3) ProgressValue += 20;
        if (ApplicationAssesmentModel.Consent == 3) ProgressValue += 20;
        if (ApplicationAssesmentModel.Document == 3) ProgressValue += 20;
        if (ApplicationAssesmentModel.InternalAssesment == 3) ProgressValue += 20;
    }

    //Progessbar
    private string BackgroundColor
    {
        get
        {
            string color;
            if (currentValue < 20)
                color = "#F64C4C";
            else if (currentValue < 60)
                color = "#FFAD0D";
            else
                color = "#47B881";

            return $"{color} {currentValue * 3.6}deg, #ededed 0deg";
        }
    }

    protected override async Task OnParametersSetAsync()
    {
        await UpdateProgressAsync();
    }

    private async Task UpdateProgressAsync()
    {
        var steps = ProgressValue;  // Number of steps for the animation
        var increment = (double)ProgressValue / steps;
        var speed = 10;   // Delay time in milliseconds

        // Ensure currentValue starts from 0 for the animation
        currentValue = 0;

        while (currentValue < ProgressValue)
        {
            currentValue = (int)Math.Min(currentValue + increment, ProgressValue);
            await InvokeAsync(StateHasChanged);
            await Task.Delay(speed);
        }

        // Ensure the final state is exactly the ProgressValue
        currentValue = ProgressValue;
        await InvokeAsync(StateHasChanged);
    }
    private string GetAssetsmentIcon(long statusId)
    {
        return statusId == 3 ? succes : statusId == 1 ? pending : reject;
    }
    private string GetApplicationDetailsIconColour(long statusId)
    {
        return statusId == 3 ? succescolour : statusId == 1 ? pendingcolour : rejectedcolour;
    }
    //show document
    private void Document()
    {
        document = !document;
        CurrentIcon = document ? upIcon : rightIcon;
    }

    // Navigations
    private void NavigateToHome()
    {
        NavigationManager.NavigateTo("applications");
    }
    private bool isShowStatusDetail = false;

    private void ToggleStatusDetail()
    {
        isShowStatusDetail = !isShowStatusDetail;
        CurrentIcon2 = isShowStatusDetail ? upIcon : downIcon;
        StateHasChanged();
    }
}
