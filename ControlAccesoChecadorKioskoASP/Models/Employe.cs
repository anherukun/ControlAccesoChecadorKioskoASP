﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControlAccesoChecadorKioskoASP.Models
{
    public class Employe
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}