using MauiAppTEST.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTEST.Services
{
    public class GoogleApiService
    {

        string API_KEY = "AIzaSyAY85IYZfPLkT6EyiauSREDkc7ZhYJCPys";

        public async Task<PlacesSearchResult> GetSearchPredictions(string input)
        {

            string url = $"https://maps.googleapis.com/maps/api/place/autocomplete/json?input={input}&key={API_KEY}";
            HttpClient client = new HttpClient();
            string response = client.GetStringAsync(url).Result;
            var result = JsonConvert.DeserializeObject<PlacesSearchResult>(response);
            return result;
        }

        public async Task<PlacesDetailsResult> GetDetails(string placesId)
        {
            string url = $"https://maps.googleapis.com/maps/api/place/details/json?fields=address_components%2Cgeometry&place_id={placesId}&key={API_KEY}";
            HttpClient client = new HttpClient();
            string response = client.GetStringAsync(url).Result;
            PlacesDetailsResult Detail = JsonConvert.DeserializeObject<PlacesDetailsResult>(response);
            return Detail;
        }
    }
}
