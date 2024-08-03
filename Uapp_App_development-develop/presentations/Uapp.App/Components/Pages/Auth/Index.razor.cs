using Microsoft.AspNetCore.Components;
using Uapp.Shared.Core.Services.auth;

namespace Uapp.App.Components.Pages.Auth
{
    public partial class Index
    {
        [Inject] ITokenStorageService tokenStorageService { get; set; }
    }
}
