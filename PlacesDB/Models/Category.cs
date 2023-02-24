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

        // Relations
        public virtual ICollection<Event>? Events { get; set; }
    }
}
