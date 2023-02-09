using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesDB.Models
{
    public class Token
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public DateTime? Expires { get; set; }

        public User? User { get; set; }
    }
}
