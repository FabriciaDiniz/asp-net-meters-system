using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MetersWebApp.Models
{
    public class Meter
    {
        [Key]
        public long Id { get; set; }
        public string IdCp { get; set; }
        public string IdCs { get; set; }
        public string IdTrafo { get; set; }
    }
}
