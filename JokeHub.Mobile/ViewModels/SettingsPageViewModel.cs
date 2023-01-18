using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JokeHub.Mobile.Pages.Settings.Categories;
using JokeHub.Mobile.Pages.Settings.Direction;

namespace JokeHub.Mobile.ViewModels
{
    public partial class SettingsPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _displayAppVersion;

        public SettingsPageViewModel()
        {
            Title = "Settings";
            DisplayAppVersion = AppInfo.VersionString;
        }



        [RelayCommand]
        public async Task TapSwipeDirection()
        {
            await Shell.Current.GoToAsync(nameof(SwipeDirectionPage), true);
        } 
        
        [RelayCommand]
        public async Task TapCategories()
        {
            await Shell.Current.GoToAsync(nameof(CategoriesPage), true);
        }

    }
}
