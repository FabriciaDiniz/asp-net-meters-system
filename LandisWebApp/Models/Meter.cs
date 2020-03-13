using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LandisWebApp.Models
{
    [Table("Meters")]
    public class Meter
    {
        [Key]
        public long Id { get; set; }
        public string Cp { get; set; }
        public int IdCs { get; set; }
        public string TrafoId { get; set; }
    }
}
