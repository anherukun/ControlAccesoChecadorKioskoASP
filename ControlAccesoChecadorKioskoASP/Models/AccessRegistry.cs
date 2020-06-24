using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControlAccesoChecadorKioskoASP.Models
{
    public class AccessRegistry
    {
        public int AccessRegistryId { get; set; }
        [Required]
        public Employe Employe { get; set; }
        [Required]
        public Department Department { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public long IngressTicks { get; set; }
        public long EgressTicks { get; set; }
    }
}