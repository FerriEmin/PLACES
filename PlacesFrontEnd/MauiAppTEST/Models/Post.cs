using MauiAppTEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTEST.Models
{
    public class Post
    {
        public Post()
        {

        }
        public string ImgPath { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public Country Country { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}

