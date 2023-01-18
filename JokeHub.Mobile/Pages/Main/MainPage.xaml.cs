using JokeHub.Mobile.ViewModels;

namespace JokeHub.Mobile.Pages;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}