using RequestTrackerCFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerCFBLLibrary.BLInterfaces
{
    public interface IAdminBL
    {
        public Task<Request> RaiseRequest(Request req, int empid);
        public Task<IList<Request>> GetAllRequestsReceived();
        public Task<IList<Request>> GetAllRequestsRaised(int empid);
        public Task<IList<RequestSolution>> GetAllSolutions(int empid);
        public Task<SolutionFeedback> GiveFeedBack(int empid, int SolutionId, SolutionFeedback solnfeedback);
        public Task<RequestSolution> RespondToSolution(int solnid, int empid, string response);
        public Task<Request> GetRequest(int empid, int reqId);
        public Task<RequestSolution> GetSolution(int empid, int reqId);
        public Task<RequestSolution> ProvideSolution(RequestSolution requestsolution);
        public Task<Request> CloseRequest(int reqId, int empId);
        public Task<IList<SolutionFeedback>> GetAllFeedbacks(int empid);
        public Task<IList<Request>> GetAllRequestsAdminProvidedSolution(int empid);
        public Task<IList<SolutionFeedback>> GetFeedbacksofSolution(int solnid);
    }
}

//Admin
//    Raise Request
//    View Request Status(All Requests)
//    View Solutions(All Solutions)
//    Give Feedback(Only for request raised by them)
//    Respond to Solution(Only for request raised by them)
//    Provide Solution
//    Mark Request as Closed
//    View Feedbacks(Only feedbacks given to them)
