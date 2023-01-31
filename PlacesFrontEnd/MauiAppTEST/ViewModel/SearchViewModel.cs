using MauiAppTEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MauiAppTEST.ViewModel
{
    public partial class SearchViewModel : BaseViewModel
    {
        [ObservableProperty]
        Root res;

        [ObservableProperty]
        List<Prediction> predictions = new List<Prediction>();

        [ObservableProperty]
        string input = "eiffel";
        
        [ObservableProperty]
        string apikey = "AIzaSyAY85IYZfPLkT6EyiauSREDkc7ZhYJCPys";

        [ObservableProperty]
        string responseBody;

        [ObservableProperty]
        double lon;

        [ObservableProperty]
        double lat;

        [ObservableProperty]
        string url;

        [ObservableProperty]
        string id;


        public void search()
        {
            Url = $"https://maps.googleapis.com/maps/api/place/autocomplete/json?input={Input}&key={Apikey}";
            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(Url).Result;
            var json = JsonConvert.DeserializeObject<Root>(response);

            Predictions = json.predictions;
        }

        public SearchViewModel()
        {
            Id = "Inget här";
            search();
        }    
    }
}
