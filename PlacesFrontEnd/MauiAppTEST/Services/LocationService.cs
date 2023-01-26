using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Devices.Sensors;

namespace MauiAppTEST.Services
{
    public class LocationService
    {
        //Get current location if possible, else get last known location.
        //Throw error 
        public async Task showLocationError()
        {
            await Shell.Current.DisplayAlert("Location error", "Couldn't retrieve location data", "cancel");
        }

        public async Task<(double?, double)> GetLocation()
        {
            try
            {
                Location location = await Geolocation.GetLocationAsync();
                if (location != null)
                {
                    return (location.Altitude, location.Latitude);
                } else
                {
                    location = await Geolocation.GetLastKnownLocationAsync();
                    if (location != null)
                    {
                        return (location.Altitude, location.Latitude);
                    }
                    else
                    {
                        await showLocationError();
                        throw new Exception();
                    }
                        
                }
            }
            catch (Exception)
            {
                await showLocationError();
                throw new Exception();
            }

        }

        public async Task<double> GetDistance(Location location, double lat, double lon, DistanceUnits units)
        {
            try
            {
                var distanceDifference = Location.CalculateDistance(location, lat, lon, units);

                if (distanceDifference < 1)
                {
                    return distanceDifference;
                } else
                {
                    await showLocationError();
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                await showLocationError();
                throw;
            }
        }
    }
}
