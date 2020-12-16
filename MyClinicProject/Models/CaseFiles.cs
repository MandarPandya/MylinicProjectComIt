using System;
using System.Collections.Generic;

namespace MyClinicProject.Models
{
    public class CaseFiles
    {
        public CaseFiles() {

        }

        public DateTime OpeningDate { get; private set; }
        public string Symptoms { get; private set; }
        public string Diagnosis { get; private set; }
        public string MedicinesToPrescribe { get; private set; }
        public DateTime FollowUpDate { get; private set; }
        public bool IsReferredTo { get; private set; }
        public bool IsOpen { get; private set; }
    }
}