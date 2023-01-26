using MauiAppTEST.ViewModel;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using MauiAppTEST.TestData;
using MauiAppTEST.Services;
using DocumentFormat.OpenXml.Spreadsheet;

namespace MauiAppTEST.View;

public partial class AdminPage : ContentPage
{

    //List<City> _currentList = new List<City>();

    public AdminPage(AdminViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
        SetCityList(CityServices.GetCities());
        SetUserList(UserServices.GetUsers());
    }
 

    private void OnManageUsersButtonClicked(object sender, EventArgs e)
    {
        var animation = new Animation();

        if (!ManageUsersFrame.IsVisible)
        {
            ManageUsersFrame.IsVisible = true;
            animation = new((value) => { ManageUsersFrame.Opacity = value; }, 0, 1);
            animation = new((value) => { ManageUsersFrame.HeightRequest = value; }, 0, 300);
        }
        else
            ManageUsersFrame.IsVisible = false;

        //ManageUsersFrame.Animate("Opacity", animation, length: 200);
        ManageUsersFrame.Animate("HeightRequest", animation, length: 100);
    }

    private void OnManageActivitesClicked(object sender, EventArgs e)
    {
        var animation = new Animation();

        if (!ManageActivitiesFrame.IsVisible)
        {
            ManageActivitiesFrame.IsVisible = true;
            animation = new((value) => { ManageActivitiesFrame.Opacity = value; }, 0, 1);
            animation = new((value) => { ManageActivitiesFrame.HeightRequest = value; }, 0, 300);
        }
        else
            ManageActivitiesFrame.IsVisible = false;

        //ManageActivitiesFrame.Animate("Opacity", animation, length: 200);
        ManageActivitiesFrame.Animate("HeightRequest", animation, length: 100);
    }

    private void SetCityList(List<City> cities)
    {
        CityView.ItemsSource = cities;
        //NoResultCheck();
    }

    private void SetUserList(List<User> users)
    {
        UserView.ItemsSource = users;
        //NoResultCheck();
    }

    private void CitySearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Length == 0)
        {
            CityView.ItemsSource = CityServices.GetCities();
        }
        else
        {
            var result = CityServices.GetCities().Where(p => p.Name.ToLower().Contains(e.NewTextValue.ToLower())).ToList();
            SetCityList(result);
        }
    }

    private void UserSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Length == 0)
        {
            UserView.ItemsSource = UserServices.GetUsers();
        }
        else
        {
            var result = UserServices.GetUsers().Where(p => p.UserName.ToLower().Contains(e.NewTextValue.ToLower())).ToList();
            SetUserList(result);
        }
    }

    //async void UserView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    await Shell.Current.GoToAsync($"{nameof(ManageUsersPage)}", new Dictionary<string, object>
    //    {
    //        ["User"] = e.CurrentSelection
    //    });
    //}

    //private void NoResultCheck()
    //{
    //    if (_currentList.Count == 0)
    //    {
    //        mySearch.Text = "Din sökning gav inget resultat...";
    //    }
    //    else
    //    {
    //        mySearch.Text = string.Empty;
    //    }
    //}
}