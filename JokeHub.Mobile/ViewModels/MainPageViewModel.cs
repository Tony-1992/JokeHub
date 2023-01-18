using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JokeHub.Infrastructure.Services.Jokes;
using JokeHub.Infrastructure.Services.Jokes.Dto;
using JokeHub.Mobile.Pages;
using JokeHub.Mobile.Services;

namespace JokeHub.Mobile.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        private readonly JokesMobileAppService _jokesAppService;
        private readonly PreferenceService _preferenceService;
        private readonly IConnectivity _connectivity;
        
        [ObservableProperty]
        private bool _isRefreshing;
        
        [ObservableProperty]
        private string _directionImage;

        [ObservableProperty]
        private SwipeDirection _prefSwipeDirection;

        [ObservableProperty]
        private JokeDto _joke;


        public MainPageViewModel(JokesMobileAppService jokesAppService, PreferenceService preferenceService, IConnectivity connectivity)
        {
            _jokesAppService = jokesAppService;
            _connectivity = connectivity;
            _preferenceService = preferenceService;

            // Subscribe to event
            _preferenceService.SwipeDirectionUpdated += UpdateSwipeDir;

            Title = "Jokes";
            SetPreferredSwipe();

            Joke = new JokeDto()
            {
                Setup = $"Swipe {_prefSwipeDirection.ToString()} to get new jokes"
            };

        }

        private void UpdateSwipeDir()
        {
            SetPreferredSwipe();
            Joke = new JokeDto()
            {
                Setup = $"Swipe {_prefSwipeDirection.ToString()} to get new jokes"
            };
        }


        private void SetPreferredSwipe()
        {
            var direction = _preferenceService.GetSwipeDirection();

            switch (direction)
            {
                case "Up":
                    PrefSwipeDirection = SwipeDirection.Up;
                    break;
                case "Down":
                    PrefSwipeDirection = SwipeDirection.Down;
                    break;
                case "Right":
                    PrefSwipeDirection = SwipeDirection.Right;
                    break;
                default:
                    PrefSwipeDirection = SwipeDirection.Left;
                    break;
            }
            DirectionImage = $"point_{direction}.svg";
        }



        [RelayCommand]
        async Task Refresh()
        {

            if (IsBusy)
                return;

            SetPreferredSwipe();
            
            if (HasInternet() is not true)
            {
                await Shell.Current.DisplayAlert("No internet connection!",
                    "An internet connection is required for this application to work.", "Ok");
                return;
            }


            IsBusy = true;
            ClearScreen();

            var jokeDto = await _jokesAppService.GetRandomJokeAsync();

            try
            {
                Joke = new JokeDto()
                {
                    Id = jokeDto.Id,
                    Setup = jokeDto.Setup,
                    PunchLine = jokeDto.PunchLine,
                    Category = jokeDto.Category,
                };
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        private bool HasInternet() => _connectivity.NetworkAccess == NetworkAccess.Internet ? true : false;
        
        private void ClearScreen()
        {
            Joke = new JokeDto()
            {
                Setup = string.Empty,
                PunchLine = string.Empty,
            };
        }
    }
}
