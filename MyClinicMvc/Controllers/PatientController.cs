using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyClinicMvc.Models;

using MyClinicProject;
using MyClinicProject.Models;
using MyClinicProject.Storage;

namespace MyClinicMvc.Controllers
{
    public class PatientController : Controller
    {
        private MyClinicSystem _myclinic;
        public PatientController(MyClinicSystem myClinic)
        {
            _myclinic = myClinic;
        }

        public IActionResult Index()
        {
            List<Patient> patients = _myclinic.GetAllPatient();
            return View(patients);
        }

        public IActionResult Details(Guid id) {
            var patient = _myclinic.GetPatient(id);
            return View(patient);
        }

        public IActionResult Edit(Guid id) {
            var patient = _myclinic.GetPatient(id);

            // Build view model

            var PatientViewModel = new PatientViewModel() {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                BirthDate = patient.BirthDate,
                Gender = patient.Gender,

            };

            // send the view model
            ViewBag.IsEditing = true;
            return View("Form", PatientViewModel);
        }
        public IActionResult Form() {
            var patientToCreate = new PatientViewModel(){
                Id = Patient.GetNewId()
            };
            ViewBag.IsEditing = false;
            return View(patientToCreate);
        }
        [HttpPost]
        public IActionResult Create(PatientViewModel newPatient) {

            if (ModelState.IsValid) {

                var patientToCreate = new Patient() {
                FirstName = newPatient.FirstName,
                LastName = newPatient.LastName,
                BirthDate = newPatient.BirthDate,
                Gender = newPatient.Gender,
                Id = newPatient.Id,

                };
            
                _myclinic.AddNewPatient(patientToCreate);
                return RedirectToAction("Index");
            } else {
                return View("Form", newPatient);
            }
        }

        [HttpPost]

        public IActionResult Update(PatientViewModel updatePatient) {
            if(ModelState.IsValid) {

                var existingPatientInfo= _myclinic.GetPatient(updatePatient.Id);    

                var patient = new Patient() {
                    Id = updatePatient.Id,
                    FirstName = updatePatient.FirstName,
                    LastName = updatePatient.LastName,
                    BirthDate = updatePatient.BirthDate,
                    Gender = updatePatient.Gender,
                    BloodGroup = existingPatientInfo.BloodGroup,
                    Allergies = existingPatientInfo.Allergies,
                    Height = existingPatientInfo.Height,
                    Weight = existingPatientInfo.Weight,
                    LongTermMedication = existingPatientInfo.LongTermMedication,
                    Address = existingPatientInfo.Address,
                    Contact = existingPatientInfo.Contact,
                    EmergencyContact = existingPatientInfo.EmergencyContact,
                    Email = existingPatientInfo.Email
                };
                _myclinic.UpdatePatient(patient);
                return RedirectToAction("Details", new {
                    id = updatePatient.Id
                });
            } else {
                ViewBag.IsEditing = true;
                return View("Form", updatePatient);
            }
        }

        public IActionResult MoreInfoForm(Guid id) {
           
            ViewBag.IsEditing = true;
           
            var patient = _myclinic.GetPatient(id);

            // Build view model

            var MoreInfoViewModelObj = new MoreInfoViewModel() {                                                        
                    BloodGroup = patient.BloodGroup,
                    Allergies = patient.Allergies,
                    Height = patient.Height,
                    Weight = patient.Weight,
                    LongTermMedication = patient.LongTermMedication,
                    Address = patient.Address,
                    Contact = patient.Contact,
                    EmergencyContact = patient.EmergencyContact,
                    Email = patient.Email
            };

            return View(MoreInfoViewModelObj);
        }

         [HttpPost]
         public IActionResult Delete(Guid id) {
             _myclinic.DeletePatientById(id);
             return RedirectToAction("Index");
         }

        //

        [HttpPost]
        public IActionResult UpdateMoreInfo(MoreInfoViewModel moreinfoToUpdate) {
            
            if(ModelState.IsValid) {

               var existingPatientInfo= _myclinic.GetPatient(moreinfoToUpdate.Id);    


                var patient = new Patient() {
                    Id = moreinfoToUpdate.Id,
                    FirstName=existingPatientInfo.FirstName,
                    LastName=existingPatientInfo.LastName,
                    Gender=existingPatientInfo.Gender,
                    BirthDate=existingPatientInfo.BirthDate,                    
                    BloodGroup = moreinfoToUpdate.BloodGroup,
                    Allergies = moreinfoToUpdate.Allergies,
                    Height = moreinfoToUpdate.Height,
                    Weight = moreinfoToUpdate.Weight,
                    LongTermMedication = moreinfoToUpdate.LongTermMedication,
                    Address = moreinfoToUpdate.Address,
                    Contact = moreinfoToUpdate.Contact,
                    EmergencyContact = moreinfoToUpdate.EmergencyContact,
                    Email = moreinfoToUpdate.Email

                    
                };
                
                _myclinic.UpdateMoreInfo(patient);
                return RedirectToAction("Details", new {
                    id = moreinfoToUpdate.Id
                });
            } else {
               ViewBag.IsEditing = true;
                return View("MoreInfoForm", moreinfoToUpdate);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
