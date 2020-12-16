using Microsoft.EntityFrameworkCore;
using MyClinicProject.Storage.EFModels;

namespace MyClinicProject.Storage
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            
        }
        public DbSet<Patient> Patients { get; set; }
    }
}