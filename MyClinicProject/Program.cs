using System;
using System.Collections.Generic;
using System.Linq;

using MyClinicProject.Models;
using MyClinicProject.Storage;

namespace MyClinicProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dependency Inection and Init
            var patientStorage = new PatientStorageList();
            var TheClinic = new MyClinicSystem(patientStorage);

            Console.WriteLine("Welcome Doctor");

            while (true) {
                Console.WriteLine("\n Please select an option\n" +
                "-S: Search for a patient\n" +
                "-L: List all patients\n" +
                "-A: Add a patient\n" +
                "-Q: Quit\n"
                );

                string userInput = Console.ReadLine();

                // Search For a Patient

                if (userInput == "S" || userInput == "s"){
                    try {
                        Console.WriteLine("What is the First Name of the Patient?");
                        string FNToSearch = Console.ReadLine();
                        Console.WriteLine("What is the Last Name of the Patient?");
                        string LNToSearch = Console.ReadLine();
                        List<Patient> results = TheClinic.SearchForPatient(FNToSearch, LNToSearch);

                        if (results.Count > 0) 
                            {
                                foreach (var Patient in results) {
                                    Console.WriteLine(Patient.ToString());
                                }
                                
                            }

                        } catch (Exception e) {
                            Console.WriteLine($"Error: {e.Message}");
                        }
                }

                // List All Patients

                if (userInput == "L" || userInput == "l") {
                    try{
                        List<Patient> results = TheClinic.GetAllPatient();
                        foreach (var Patient in results) {
                            Console.WriteLine(Patient.ToString());
                        }
                   
                    } catch (Exception e) {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                }

                if(userInput == "A" || userInput == "a") {
                    try{
                        //Console.WriteLine("Please Enter Id");
                        //string Id = Console.ReadLine();
                       
                        Console.WriteLine("Please Enter First Name");
                        string FirstName = Console.ReadLine();
                        Console.WriteLine("Please Enter Last Name");
                        string LastName = Console.ReadLine();
                        Console.WriteLine("Please Enter Birth Date (yyyy/mm/dd)");
                        string BirthDate_str = Console.ReadLine();
                        DateTime BirthDate = Convert.ToDateTime(BirthDate_str);
                        Console.WriteLine("Please Enter Gender");
                        string Gender = Console.ReadLine();

                       // TheClinic.AddNewPatient(new Patient(FirstName, LastName, BirthDate, Gender));
                        

                    }
                    catch(Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}"); 
                    }
                }
                // Quit
                if (userInput == "Q" || userInput == "q") {
                    break;
                }

            }
            
        }
    }
}
