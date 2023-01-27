using CommunityToolkit.Mvvm.ComponentModel;
using MauiAppTEST.Models;
using MauiAppTEST.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTEST.ViewModel
{
    [QueryProperty(nameof(Post), nameof(Post))]
    [QueryProperty(nameof(Review), nameof(Review))]
    //[QueryProperty(nameof(Rating), nameof(Rating))]
    public partial class ActivityDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        Post post;

        [ObservableProperty]
        Review review;


        [ObservableProperty]
        float rating;

        public ActivityDetailsViewModel()
        {
            
        }
 
    }
}
