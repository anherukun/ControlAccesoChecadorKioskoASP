using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControlAccesoChecadorKioskoASP.Models
{
    public class AccessToken
    {
        [Key]
        public string AccessTokenId { get; set; }
        [Required]
        public int EmployeId { get; set; }
        [ForeignKey("EmployeId")]
        public Employe Employe { get; set; }
        public long CreationDate { get; set; }
    }
}