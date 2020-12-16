using System;
using System.Collections.Generic;

namespace MyClinicProject.Models
{
    public class Patient
    {
        /*public Patient(string firstname, string lastname, DateTime birthdate, string gender) {

            Id = GetNewId();
            FirstName = firstname;
            LastName = lastname;
            Gender = gender;
            BirthDate = birthdate;

        } */


        public Guid Id { get; set; }
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

        

        public override string ToString()
        {
            string basicdetails = $"\n----Patient: {Id}----\n";
            basicdetails += $"First Name: {FirstName}\n";
            basicdetails += $"Last Name: {LastName}\n";
            basicdetails += $"Birth Date: {BirthDate.Day} / {BirthDate.Month} / {BirthDate.Year}\n";
            basicdetails += $"Gender: {Gender}\n";
            return basicdetails;
        }

        public static Guid GetNewId() {

        Guid g = Guid.NewGuid();
        
        return g;                     

        }


    }
}