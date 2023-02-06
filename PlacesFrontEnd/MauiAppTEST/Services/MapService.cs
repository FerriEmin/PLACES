using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;

namespace MauiAppTEST.Services
{
    public class MapService
    {
        public async Task showMapError()
        {
            await Shell.Current.DisplayAlert("Map error", "Couldn't retrieve map", "Cancel");
        }

        public async Task NavigateToCurrentLocation(Location currentLocation, IMap m)
        {
            var location = currentLocation;
            var options = new MapLaunchOptions();

            try
            {
                await m.TryOpenAsync(location.Longitude,location.Latitude, options);
            }
            catch (Exception ex)
            {
                await showMapError();
                throw new Exception("Could not open map", ex);
            }
        }

        public async Task NavigateToLocation(double lat, double lon)
        {
            var location = new Location(lat, lon);
            var options = new MapLaunchOptions();

            try
            {
                await Map.Default.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                await showMapError();
                throw new Exception("Could not open map", ex);
            }
        }
    }
}
