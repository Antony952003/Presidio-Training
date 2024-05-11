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
    public class ELRequestRepository : RequestRepository
    {
        public ELRequestRepository(RequestTrackerContext context) : base(context)
        {
        }
        public async override Task<Request> Get(int key)
        {
            var request = _context.Requests
                .Include(x => x.RequestSolutions)
                .SingleOrDefault(e => e.RequestNumber == key);
            if (request != null)
            {
                return request;
            }
            return null;
        }


        public async override Task<IList<Request>> GetAll()
        {
            return await _context.Requests
                .Include(x => x.RequestSolutions)
                .ToListAsync();
        }
    }
}
