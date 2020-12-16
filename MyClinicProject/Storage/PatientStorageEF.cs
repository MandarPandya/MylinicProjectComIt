using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using MyClinicProject.Models;

namespace MyClinicProject.Storage
{
    public class PatientStorageEF : IStorePatient
    {
        private ApplicationContext _context;
       
        public PatientStorageEF(ApplicationContext context) {
            _context = context;
        }

        public void Create(Patient newPatient) {
            var patientModel = ConvertToDb(newPatient);
            _context.Patients.Add(patientModel);
            _context.SaveChanges();
        }

        public void Update(Patient patientToUpdate) {
            var patientDb = ConvertToDb(patientToUpdate);
            _context.Patients.Update(patientDb);
            _context.SaveChanges();
            
        }

        public List<Patient> GetByName (String FirstName, String LastName) {
            return new List<Patient>();
        }

        public List<Patient> GetAll() {
            List<Patient> results = new List<Patient>();
            
            var patientsFromDb = _context.Patients.AsNoTracking().Where(x => x.IsDeleted == false).ToList();
            
            foreach (var patientFromDb in patientsFromDb) {
                var nextPatient = ConvertFromDb(patientFromDb);
                    results.Add(nextPatient);
                };
            return results;
        }

       public Patient GetById(Guid id) {
           var patientFromDb = _context.Patients.AsNoTracking().Where(x => x.IsDeleted == false).First(x => x.PatientId == id);
           var patient = ConvertFromDb(patientFromDb);
           return patient;
        }



        public void UpdateMoreInfo(Patient patientToUpdate) {
            var patientDb = ConvertToDb(patientToUpdate);
            _context.Patients.Update(patientDb);
            _context.SaveChanges();
        }

        private static Patient ConvertFromDb(EFModels.Patient patientFromDb) {
            return new Patient() {
                Id = patientFromDb.PatientId,
                FirstName = patientFromDb.FirstName,
                LastName = patientFromDb.LastName,
                Gender = patientFromDb.Gender,
                BirthDate = patientFromDb.BirthDate,
                BloodGroup = patientFromDb.BloodGroup,
                Allergies = patientFromDb.Allergies,
                Weight = patientFromDb.Weight,
                Height = patientFromDb.Height,
                LongTermMedication = patientFromDb.LongTermMedication,
                Address = patientFromDb.Address,
                Contact = patientFromDb.Contact,
                EmergencyContact = patientFromDb.EmergencyContact,
                Email = patientFromDb.Email,
            };
        
        }
        
        private static EFModels.Patient ConvertToDb(Patient patient) {
            return new EFModels.Patient() {
                PatientId = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Gender = patient.Gender,
                BirthDate = patient.BirthDate,
                BloodGroup = patient.BloodGroup,
                Allergies = patient.Allergies,
                Height = patient.Height,
                Weight = patient.Weight,
                LongTermMedication = patient.LongTermMedication,
                Address = patient.Address,
                Contact = patient.Contact,
                EmergencyContact = patient.EmergencyContact,
                Email = patient.Email,
            };
        }

        public void Delete(Guid id) {
            var patientFromDb = _context.Patients.AsNoTracking().First(x => x.PatientId == id);
            patientFromDb.IsDeleted = true;
            _context.Patients.Update(patientFromDb);
            _context.SaveChanges();
        }
    }
}