using CommunityToolkit.Mvvm.Input;
using MauiAppTEST.Services;
using MauiAppTEST.Models;
using MauiAppTEST.View;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace MauiAppTEST.ViewModel
{
    public partial class CityViewModel : BaseViewModel
    {

        CityServices cityService;
        public ObservableCollection<Country> Cities { get; } = new();
        public CityViewModel()
        {
            LoadCities();
            //Title = "Cities";
            //this.cityService = cityService;
        }

        //protected override void OnNavigatedTo(NavigatedToEventArgs args)
        //{
        //    base.OnNavigatedTo(args);
        //}

        public void LoadCities()
        {
            List<Country> cities = CityServices.GetCities();

            foreach (var city in cities)
                Cities.Add(city);
        }

        [RelayCommand]
        async Task GoToActivityPageAsync(Country city)
        {
            if (city is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ActivityPage)}", true, new Dictionary<string, object>
            {
            {"City", city }
            });
        }
    }
}
