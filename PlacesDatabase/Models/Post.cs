using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesDB.Models
{
    // Event
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public float? Rating { get; set; }
        public DateTime Created { get; set; }

        // BLOB column

        // Relations
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
