using JokeHub.Mobile.Pages;
using JokeHub.Mobile.Pages.Settings.Categories;
using JokeHub.Mobile.Pages.Settings.Direction;

namespace JokeHub.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(SwipeDirectionPage), typeof(SwipeDirectionPage));
            Routing.RegisterRoute(nameof(CategoriesPage), typeof(CategoriesPage));
        }
    }
}