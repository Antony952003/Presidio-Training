using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IRequestService
    {
        public Task<ReturnRequestDTO> RaiseRequest(RequestInputDTO requestInputDTO);
        public Task<IList<ReturnRequestDTO>> GetAllOpenRequests();
        public Task<ReturnRequestDTO> CloseRequest(int employeeid, int requestnumber, int adminid);
    }
}
