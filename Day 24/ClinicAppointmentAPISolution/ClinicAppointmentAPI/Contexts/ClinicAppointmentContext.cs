using ClinicAppointmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentAPI.Contexts
{
    public class ClinicAppointmentContext : DbContext
    {
        public ClinicAppointmentContext(DbContextOptions<ClinicAppointmentContext> options) : base(options) {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 101, Name = "Mark Zuckerberg", Specialization = "ENT Specialist", Experience = 2.5},
                new Doctor() { Id = 102, Name = "Elon Musk" , Specialization = "Orthodotist", Experience = 1.5}
                );
        }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
