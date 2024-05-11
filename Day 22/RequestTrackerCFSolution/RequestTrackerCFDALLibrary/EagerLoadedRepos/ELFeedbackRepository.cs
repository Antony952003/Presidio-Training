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
    public class ELFeedbackRepository : FeedbackRepository
    {
        public ELFeedbackRepository(RequestTrackerContext context) : base(context)
        {
        }
        public async  override Task<SolutionFeedback> Get(int key)
        {
            var feedback = _context.Feedbacks.SingleOrDefault(e => e.FeedbackId == key);
            return feedback;
        }

        public async override Task<IList<SolutionFeedback>> GetAll()
        {
            return await _context.Feedbacks.ToListAsync();

        }
    }
}
