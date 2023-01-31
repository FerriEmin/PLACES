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
        List<StructuredFormatting> titles = new List<StructuredFormatting>();

        [ObservableProperty]
        string responseBody;

        public async Task<Root> search()
        {

            string url = "https://maps.googleapis.com/maps/api/place/findplacefromtext/json";

            string fields = "?fields=formatted_address%2Cname%2Crating%2Copening_hours%2Cgeometry";

            string input = "&input=mongolian";

            string inputType = "&inputtype=textquery";

            string locationBias = " &locationbias=circle%3A2000%4047.6918452%2C-122.2226413";

            string API_KEY = "AIzaSyAY85IYZfPLkT6EyiauSREDkc7ZhYJCPys";

            string apa = "https://maps.googleapis.com/maps/api/place/autocomplete/json?input=amoeba&location=37.76999%2C-122.44696&radius=500&types=establishment&key=AIzaSyAY85IYZfPLkT6EyiauSREDkc7ZhYJCPys";
            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(apa).Result;
            var json = JsonConvert.DeserializeObject<Root>(response);

            return json;
        }

        public SearchViewModel()
        {
            var temp = search().Result;
            temp.predictions.ForEach(x =>
            {
                var kkk = x.structured_formatting;
                Titles.Add(kkk);
            });
        }    
    }
}
