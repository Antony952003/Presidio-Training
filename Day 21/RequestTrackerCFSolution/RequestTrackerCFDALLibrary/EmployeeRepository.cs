using Microsoft.EntityFrameworkCore;
using RequestTrackerCFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerCFDALLibrary
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        readonly RequestTrackerContext _context;
        public EmployeeRepository(RequestTrackerContext context) { 
        _context = context;
        }
        public async Task<Employee> Add(Employee entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Employee> Delete(int key)
        {
            var employee = await Get(key);
            if (employee != null) {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return employee;
        }

        public async Task<Employee> Get(int key)
        {
            var employee  = _context.Employees.SingleOrDefault(e => e.Id == key);
            return employee;
        }

        public async Task<IList<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> Update(Employee entity)
        {
            var employee = await Get(entity.Id);
            if (employee != null)
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            }
            return employee;

        }
    }
}
