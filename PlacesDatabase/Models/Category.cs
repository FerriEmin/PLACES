using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesDB.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgPath { get; set; }

        // Ta bort img path

        // Relations
        public virtual ICollection<Post> Posts { get; set; }
    }
}
