using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Advisors
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage= "Name is required")]
        [MaxLength(255, ErrorMessage = "Name cannot be longer than 255 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage= "SIN is required")]
        [StringLength(9,MinimumLength =9,ErrorMessage = "SIN must be exactly 8 characters")]
        public string SIN { get; set; }

        [StringLength(255, ErrorMessage = "Address cannot be longer than 255 characters")]
        public string Address { get; set; }

        [StringLength(10,MinimumLength = 10, ErrorMessage = "Phone must be exactly 10 Digits")]
        public string Phone { get; set; }

      
        public HealthStatus HealthStatus { get; set; }
    }
    public enum HealthStatus
    {
        Green,
        Yellow,
        Red
    }
}
