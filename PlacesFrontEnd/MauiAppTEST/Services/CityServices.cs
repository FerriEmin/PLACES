using MauiAppTEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTEST.Services
{

    //C:\src\.NET\PLACES2023\PLACES\PlacesFrontEnd\MauiAppTEST\Models\
    public class CityServices
    {
        public static List<Country> GetCities()
        {
            List<Country> cityList = new List<Country>()
            {
                new Country(){ Name="Paris" },
                new Country(){ Name="Venice" },
                new Country(){ Name="Rome" },
                new Country(){ Name="Bangkok" },
                new Country(){ Name="Stockholm" },
                new Country(){ Name="New York" },
                new Country(){ Name="Tokyo" },
                new Country(){ Name="Los Angeles" },
            };
            return cityList;
        }
    }
}
