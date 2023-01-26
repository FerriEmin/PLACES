using MauiAppTEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTEST.TestData
{
    public class Post
    {
        public Post()
        {

        }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public City city { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}

