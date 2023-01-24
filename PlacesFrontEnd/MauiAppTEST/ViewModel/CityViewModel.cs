using CommunityToolkit.Mvvm.Input;
using MauiAppTEST.Services;
using MauiAppTEST.TestData;
using MauiAppTEST.View;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace MauiAppTEST.ViewModel
{
    public partial class CityViewModel : BaseViewModel
    {

        CityServices cityService;
        public ObservableCollection<City> Cities { get; } = new();
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
            List<City> cities = CityServices.GetCities();

            foreach (var city in cities)
                Cities.Add(city);
        }

        [RelayCommand]
        async Task GoToActivityPageAsync(City city)
        {
            if (city is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ActivityPage)}", true, new Dictionary<string, object>
            {
            {"City", city }
            });
        }


        [RelayCommand]
        async Task GetCityAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                //var cities = cityService.GetCities();

                //if (cities.Count != 0)
                //    cities.Clear();

                //foreach (var city in cities)
                //    Cities.Add(city);

                List<City> cities = new List<City>()
                {
                new City(){ Name="Paris", Image = "paris.png"},
                new City(){ Name="Venice", Image = "venice.png"},
                new City(){ Name="Rome", Image = "rome.png"},
                new City(){ Name="Bangkok", Image = "bangkok.png" },
                new City(){ Name="Stockholm", Image = "stockholm.png" },
                new City(){ Name="New York", Image = "ny.png" },
                new City(){ Name="Tokyo", Image = "tokyo.png"},
                new City(){ Name="Los Angeles", Image = "la.png" },
                 };

                foreach (var city in cities)
                    Cities.Add(city);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"unable to get monkeys: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
