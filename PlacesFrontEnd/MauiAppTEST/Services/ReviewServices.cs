using MauiAppTEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTEST.Services
{
    public class ReviewServices
    {
        public static void GetReviewList()
        {

            List<Review> ReviewList = new List<Review>()
            {
                new Review(){ Rating=4, Comment="Blablabla" },
                new Review(){ Rating=2, Comment="Blablayyyyyybla" },
                new Review(){ Rating=3, Comment="Blablahhhyjbla" },
                new Review(){ Rating=5, Comment="Blablssdfrrrrabla" },
                new Review(){ Rating=3, Comment="Blablyhhhhabla" },
                new Review(){ Rating=1, Comment="Blablabdddddla" },
                new Review(){ Rating=2, Comment="Blablassdsadasdsabla" },
                new Review(){ Rating=3, Comment="Blabladdddbla" },
                new Review(){ Rating=5, Comment="Blabldddddddddddddabla" },
            };
        }
  
    }
}
