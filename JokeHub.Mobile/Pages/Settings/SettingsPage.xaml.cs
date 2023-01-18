using JokeHub.Mobile.ViewModels;

namespace JokeHub.Mobile.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}