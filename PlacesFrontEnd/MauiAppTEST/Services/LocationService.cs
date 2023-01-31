using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Devices.Sensors;

namespace MauiAppTEST.Services
{
    //Add this to ANDROID
    //Add the assembly-based permission:
    //Open the Platforms/Android/MainApplication.cs file and add the following assembly attributes after using directives:

    //[assembly: UsesPermission(Android.Manifest.Permission.AccessCoarseLocation)]
    //[assembly: UsesPermission(Android.Manifest.Permission.AccessFineLocation)]
    //[assembly: UsesFeature("android.hardware.location", Required = false)]
    //[assembly: UsesFeature("android.hardware.location.gps", Required = false)]
    //[assembly: UsesFeature("android.hardware.location.network", Required = false)]
    public class LocationService
    {
       
        public async Task showLocationError()
        {
            await Shell.Current.DisplayAlert("Location error", "Couldn't retrieve location data", "Cancel");
        }

        public async Task<Location> GetCachedLocation()
        {
            try
            {
                Location location = await Geolocation.Default.GetLastKnownLocationAsync();

                if (location != null)
                    return location;
              
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            throw new Exception();



        }

        //Get current location if possible, else get last known location.
        //Throw error 
        public async Task<Location> GetLocation()
        {
            try
            {
                Location location = await Geolocation.GetLocationAsync();
                if (location != null) { 

                    System.Diagnostics.Debug.WriteLine($"MapClick: {location.Latitude}, {location.Longitude}");
                    return location;
                } else
                {
                    location = await Geolocation.GetLastKnownLocationAsync();
                    if (location != null)
                    {
                        System.Diagnostics.Debug.WriteLine($"MapClick: {location.Latitude}, {location.Longitude}");

                        return location;
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
