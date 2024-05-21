using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Security.Claims;

namespace EmployeeRequestTrackerAPI.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository<int, Employee> _emprepo;
        private readonly IRepository<int, Request> _requestrepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RequestService(IRepository<int, Employee> emprepo, IRepository<int, Request> requestrepo,
            IHttpContextAccessor _httpContextAccessor) {
            _emprepo = emprepo;
            _requestrepo = requestrepo;
        }
        public async Task<ReturnRequestDTO> CloseRequest(int employeeid, int requestnumber,int adminid)
        {
            try
            {
                ReturnRequestDTO returnRequestDTO = null;
                var employee = await _emprepo.Get(employeeid);
                if (employee == null)
                {
                    throw new NoSuchEmployeeException();
                }
                var request = await _requestrepo.Get(requestnumber);
                if (request == null)
                {
                    throw new NoSuchRequestException();
                }
                request.ClosedDate = DateTime.Now;
                request.RequestClosedBy = adminid;
                request.RequestStatus = "Closed";
                await _requestrepo.Update(request);
                returnRequestDTO = MapRequestToReturnDTO(request);
                return returnRequestDTO;
            }
            catch(NoSuchEmployeeException ex)
            {
                throw;
            }
            catch(NoSuchRequestException ex)
            {
                throw;
            }

        }

        public async Task<IList<ReturnRequestDTO>> GetAllOpenRequests()
        {
            try
            {
                var employees = await _emprepo.Get();
                List<Request> OpenRequests = new List<Request>();
                foreach (var employee in employees)
                {
                    var employeerequests = employee.RequestsRaised;
                    if(employeerequests != null)
                    {
                        foreach (var request in employeerequests.ToList())
                        {
                            if (request.RequestStatus == "Open")
                            {
                                OpenRequests.Add(request);
                            }
                        }
                    }
                }
                if (OpenRequests == null) throw new NoRequestsOpenException();
                List<ReturnRequestDTO> OpenRequestReturns = new List<ReturnRequestDTO>();
                OpenRequests.ForEach(r =>
                {
                    OpenRequestReturns.Add(MapRequestToReturnDTO(r));
                });
                return OpenRequestReturns;
            }
            catch(NoSuchEmployeeException ex)
            {
                throw;
            }
        }

        public async Task<ReturnRequestDTO> RaiseRequest(RequestInputDTO requestInputDTO)
        {
            try
            {
                Request request = null;
                ReturnRequestDTO returnRequestDTO = null;
                var employee = await _emprepo.Get(requestInputDTO.EmployeeId);
                if (employee == null)
                {
                    throw new NoSuchEmployeeException();
                }
                request = MapRequestInputWithRequest(requestInputDTO);
                await _requestrepo.Add(request);
                returnRequestDTO = MapRequestToReturnDTO(request);
                return returnRequestDTO;
            }
            catch (NoSuchEmployeeException ex)
            {
                throw;
            }


        }

        private ReturnRequestDTO? MapRequestToReturnDTO(Request request)
        {
            ReturnRequestDTO returnRequestDTO = new ReturnRequestDTO()
            {
                RequestNumber = request.RequestNumber,
                RequestMessage = request.RequestMessage,
                RequestDate  = request.RequestDate,
                ClosedDate  = request.ClosedDate,
                RequestStatus = request.RequestStatus,
                RequestRaisedBy = request.RequestRaisedBy,
                RequestClosedBy = request.RequestClosedBy,
            };
            return returnRequestDTO;

        }

        private Request? MapRequestInputWithRequest(RequestInputDTO requestInputDTO)
        {
            Request request = new Request()
            {
                RequestMessage = requestInputDTO.RequestMessage,
                RequestDate = DateTime.Now,
                RequestRaisedBy = requestInputDTO.EmployeeId,
                RequestStatus = "Open"
                
            };
            return request;
        }
    }
}
