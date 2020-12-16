using System;
using System.Collections.Generic;
using System.Linq;

using MyClinicProject.Models;

namespace MyClinicProject.Storage
{
    public class PatientStorageList : IStorePatient
    {
        private readonly List<Patient> _patientList;
       
        public PatientStorageList() {
            _patientList = new List<Patient>();
        }

        public void Create(Patient newPatient) {
            _patientList.Add(newPatient);
        }

        public void Update(Patient patientToUpdate) {
            var patient = GetById(patientToUpdate.Id);
            patient.FirstName = patientToUpdate.FirstName;
            patient.LastName = patientToUpdate.LastName;
            patient.BirthDate = patientToUpdate.BirthDate;
            patient.Gender = patientToUpdate.Gender;
        }

        public List<Patient> GetByName (String FirstName, String LastName) {
            var SearchResult = _patientList.Where(x => x.FirstName.ToLower() == FirstName.ToLower() || x.LastName.ToLower() == LastName.ToLower()).ToList();

            if (SearchResult.Count == 0) {
                throw new Exception($"Patient {FirstName} {LastName} does not exist");
            }

            return SearchResult;
        }

        public List<Patient> GetAll() {
            return _patientList;
        }

       public Patient GetById(Guid id) {

            var SearchResult = _patientList.Find(x => x.Id == id);

            if (SearchResult == null) {
                throw new Exception($"Patient {id} does not exist");
            }

            return SearchResult;

        }

        public void UpdateMoreInfo(Patient patientToUpdate) {
            var patient = GetById(patientToUpdate.Id);
            patient.BloodGroup = patientToUpdate.BloodGroup;
            patient.Allergies = patientToUpdate.Allergies;
            patient.Height = patientToUpdate.Height;
            patient.Weight = patientToUpdate.Weight;
            patient.LongTermMedication = patientToUpdate.LongTermMedication;
            patient.Address = patientToUpdate.Address;
            patient.Contact = patientToUpdate.Contact;
            patient.EmergencyContact = patientToUpdate.EmergencyContact;
            patient.Email = patientToUpdate.Email;
        }

        public void Delete(Guid id) {
            //todo
        }
    }
}