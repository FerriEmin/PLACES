using CommunityToolkit.Mvvm.Input;
using MauiAppTEST.Services;
using MauiAppTEST.TestData;
using MauiAppTEST.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTEST.ViewModel
{
    public partial class AdminViewModel : BaseViewModel
    {
        public ObservableCollection<City> Cities { get; } = new();
        public ObservableCollection<User> Users { get; } = new();

        public AdminViewModel()
        {
            LoadCities();
            LoadUsers();
        }
  
        public void LoadCities()
        {
            List<City> cities = CityServices.GetCities();

            foreach (var city in cities)
                Cities.Add(city);
        }

        public void LoadUsers()
        {
            List<User> users = UserServices.GetUsers();

            foreach (var user in users)
                Users.Add(user);
        }

        [RelayCommand]
        async Task GoToManageUsersPage(User user)
        {
            if (user is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(ManageUsersPage)}?ThisUsersCommentList={user.CommentList}", new Dictionary<string, object>
            {
                ["User"] = user
            });
           
        }
    }
}
