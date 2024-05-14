using ClinicAppointmentAPI.Contexts;
using ClinicAppointmentAPI.Interfaces;
using ClinicAppointmentAPI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentAPI.Repositories
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly ClinicAppointmentContext _context;
        public DoctorRepository(ClinicAppointmentContext context) { 
            _context = context;
        }
        public async Task<Doctor> Add(Doctor item)
        {
            if (_context.Doctors.Contains(item))
            {
                return null;
            }
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Doctor> Delete(int key)
        {
            var FoundDoctor = _context.Doctors.ToList().Find(x => x.Id == key);
            if (FoundDoctor != null)
            {
                _context.Doctors.Remove(FoundDoctor);
                await _context.SaveChangesAsync();
                return FoundDoctor;
            }
            return null;
        }

        public async Task<Doctor> Get(int key)
        {
            var FoundDoctor = _context.Doctors.ToList().FirstOrDefault(x => x.Id == key);
            if (FoundDoctor != null) { return FoundDoctor; }
            return null;
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            var result = await _context.Doctors.ToListAsync();
            return result;
        }

        public async Task<Doctor> Update(Doctor item)
        {
            var FoundDoctor = await Get(item.Id);
            if (FoundDoctor != null)
            {
                _context.Doctors.Update(FoundDoctor);
                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }
    }
}
