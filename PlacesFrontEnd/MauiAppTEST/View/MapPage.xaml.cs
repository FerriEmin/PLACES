using MauiAppTEST.ViewModel;
using Microsoft.Maui.Maps;

namespace MauiAppTEST.View;

public partial class MapPage : ContentPage
{
	MapViewModel mapViewModel;
	public MapPage(MapViewModel vm)
	{
		BindingContext = vm;
		mapViewModel = vm;
		InitializeComponent();
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {

        base.OnNavigatedTo(args);

        Double lat = 1;
        Double lon = 1;
        MapSpan ms = new MapSpan(mapViewModel.Location, lat, lon);

		map.MoveToRegion(ms);

		//var PinsList = mapViewModel.PinsList;
		//foreach (var item in PinsList)
		//{
		//	if (item != null)
		//	{
  //              map.Pins.Add(item);
  //          }
		//}
    }
}