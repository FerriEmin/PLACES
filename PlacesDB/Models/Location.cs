﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesDB.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        // Relations
        public virtual Country? Country { get; set; }
        public virtual City? City { get; set; }
        public virtual ICollection<Event>? Events { get; set; }




    }
}
