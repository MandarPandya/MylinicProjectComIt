using System;
using System.ComponentModel.DataAnnotations;

namespace MyClinicMvc.Models
{
    public class MoreInfoViewModel
    {
        public Guid Id { get; set; }        


        public string BloodGroup { get;  set; }
        
        [Required]
        [StringLength(40)]
        public string Allergies { get;  set; }

        
        public double Height { get;  set; }
        public double Weight { get;  set; }
        
        [Required]
        [StringLength(40)]
        public string LongTermMedication { get;  set; }
        
        [Required]
        [StringLength(40)]
        public string Address { get;  set; }

        [Required]
        [StringLength(15)]
        public string Contact { get;  set; }
        
        [StringLength(25)]
        public string EmergencyContact { get;  set; }
        
        
        [StringLength(50)]
        public string Email { get;  set; }

    }
}
