using RequestTrackerCFDALLibrary;
using RequestTrackerCFDALLibrary.EagerLoadedRepos;
using RequestTrackerCFDALLibrary.LazyLoadedRepos;
using RequestTrackerCFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerCFBLLibrary
{
    public class UserBL : IUserBL
    {
        IRepository<int, Employee> _emprepository;
        IRepository<int, Employee> _elemprepository;
        IRepository<int, Request> _requestrepository;
        IRepository<int, RequestSolution> _reqsolutionrepository;
        IRepository<int, SolutionFeedback> _feedbackrepository;
        public UserBL() {

            _emprepository = new EmployeeRepository(new RequestTrackerContext());
            _requestrepository = new RequestRepository(new RequestTrackerContext());
            _reqsolutionrepository = new RequestSolutionRepository(new RequestTrackerContext());
            _feedbackrepository = new FeedbackRepository(new RequestTrackerContext());
            _elemprepository = new ELEmployeeRepository(new RequestTrackerContext());
        }
        public async Task<SolutionFeedback> GiveFeedBack(int empid,SolutionFeedback SolnFeedback,int SolutionId)
        {
            var employee = await _emprepository.Get(empid);
            var FoundSolution = await _reqsolutionrepository.Get(SolutionId);
            await _feedbackrepository.Add(SolnFeedback);
            FoundSolution.Feedbacks.Add(SolnFeedback);
            employee.FeedbacksGiven.Add(SolnFeedback);
            await _emprepository.Update(employee);
            await _reqsolutionrepository.Update(FoundSolution);
            return SolnFeedback;
        }

        public async Task<Request> RaiseRequest(Request req, int empid)
        {
            var employee = await _emprepository.Get(empid);
            var IsFound = await _requestrepository.Get(req.RequestNumber);
            if (IsFound == null) { return null; }
            var AddedRequest = await _requestrepository.Add(req);
            //employee.RequestsRaised.Add(req);
            var FoundEmployee = await _emprepository.Get(employee.Id);
            FoundEmployee.RequestsRaised.Add(req);
            await _emprepository.Update(FoundEmployee);
            return AddedRequest;
        }

        public async Task<RequestSolution> RespondToSolution(int ReqNumber, string response)
        {
            var IsFound = await _requestrepository.Get(ReqNumber);
            if(IsFound != null)
            {
                var AllSolutions = await _reqsolutionrepository.GetAll();
                var FoundSolution = AllSolutions.ToList().Find(x => x.RequestId == ReqNumber);
                FoundSolution.RequestRaiserComment = response;
                return await _reqsolutionrepository.Update(FoundSolution);
            }
            return null;
        }

        public async Task<string> ViewRequestStatus(Request req)
        {
            var IsFound = await _requestrepository.Get(req.RequestNumber);
            if (IsFound != null)
            {
                return IsFound.RequestStatus;
            }
            return null;
        }

        public async Task<IList<RequestSolution>> ViewSolutions(int RequestId)
        {
            var AllSolutions = await _reqsolutionrepository.GetAll();
            var SolutionsForRequest = AllSolutions.ToList().FindAll(x => x.RequestId == RequestId);
            return SolutionsForRequest;
        }
    }
}
