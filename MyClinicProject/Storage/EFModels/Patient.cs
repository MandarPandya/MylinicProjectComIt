using System;

namespace MyClinicProject.Storage.EFModels
{
    public class Patient
    {
        public Guid PatientId { get; set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Gender { get;  set; }
        public DateTime BirthDate { get;  set; }
        public string BloodGroup { get;  set; }
        public string Allergies { get;  set; }
        public double Height { get;  set; }
        public double Weight { get;  set; }
        public string LongTermMedication { get;  set; }
        public string Address { get;  set; }
        public string Contact { get;  set; }
        public string EmergencyContact { get;  set; }
        public string Email { get;  set; }
        
        public bool IsDeleted { get; set; }
    }
}