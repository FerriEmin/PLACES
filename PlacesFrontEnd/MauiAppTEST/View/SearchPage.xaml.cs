using MauiAppTEST.ViewModel;
using MauiAppTEST.Models;

namespace MauiAppTEST.View;

public partial class SearchPage : ContentPage
{

	SearchViewModel svm;
	public SearchPage(SearchViewModel vm)
	{

		svm = vm;
		BindingContext = vm;	
		InitializeComponent();
	}

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
   {
		svm.Input = e.NewTextValue;
		svm.populatePredictions(e.NewTextValue);

		if (SearchBar.Text.Length > 0)
		{
			Suggestions.IsVisible = true;
		} else
		{
			Suggestions.IsVisible = false;
		}
    }

	private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		string current = (e.CurrentSelection.FirstOrDefault() as Prediction)?.place_id;
		svm.populateDetail(current);
		svm.Id = svm.Detail.result.address_components[0].long_name;
    }

    void BackButton_Clicked(System.Object sender, System.EventArgs e)
    {
		svm.Back();
    }
}