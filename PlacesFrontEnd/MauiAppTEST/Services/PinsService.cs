using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.Maui.Controls.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTEST.Services
{
    public class PinsService
    {
        LocationService locationService;
        int amtOfPins = 10;

        public ICollection<Pin> PinsList;

        public PinsService(LocationService ls) 
        {
            locationService = ls;
            PinsList = CreatePins().Result;
        }

        public async Task<ICollection<Pin>> CreatePins() 
        {
            List<Pin> tempPinsList = new List<Pin>();
            Location currentLocation = await locationService.GetCachedLocation();

            for (int i = 0; i < amtOfPins; i++)
            {
                Location newLocation = new Location(currentLocation.Latitude + 2 * i, currentLocation.Longitude - 2 * i);
                Pin pin = await CreatePin("apa", "apa", PinType.Place, newLocation);
                tempPinsList.Add(pin);
            }
            return tempPinsList;
        }

        public async Task<Pin> CreatePin(string label, string address, PinType type, Location location)
        {
            try
            {
                Pin newPin = new Pin
                {
                    Label = label,
                    Address = address,
                    Type = type,
                    Location = location
                };

                return newPin;
            }
            catch (Exception)
            {
                throw new Exception("Could not create pin");
            }
            
        }
    }
}
