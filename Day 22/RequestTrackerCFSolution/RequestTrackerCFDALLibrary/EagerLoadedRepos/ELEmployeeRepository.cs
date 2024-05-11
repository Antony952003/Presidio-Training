using Microsoft.EntityFrameworkCore;
using RequestTrackerCFDALLibrary.LazyLoadedRepos;
using RequestTrackerCFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerCFDALLibrary.EagerLoadedRepos
{
    public class ELEmployeeRepository : EmployeeRepository
    {
        public ELEmployeeRepository(RequestTrackerContext context) : base(context)
        {
        }
        public async override Task<IList<Employee>> GetAll()
        {
            return await _context.Employees
                .Include(x => x.SolutionsProvided)
                .Include(x => x.RequestsClosed)
                .Include(x => x.FeedbacksGiven)
                .Include(x => x.RequestsRaised)
                .ToListAsync();
        }
        public async override Task<Employee> Get(int key)
        {
            var employee = _context.Employees
                .Include(x => x.SolutionsProvided)
                .Include(x => x.RequestsClosed)
                .Include(x => x.FeedbacksGiven)
                .Include(x => x.RequestsRaised)
                .SingleOrDefault(e => e.Id == key);

            return employee;
        }
    }
}
