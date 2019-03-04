using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asset.Models.VenueViewModel
{
    public class VenueViewModel
    {
        public int Id { get; set; }
        public string Venue_Name { get; set; }
        public double Size { get; set; }
        public string Location { get; set; }
        public double Cost { get; set; }
    }
}
