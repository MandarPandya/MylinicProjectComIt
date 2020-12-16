using System;
using System.Collections.Generic;
using MyClinicProject.Models;

namespace MyClinicProject.Storage
{
    public interface IStorePatient
    {
        void Create(Patient newPatient);

        List<Patient> GetByName (String FirstName, String LastName);

        List<Patient> GetAll();

        public Patient GetById(Guid id);

        void Update(Patient patientToUpdate);

        public void UpdateMoreInfo(Patient patientToUpdate);

        void Delete(Guid id);
    }
    
}