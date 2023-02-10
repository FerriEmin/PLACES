using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppTEST.Models;
using MauiAppTEST.Services;
using MauiAppTEST.View;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MauiAppTEST.ViewModel
{
    [QueryProperty(nameof(Country), nameof(Country))]
    public partial class ActivityViewModel : BaseViewModel
    {
        public static Review rev { get; set; }

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

        [RelayCommand]
        async Task GoToActivityDetailsPageAsync(Post post)
        {
            if (post is null)
                return;

            float rating = default;
            Review review = new Review();
            var postList = PostServices.GetPosts();


            foreach (var posts in postList)
            {
                if(post.Id == posts.Id)
                foreach (var reviews in posts.Reviews)
                {
                        review = reviews;
                        rev = review;
                    }
            }

            await Shell.Current.GoToAsync($"{nameof(ActivityDetailsPage)}?Rating={rating}", true, new Dictionary<string, object>
            {
                ["Post"] = post,
                ["Review"] = review,
            });
        }
    }
}