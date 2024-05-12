using RequestTrackerCFBLLibrary.BLInterfaces;
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
        IRepository<int, Request> _elrequestrepository;
        IRepository<int, RequestSolution> _reqsolutionrepository;
        IRepository<int, SolutionFeedback> _feedbackrepository;
        IRepository<int, SolutionFeedback> _elfeedbackrepository;
        public UserBL()
        {

            _emprepository = new EmployeeRepository(new RequestTrackerContext());
            _requestrepository = new RequestRepository(new RequestTrackerContext());
            _reqsolutionrepository = new RequestSolutionRepository(new RequestTrackerContext());
            _feedbackrepository = new FeedbackRepository(new RequestTrackerContext());
            _elemprepository = new ELEmployeeRepository(new RequestTrackerContext());
            _elrequestrepository = new ELRequestRepository(new RequestTrackerContext());
            _elfeedbackrepository = new ELFeedbackRepository(new RequestTrackerContext());
        }

        public async Task<int> GenerateId()
        {
            var employees = await _emprepository.GetAll();
            int id = employees.Max(x => x.Id);
            return ++id;
        }
        public async Task<SolutionFeedback> GiveFeedBack(int empid, SolutionFeedback SolnFeedback, int SolutionId)
        {
            await _feedbackrepository.Add(SolnFeedback);
            return SolnFeedback;
        }

        public async Task<Request> RaiseRequest(Request req, int empid)
        {
            var IsFound = await _elrequestrepository.Get(req.RequestNumber);
            if (IsFound != null) { return null; }
            var AddedRequest = await _requestrepository.Add(req);
            //employee.RequestsRaised.Add(req);
            var FoundEmployee = await _elemprepository.Get(empid);
            FoundEmployee.RequestsRaised.Add(req);
            await _emprepository.Update(FoundEmployee);
            return AddedRequest;
        }

        public async Task<RequestSolution> RespondToSolution(int solutionId, string response)
        {
            var AllSolutions = await _reqsolutionrepository.GetAll();
            var FoundSolution = AllSolutions.ToList().Find(x => x.SolutionId == solutionId);
            if (FoundSolution != null)
            {
                FoundSolution.RequestRaiserComment = response;
                return await _reqsolutionrepository.Update(FoundSolution);
            }
            return null;
        }

        public async Task<string> ViewRequestStatus(Request req)
        {
            var IsFound = await _elrequestrepository.Get(req.RequestNumber);
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
        public async Task<IList<Request>> GetAllRequestsById(int requestRaisedBy)
        {
            var requests = (await _elrequestrepository.GetAll()).ToList().FindAll(r => r.RequestRaisedBy == requestRaisedBy);
            if (requests.Count == 0)
            {
                return null;
            }
            return requests;
        }
    }
}
