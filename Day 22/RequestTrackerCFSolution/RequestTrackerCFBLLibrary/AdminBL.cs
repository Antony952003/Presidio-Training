using RequestTrackerCFBLLibrary.BLInterfaces;
using RequestTrackerCFDALLibrary;
using RequestTrackerCFDALLibrary.EagerLoadedRepos;
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
        IRepository<int, Employee> _elemprepository;
        IRepository<int, Request> _requestrepository;
        IRepository<int, Request> _elrequestrepository;
        IRepository<int, RequestSolution> _reqsolutionrepository;
        IRepository<int, SolutionFeedback> _feedbackrepository;
        IRepository<int, SolutionFeedback> _elfeedbackrepository;
        public AdminBL()
        {
            _emprepository = new EmployeeRepository(new RequestTrackerContext());
            _requestrepository = new RequestRepository(new RequestTrackerContext());
            _reqsolutionrepository = new RequestSolutionRepository(new RequestTrackerContext());
            _feedbackrepository = new FeedbackRepository(new RequestTrackerContext());
            _elemprepository = new ELEmployeeRepository(new RequestTrackerContext());
            _elrequestrepository = new ELRequestRepository(new RequestTrackerContext());
            _elfeedbackrepository = new ELFeedbackRepository(new RequestTrackerContext());
        }
        public async Task<Request> CloseRequest(int reqId, int empId)
        {
            var request = await _elrequestrepository.Get(reqId);
            var employee = await _elemprepository.Get(empId);
            if (request != null)
            {
                request.RequestClosedBy = employee.Id;
                request.RequestStatus = "closed";
                request.ClosedDate = System.DateTime.Now;
                await _requestrepository.Update(request);
                return request;
            }
            return null;
        }

        public async Task<IList<SolutionFeedback>> GetAllFeedbacks(int empid)
        {
            var employee = await _elemprepository.Get(empid);
            if(employee != null)
            {
                return employee.FeedbacksGiven.ToList();
            }
            return null;
        }
        public async Task<IList<SolutionFeedback>> GetFeedbacksofSolution(int solnid)
        {
            var allfeedbacks = await _feedbackrepository.GetAll();
            var FeedbacksOfSolution = allfeedbacks.ToList().FindAll((x) => x.SolutionId == solnid);
            return FeedbacksOfSolution;
        }

        public async Task<IList<Request>> GetAllRequestsRaised(int empid)
        {
            var employee = await _elemprepository.Get(empid);
            if (employee != null)
            {
                return employee.RequestsRaised.ToList();
            }
            return null;
            
        }
        public async Task<IList<Request>> GetAllRequestsReceived()
        {
            var allrequests = await _elrequestrepository.GetAll();
            return allrequests;
            //List<Request> allrequestsreceived = new List<Request>();
            //allrequests.ToList().ForEach(request =>
            //{
            //    var valid = request.RequestSolutions.ToList().Find(x => x.SolvedBy == employee.Id);
            //    if (valid != null)
            //    {
            //        allrequestsreceived.Add(request);
            //    }
            //});
            //return allrequestsreceived;
        }

        public async Task<IList<RequestSolution>> GetAllSolutions(int empid)
        {
            var employee = await _elemprepository.Get(empid);
            if(employee != null)
            {
                return employee.SolutionsProvided.ToList();
            }
            return null;
        }

        public async Task<Request> GetRequest(int empid,int reqId)
        {
            var request = await _elrequestrepository.Get(reqId);
            if(request!= null)
            {
                return request;
            }
            return null;
        }

        public async Task<RequestSolution> GetSolution(int empid, int solutionId)
        {
            var employee = await _elemprepository.Get(empid);
            if(employee != null)
            {
                return employee.SolutionsProvided.ToList().Find(x => x.SolutionId == solutionId);
            }
            return null;
        }

        public async Task<SolutionFeedback> GiveFeedBack(int empid,int SolutionId, SolutionFeedback solnfeedback)
        {
            var employee = await _elemprepository.Get(empid);
            var FoundSolution = await _reqsolutionrepository.Get(SolutionId);
            await _feedbackrepository.Add(solnfeedback);
            FoundSolution.Feedbacks.Add(solnfeedback);
            employee.FeedbacksGiven.Add(solnfeedback);
            await _emprepository.Update(employee);
            await _reqsolutionrepository.Update(FoundSolution);
            return solnfeedback;
        }

        public async Task<RequestSolution> ProvideSolution(RequestSolution requestsolution)
        {
            var result = await _reqsolutionrepository.Add(requestsolution);
            return requestsolution;
        }

        public async Task<Request> RaiseRequest(Request req, int empid)
        {
            var IsFound = await _elrequestrepository.Get(req.RequestNumber);
            if (IsFound == null) { return null; }
            var AddedRequest = await _requestrepository.Add(req);
            //employee.RequestsRaised.Add(req);
            var FoundEmployee = await _elemprepository.Get(empid);
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
        public async Task<IList<Request>> GetAllRequestsAdminProvidedSolution(int empid)
        {
            var AllRequests = await _elrequestrepository.GetAll();
            var AllRequestsAdminProvidedSolution = new List<Request>();
            AllRequests.ToList().ForEach(req =>
            {
                var DidAdminSolve = req.RequestSolutions.ToList().SingleOrDefault(x => x.SolvedBy == empid);
                if(DidAdminSolve != null)
                    AllRequestsAdminProvidedSolution.Add(req);
            });
            return AllRequestsAdminProvidedSolution;
        }
    }
}
