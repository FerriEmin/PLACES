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
using MauiAppTEST.Services;
using System.Runtime.CompilerServices;

namespace MauiAppTEST.ViewModel
{
    public partial class SearchViewModel : BaseViewModel
    {
        
        GoogleApiService googleApiService;

        [ObservableProperty]
        PlacesSearchResult res;

        [ObservableProperty]
        List<Prediction> predictions = new List<Prediction>();

        [ObservableProperty]
        PlacesDetailsResult detail = null;

        [ObservableProperty]
        string input = "Eiffel";
         
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

        public void populatePredictions(string input)
        {
            Predictions = googleApiService.GetSearchPredictions(input).Result.predictions;
        }

        public void populateDetail(string placesId)
        {
            Detail = googleApiService.GetDetails(placesId).Result;
        }

        public SearchViewModel(GoogleApiService gas)
        {
            googleApiService = gas;
            Id = "Du har inte valt någonting";
            populatePredictions(Input);
        }
    }
}
