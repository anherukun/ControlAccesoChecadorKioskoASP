using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControlAccesoChecadorKioskoASP.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}