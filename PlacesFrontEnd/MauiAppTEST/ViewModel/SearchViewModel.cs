using MauiAppTEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiAppTEST.ViewModel
{
    public partial class SearchViewModel : BaseViewModel
    {

        [ObservableProperty]
        string responseBody;

        //public async Task<string> search()
        //{

        //    //string url = "https://maps.googleapis.com/maps/api/place/findplacefromtext/json";

        //    //string fields = "?fields=formatted_address%2Cname%2Crating%2Copening_hours%2Cgeometry";

        //    //string input = "&input=mongolian";

        //    //string inputType = "&inputtype=textquery";

        //    //string locationBias = " &locationbias=circle%3A2000%4047.6918452%2C-122.2226413";

        //    //string API_KEY = "AIzaSyAY85IYZfPLkT6EyiauSREDkc7ZhYJCPys";

        //    //string apa = "https://maps.googleapis.com/maps/api/place/findplacefromtext/json?fields=formatted_address%2Cname%2Crating%2Copening_hours%2Cgeometry&input=mongolian&inputtype=textquery&locationbias=circle%3A2000%4047.6918452%2C-122.2226413&key=AIzaSyAY85IYZfPLkT6EyiauSREDkc7ZhYJCPys";

        //    //HttpClient client = new HttpClient();
        //    ////var result = await client.GetAsync(url + fields + input + inputType + locationBias + API_KEY);
        //    //var result = await client.GetAsync(url);
        //    //string responseBody = await result.Content.ReadAsStringAsync();
        //    //return responseBody;
        //}

        public SearchViewModel()
        {
            //ResponseBody = search().Result;
        }    
    }
}
