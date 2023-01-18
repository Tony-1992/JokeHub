using CommunityToolkit.Maui;
using JokeHub.Mobile.Pages;
using JokeHub.Mobile.Pages.Settings.Categories;
using JokeHub.Mobile.Pages.Settings.Direction;
using JokeHub.Mobile.Services;
using JokeHub.Mobile.ViewModels;
using Plugin.MauiMTAdmob;

namespace JokeHub.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiMTAdmob()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Nunito-ExtraLight.ttf", "NunitoExtraLight");
                    fonts.AddFont("Nunito-VariableFont_wght.ttf", "Nunito");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton(Connectivity.Current);

            // Register services
            builder.Services.AddScoped<JokesMobileAppService>();
            builder.Services.AddScoped<PreferenceService>();
            builder.Services.AddScoped<ToastService>();

            // Register pages & view models
            builder.Services.AddScoped<MainPage>();
            builder.Services.AddScoped<MainPageViewModel>();
            
            builder.Services.AddScoped<SettingsPage>();
            builder.Services.AddScoped<SettingsPageViewModel>();  
            builder.Services.AddScoped<SwipeDirectionPage>();
            builder.Services.AddScoped<SwipeDirectionPageViewModel>();  
            builder.Services.AddScoped<CategoriesPage>();
            builder.Services.AddScoped<CategoriesPageViewModel>(); 

           

            return builder.Build();
        }
    }
}