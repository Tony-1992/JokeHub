using JokeHub.Mobile.ViewModels;

namespace JokeHub.Mobile.Pages.Settings.Categories;

public partial class CategoriesPage : ContentPage
{
	public CategoriesPage(CategoriesPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}