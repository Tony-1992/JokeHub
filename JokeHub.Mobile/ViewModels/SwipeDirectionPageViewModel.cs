using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JokeHub.Mobile.Models;
using JokeHub.Mobile.Services;

namespace JokeHub.Mobile.ViewModels
{
    public partial class SwipeDirectionPageViewModel : BaseViewModel
    {
        private readonly PreferenceService _preferenceService;
        private readonly ToastService _toastService;

        [ObservableProperty]
        private IList<SwipeListItem> _swipeDirections;
        [ObservableProperty]
        private SwipeListItem _selectedSwipe;

        public SwipeDirectionPageViewModel(PreferenceService preferenceService, ToastService toastService)
        {
            _preferenceService = preferenceService;
            _toastService = toastService;

            Title = "Swipe direction";
            _swipeDirections = new List<SwipeListItem>()
            {
                new SwipeListItem()
                {
                    Direction = SwipeDirection.Down,
                    Text = "Swipe down"
                },
                new SwipeListItem()
                {
                    Direction = SwipeDirection.Up,
                    Text = "Swipe up"
                },
                new SwipeListItem()
                {
                    Direction = SwipeDirection.Left,
                    Text = "Swipe left"
                },
                new SwipeListItem()
                {
                    Direction = SwipeDirection.Right,
                    Text = "Swipe right"
                },
            };
        }

        [RelayCommand]
        async Task UpdateSwipeDirection()
        {
            if (_selectedSwipe is null)
            {
                await _toastService.ShowToast("Please choose a swipe direction!");
                return;
            }
            
            _preferenceService.SetSwipeDirection(_selectedSwipe);
            await _toastService.ShowToast("Swipe direction updated!");
            await Shell.Current.GoToAsync("../", true);
        }
    }
}
