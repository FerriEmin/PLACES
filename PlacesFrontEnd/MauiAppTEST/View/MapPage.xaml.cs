using MauiAppTEST.ViewModel;
using Microsoft.Maui.Maps;

namespace MauiAppTEST.View;

public partial class MapPage : ContentPage
{
	MapViewModel mapViewModel;
	public MapPage(MapViewModel vm)
	{  
        mapViewModel = vm;
		BindingContext = vm;
		InitializeComponent();
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        map.MoveToRegion(mapViewModel.MapSpan);

        foreach (var item in mapViewModel.ps.PinsList)
        {
           if (item != null)
           {
               map.Pins.Add(item);
            }
        }
    }

    private void SearchButton_Clicked(object sender, EventArgs e)
    {
        mapViewModel.NavigateToSearchPage();
    }

    private void ActivityButton_Clicked(object sender, EventArgs e)
    {
        mapViewModel.NavigateToActivityPage();

    }

    private void AddActivityButton_Clicked(object sender, EventArgs e)
    {
        mapViewModel.NavigateToAddActivityPage();

    }


    private void map_MapClicked(object sender, Microsoft.Maui.Controls.Maps.MapClickedEventArgs e)
    {
        
    }

    private void ProfilePicture_Clicked(object sender, EventArgs e)
    {
        mapViewModel.NavigateToSettingsPage();

    }
}