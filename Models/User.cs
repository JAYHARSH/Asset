using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asset.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int User_Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string EmailAddress { get; set; }
        [ForeignKey("Venue_Id")]
        public int Venue_Id { get; set; }
        public List<Venue> Venue { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
