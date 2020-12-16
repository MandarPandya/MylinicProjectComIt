using System;
using System.Collections.Generic;
using System.Linq;

using MyClinicProject.Models;
using MyClinicProject.Storage;

namespace MyClinicProject
{
    public class MyClinicSystem
    {
        public MyClinicSystem(IStorePatient patientStorage){
            _patientStorage = patientStorage;
        
        }
        // Storage
        private readonly IStorePatient _patientStorage;
       
        // Methods

        public List<Patient> SearchForPatient(string FNToSearch, String LNToSearch) {
            return _patientStorage.GetByName(FNToSearch, LNToSearch);
        }

        public List<Patient> GetAllPatient() {
            return _patientStorage.GetAll();
        }

        public Patient GetPatient(Guid id) {
            return _patientStorage.GetById(id);
        }

        public void UpdatePatient(Patient patientToUpdate) {
            _patientStorage.Update(patientToUpdate);
        }
        public Patient AddNewPatient(Patient newPatient) {
            _patientStorage.Create(newPatient);
            return newPatient;

        }

        public void UpdateMoreInfo(Patient patientToUpdate) {
            _patientStorage.UpdateMoreInfo(patientToUpdate);
        }

        public void DeletePatientById(Guid id) {
            _patientStorage.Delete(id);
        }

    }
}