using JokeHub.Mobile.ViewModels;

namespace JokeHub.Mobile.Pages.Settings.Direction;

public partial class SwipeDirectionPage : ContentPage
{
	public SwipeDirectionPage(SwipeDirectionPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}