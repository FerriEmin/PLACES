using MauiAppTEST.ViewModel;

namespace MauiAppTEST.View;

public partial class SearchPage : ContentPage
{
	public SearchPage(SearchViewModel vm)
	{
		BindingContext = vm;	
		InitializeComponent();
	}
}