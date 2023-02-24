using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesDB.Models
{
    // Event
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime? Created { get; set; } = DateTime.Now;
        public DateTime? Planned { get; set; }

        // Relations
        public virtual User? User { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Location? Location { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
    }
}
