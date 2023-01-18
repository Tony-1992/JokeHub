using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JokeHub.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeHub.Mobile.ViewModels
{
    public partial class CategoriesPageViewModel : BaseViewModel
    {
        private readonly PreferenceService _preferenceService;
        private readonly ToastService _toastService;

        [ObservableProperty]
        private bool _showDarkJokes;
        [ObservableProperty]
        private bool _showYoMamaJokes;
        [ObservableProperty]
        private bool _showSexualJokes;


        public CategoriesPageViewModel(PreferenceService preferenceService, ToastService toastService)
        {
            Title = "Categories";
            _preferenceService = preferenceService;
            _toastService = toastService;
            SetSwitchs();
        }

        private void SetSwitchs()
        {
            ShowDarkJokes = _preferenceService.GetDarkJoke();
            ShowYoMamaJokes = _preferenceService.GetYoMamaJoke();
            ShowSexualJokes = _preferenceService.GetSexualJoke();
        }

        [RelayCommand]
        public async Task UpdatePreferences()
        {
            _preferenceService.SetDarkJoke(ShowDarkJokes);
            _preferenceService.SetYoMamaJoke(ShowYoMamaJokes);
            _preferenceService.SetSexualJoke(ShowSexualJokes);


            await _toastService.ShowToast("Joke categories updated");
            await Shell.Current.GoToAsync("../", true);
            return;
        }
    }
}
