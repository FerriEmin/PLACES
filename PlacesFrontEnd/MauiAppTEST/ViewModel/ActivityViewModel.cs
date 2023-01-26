using MauiAppTEST.TestData;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MauiAppTEST.ViewModel
{
    public partial class ActivityViewModel : BaseViewModel
    {
        public ObservableCollection<Post> Activities { get; } = new();

        public ActivityViewModel()
        {
            GetActivitiesAsync();
        }
        void GetActivitiesAsync()
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

                List<Post> activities = new List<Post>()
                {
                new Post(){ Name="Activity1"},
                new Post(){ Name="Activity2"},
                new Post(){ Name="Activity3"},
                new Post(){ Name="Activity4"},
                 };

                foreach (var activity in activities)
                    Activities.Add(activity);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                //await Shell.Current.DisplayAlert("Error!", $"unable to get monkeys: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }


        }
    }
}