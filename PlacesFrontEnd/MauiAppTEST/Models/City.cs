using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTEST.TestData
{
    public class City
    {
        public City()
        {

        }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string Image { get; set; }
        public Activities Activities { get; set; } // gör class
        public double Latitude { get; set; }
        public double Longitude { get; set; }


    }
}
