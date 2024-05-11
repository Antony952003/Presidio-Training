using RequestTrackerCFDALLibrary;
using RequestTrackerCFDALLibrary.LazyLoadedRepos;
using RequestTrackerCFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerCFBLLibrary
{
    public class AdminBL : IAdminBL
    {
        IRepository<int, Employee> _emprepository;
        IRepository<int, Request> _requestrepository;
        IRepository<int, RequestSolution> _reqsolutionrepository;
        IRepository<int, SolutionFeedback> _feedbackrepository;
        public AdminBL()
        {
            _emprepository = new EmployeeRepository(new RequestTrackerContext());
            _requestrepository = new RequestRepository(new RequestTrackerContext());
            _reqsolutionrepository = new RequestSolutionRepository(new RequestTrackerContext());
            _feedbackrepository = new FeedbackRepository(new RequestTrackerContext());
        }
        public async Task<Request> CloseRequest(int reqId, int empId)
        {
            var request = await _requestrepository.Get(reqId);
            var employee = await _emprepository.Get(empId);
            if (request != null)
            {
                employee.RequestsClosed.Add(request);
                await _emprepository.Update(employee);
                request.RequestClosedByEmployee = employee;
                request.RequestStatus = "closed";
                request.ClosedDate = System.DateTime.Now;
                await _requestrepository.Update(request);
                return request;
            }
            return null;
        }

        public async Task<IList<SolutionFeedback>> GetAllFeedbacks(int empid)
        {
            var employee = await _emprepository.Get(empid);
            if(employee != null)
            {
                return employee.FeedbacksGiven.ToList();
            }
            return null;
        }

        public async Task<IList<Request>> GetAllRequestsRaised(int empid)
        {
            var employee = await _emprepository.Get(empid);
            if (employee != null)
            {
                return employee.RequestsRaised.ToList();
            }
            return null;
            
        }
        public async Task<IList<Request>> GetAllRequestsReceived(int empid)
        {
            var employee = await _emprepository.Get(empid);
            var allrequests = await _requestrepository.GetAll();
            List<Request> allrequestsreceived = new List<Request>();
            allrequests.ToList().ForEach(request =>
            {
                var valid = request.RequestSolutions.ToList().Find(x => x.SolvedBy == employee.Id);
                if (valid != null)
                {
                    allrequestsreceived.Add(request);
                }
            });
            return allrequestsreceived;
        }

        public async Task<IList<RequestSolution>> GetAllSolutions(int empid)
        {
            var employee = await _emprepository.Get(empid);
            if(employee != null)
            {
                return employee.SolutionsProvided.ToList();
            }
            return null;
        }

        public async Task<Request> GetRequest(int empid,int reqId)
        {
            var request = await _requestrepository.Get(reqId);
            if(request!= null)
            {
                return request;
            }
            return null;
        }

        public async Task<RequestSolution> GetSolution(int empid, int solutionId)
        {
            var employee = await _emprepository.Get(empid);
            if(employee != null)
            {
                return employee.SolutionsProvided.ToList().Find(x => x.SolutionId == solutionId);
            }
            return null;
        }

        public async Task<SolutionFeedback> GiveFeedBack(int empid,int SolutionId, SolutionFeedback solnfeedback)
        {
            var employee = await _emprepository.Get(empid);
            var FoundSolution = await _reqsolutionrepository.Get(SolutionId);
            await _feedbackrepository.Add(solnfeedback);
            FoundSolution.Feedbacks.Add(solnfeedback);
            employee.FeedbacksGiven.Add(solnfeedback);
            await _emprepository.Update(employee);
            await _reqsolutionrepository.Update(FoundSolution);
            return solnfeedback;
        }

        public async Task<RequestSolution> ProvideSolution(int empid, int reqId, RequestSolution requestsolution)
        {
            var employee = await _emprepository.Get(empid);
            var request = await _requestrepository.Get(reqId);
            request.RequestSolutions.Add(requestsolution);
            employee.SolutionsProvided.Add(requestsolution);
            await _requestrepository.Update(request);
            return requestsolution;
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

        public async Task<RequestSolution> RespondToSolution(int solnid, int empid,string response)
        {
            var requestsoln = await _reqsolutionrepository.Get(solnid);
            requestsoln.RequestRaiserComment = response;
            await _reqsolutionrepository.Update(requestsoln);
            return requestsoln;

        }
    }
}
