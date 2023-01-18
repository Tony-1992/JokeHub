using JokeHub.Infrastructure.Services.Jokes;
using JokeHub.Infrastructure.Services.Jokes.Dto;
using System.Net.Http.Json;

namespace JokeHub.Mobile.Services
{
    public class JokesMobileAppService
    {
        private HttpClient _httpClient;
        private PreferenceService _preferenceService;
        
        public JokesMobileAppService(PreferenceService preferenceService)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://jokehubapi20220816232921.azurewebsites.net/api");
            _preferenceService = preferenceService;
        }


        public async Task<JokeDto> GetRandomJokeAsync()
        {
            var filters = _preferenceService.GetFilters();

            var url = $"{_httpClient.BaseAddress}/joke/GetRandomJoke";

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, filters);

            if (response.IsSuccessStatusCode)
            {
                JokeDto jokeDto = await response.Content.ReadFromJsonAsync<JokeDto>();
                return jokeDto;
            }

            await Shell.Current.DisplayAlert("Oops", "Something went wrong on the server! Exit and try again later", "Ok");
            
            // Handle server failure by showing message to user.
            throw new NotImplementedException();
        }
    }
}
