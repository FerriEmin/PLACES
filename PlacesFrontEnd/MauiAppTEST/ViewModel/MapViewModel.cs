using CommunityToolkit.Mvvm.ComponentModel;
using MauiAppTEST.Services;
using MauiAppTEST.View;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;


namespace MauiAppTEST.ViewModel
{
    public partial class MapViewModel : BaseViewModel
    {

        LocationService locationService;
        public PinsService ps;

        [ObservableProperty]
        Double lon;

        [ObservableProperty]
        Double lat;

        [ObservableProperty]
        Location location;


        [ObservableProperty]
        public MapSpan mapSpan;

        public MapViewModel(LocationService ls, PinsService pinsService)
        {
            locationService = ls;
            ps = pinsService;

            var res = locationService.GetLocation().Result;

            Lon = res.Longitude;
            Lat = res.Latitude;
            Location location = res;            
            mapSpan = new MapSpan(location, Lon, Lat);
        }

    }
}
