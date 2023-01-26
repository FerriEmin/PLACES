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
        [ObservableProperty]
        Country country;

        float rating;
        public ObservableCollection<Post> Activities { get; } = new();

        public ActivityViewModel()
        {
            ReviewServices.GetReviewList();
            UserServices.GetUsers();
            PostServices.LoadPosts();

        }

        void LoadAllPosts()
        {
            var Posts = PostServices.GetPosts();
            var Reviews = PostServices.GetPosts();

            Dictionary<int, List<Review>> ReviewDictionary = new Dictionary<int, List<Review>>();

            foreach (var key in ReviewDictionary.Keys)
            {
                foreach (var review in ReviewDictionary[key])
                {
                    if(review.Rating = 1)
                        
                }
            }
        }
    }
}