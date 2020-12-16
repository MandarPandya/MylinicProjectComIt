using System;
using System.ComponentModel.DataAnnotations;

namespace MyClinicMvc.Models
{
    public class PatientViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(10)]
        public string LastName { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }
        
        [Required]
        [StringLength(6)]
        public string Gender { get; set; }

         public string BloodGroup { get;  set; }
        public string Allergies { get;  set; }
        public double Height { get;  set; }
        public double Weight { get;  set; }
        public string LongTermMedication { get;  set; }
        public string Address { get;  set; }
        public string Contact { get;  set; }
        public string EmergencyContact { get;  set; }
        public string Email { get;  set; }

    }
}
