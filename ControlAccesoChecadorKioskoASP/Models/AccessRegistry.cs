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
        [Key]
        public int AccessRegistryId { get; set; }
        [Required]
        public int EmployeId { get; set; }
        [ForeignKey("EmployeId")]
        public Employe Employe { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public long IngressTicks { get; set; }
        public long EgressTicks { get; set; }
    }
}