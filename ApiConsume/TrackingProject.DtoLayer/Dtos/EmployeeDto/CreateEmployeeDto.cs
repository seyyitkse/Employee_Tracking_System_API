using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingProject.DtoLayer.Dtos.EmployeeDto
{
    public class CreateEmployeeDto
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(5)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(5)]
        public string ConfirmPassword { get; set; }
    }
}
