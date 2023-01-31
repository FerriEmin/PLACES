using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class SearchPage : ContentPage
{
	public SearchPage(SearchViewModel vm)
	{


		BindingContext = vm;	
		InitializeComponent();
	}

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
		if (SearchBar.Text.Length > 0)
		{
			Suggestions.IsVisible = true;
		} else
		{
			Suggestions.IsVisible = false;
		}
		
    }
}