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

        Double lat = 1;
        Double lon = 1;

        map.MoveToRegion(mapViewModel.MapSpan);

        foreach (var item in mapViewModel.ps.PinsList)
        {
           if (item != null)
           {
               map.Pins.Add(item);
            }
        }
    }
}