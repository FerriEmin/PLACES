using CommunityToolkit.Mvvm.ComponentModel;
using MauiAppTEST.Services;
using MauiAppTEST.View;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;


namespace MauiAppTEST.ViewModel
{
    public partial class MapViewModel : BaseViewModel
    {
        [ObservableProperty]
        Double lon;

        [ObservableProperty]
        Double lat;

        [ObservableProperty]
        Location location;

        [ObservableProperty]
        ICollection<Pin> pinsLis;  

        public MapSpan mapSpan;

        public MapViewModel(LocationService locationService, PinsService pinsService)
        {
            lon = locationService.GetCachedLocation().Result.Longitude;
            lat = locationService.GetCachedLocation().Result.Latitude;
            location = locationService.GetCachedLocation().Result;
            
            PinsLis = pinsService.PinsList;
            mapSpan = new MapSpan(location, lat, lon);
        }

    }
}
