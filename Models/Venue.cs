using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asset.Models
{
    public class Venue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Venue_Id { get; set; }
        public string Venue_Name { get; set; }
        public double Size { get; set; }
        public string Location { get; set; }
        public double Cost { get; set; }
    }
}
