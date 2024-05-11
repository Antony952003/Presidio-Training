﻿using Microsoft.EntityFrameworkCore;
using RequestTrackerCFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerCFDALLibrary.LazyLoadedRepos
{
    public class FeedbackRepository : IRepository<int, SolutionFeedback>
    {
        public readonly RequestTrackerContext _context;
        public FeedbackRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<SolutionFeedback> Add(SolutionFeedback entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<SolutionFeedback> Delete(int key)
        {
            var feedback = await Get(key);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
            }
            return feedback;
        }

        public virtual async Task<SolutionFeedback> Get(int key)
        {
            var feedback = _context.Feedbacks.SingleOrDefault(e => e.FeedbackId == key);
            return feedback;
        }

        public virtual async Task<IList<SolutionFeedback>> GetAll()
        {
            return await _context.Feedbacks.ToListAsync();

        }

        public async Task<SolutionFeedback> Update(SolutionFeedback entity)
        {
            var feedback = await Get(entity.FeedbackId);
            if (feedback != null)
            {
                _context.Feedbacks.Update(feedback);
                await _context.SaveChangesAsync();
                return feedback;
            }
            return null;
        }
    }
}
