using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        readonly IRequestService _requestService;
        public RequestController(IRequestService requestService) { 
            _requestService = requestService;
        }

        [Route("RaiseRequest")]
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        [ProducesResponseType(typeof(ReturnRequestDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]

        public async Task<ActionResult<ReturnRequestDTO>> RaiseRequest(RequestInputDTO requestInputDTO)
        {
            try
            {
                var result = await _requestService.RaiseRequest(requestInputDTO);
                return Ok(result);
            }
            catch(NoSuchEmployeeException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [Route("CloseRequest")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ReturnRequestDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]

        public async Task<ActionResult<ReturnRequestDTO>> CloseRequest(int employeeid, int requestnumber)
        {
            try
            {
                if ((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value) == "User")
                    throw new AdminOnlyOperationException();
                int adminid = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "eid").Value);
                var result = await _requestService.CloseRequest(employeeid, requestnumber,adminid);
                return Ok(result);
            }
            catch (NoSuchEmployeeException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch(NoSuchRequestException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch(AdminOnlyOperationException ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
        [Route("GetAllOpenRequests")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IList<ReturnRequestDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<ReturnRequestDTO>>> GetAllOpenRequests()
        {
            try
            {
                if ((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value) == "User")
                    throw new AdminOnlyOperationException();
                int adminid = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "eid").Value);
                var result = await _requestService.GetAllOpenRequests();
                return Ok(result);
            }
            catch(NoRequestsOpenException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch (NoSuchEmployeeException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch (AdminOnlyOperationException ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
    }
}
