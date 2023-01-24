using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTEST.TestData
{
    public class CityServices
    {
        public static List<City> GetCities()
        {
            List<City> cityList = new List<City>()
            {
                new City(){ Name="Paris" },
                new City(){ Name="Venice" },
                new City(){ Name="Rome" },
                new City(){ Name="Bangkok" },
                new City(){ Name="Stockholm" },
                new City(){ Name="New York" },
                new City(){ Name="Tokyo" },
                new City(){ Name="Los Angeles" },
            };

            return cityList;
        }


    }
}
