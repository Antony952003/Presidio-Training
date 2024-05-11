using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerCFModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerCFBLLibrary
{
    public interface IUserBL
    {
        public Task<Request> RaiseRequest(Request req, int empid);
        public Task<string> ViewRequestStatus(Request req);
        public Task<IList<RequestSolution>> ViewSolutions(int RequestId);
        public Task<SolutionFeedback> GiveFeedBack(int empid, SolutionFeedback SolnFeedback, int SolutionId);
        public Task<RequestSolution> RespondToSolution(int ReqNumber, string response);
    }
}

//User
//    Raise Request
//    View Request Status
//    View Solutions
//    Give Feedback
//    Respond to Solution
//|