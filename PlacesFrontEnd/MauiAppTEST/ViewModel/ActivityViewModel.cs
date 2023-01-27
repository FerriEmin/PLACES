using CommunityToolkit.Mvvm.ComponentModel;
using MauiAppTEST.Models;
using MauiAppTEST.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MauiAppTEST.ViewModel
{
    [QueryProperty(nameof(Country), nameof(Country))]
    public partial class ActivityViewModel : BaseViewModel
    {
        [ObservableProperty] Country country;
        public ObservableCollection<Post> Activities { get; } = new();

        public ActivityViewModel()
        {
            LoadActivites();
        }

        void LoadActivites()
        {
            var posts = PostServices.GetPosts();

            foreach (var item in posts)
                Activities.Add(item);
        }
    }
}