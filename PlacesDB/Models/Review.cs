using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesDB.Models
{
    public class Review
    {
        public int Id { get; set; }
        public float Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }

        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}
