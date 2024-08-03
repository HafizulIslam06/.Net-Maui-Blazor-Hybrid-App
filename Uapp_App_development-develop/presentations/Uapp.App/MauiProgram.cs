using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using Uapp.Services;
using Uapp.Shared;
using Uapp.Shared.Core.Services.auth;

namespace Uapp.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            builder.Services.AddTransient<AuthInterceptor>();

            builder.Services.AddSharedModule(builder.Configuration); //register shared module
            builder.Services.AddClientServices(); //register shared module
            builder.Services.AddHttpClient();

            builder.Services.AddHttpClient("ServerAPI")
                .AddPolicyHandler(HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))))
                .AddHttpMessageHandler<AuthInterceptor>();

            builder.Services.AddBlazoredToast();
            builder.Services.AddAuthorizationCore(); //custom add
            builder.Services.AddScoped<AuthenticationStateProvider, UappAuthStateProvider>(); //custom add


            builder.Services.AddPageState();
            builder.Services.AddMauiBlazorWebView();

            //builder.Services.AddTransient<IRegistrationService, RegistrationService>();
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();

            return builder.Build();
        }
    }
}
