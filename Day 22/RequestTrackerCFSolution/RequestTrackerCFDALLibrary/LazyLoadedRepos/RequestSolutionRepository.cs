using Microsoft.EntityFrameworkCore;
using RequestTrackerCFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerCFDALLibrary.LazyLoadedRepos
{
    public class RequestSolutionRepository : IRepository<int, RequestSolution>
    {
        RequestTrackerContext _context;
        public RequestSolutionRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<RequestSolution> Add(RequestSolution entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<RequestSolution> Delete(int key)
        {
            var requestsolution = await Get(key);
            if (requestsolution != null)
            {
                _context.RequestSolutions.Remove(requestsolution);
                await _context.SaveChangesAsync();
                return requestsolution;
            }
            return null;
        }

        public async Task<RequestSolution> Get(int key)
        {
            var requestsolution = _context.RequestSolutions.SingleOrDefault(x => x.SolutionId == key);
            if (requestsolution != null)
            {
                return requestsolution;
            }
            return null;
        }

        public async Task<IList<RequestSolution>> GetAll()
        {
            return await _context.RequestSolutions.ToListAsync();
        }

        public async Task<RequestSolution> Update(RequestSolution entity)
        {
            var requestsolution = await Get(entity.SolutionId);
            if (requestsolution != null)
            {
                _context.RequestSolutions.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }
    }
}
