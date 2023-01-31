using CommunityToolkit.Mvvm.ComponentModel;
using MauiAppTEST.Models;
using MauiAppTEST.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTEST.ViewModel
{
    [QueryProperty(nameof(Post), nameof(Post))]
    [QueryProperty(nameof(Review), nameof(Review))]
    public partial class ActivityDetailsViewModel : BaseViewModel
    {
        public ObservableCollection<Post> Rating { get; } = new();

        [ObservableProperty]
        Post post;

        [ObservableProperty]
        Review review;

        public ActivityDetailsViewModel()
        {
        }
    }
}
