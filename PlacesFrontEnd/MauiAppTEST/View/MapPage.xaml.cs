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

    private void map_MapClicked(object sender, Microsoft.Maui.Controls.Maps.MapClickedEventArgs e)
    {
            
    }

    
}