using Microsoft.AspNetCore.Mvc;
using TeamMuseum.Services.Dtos;
using TeamMuseum.Services.Services;
using static TeamMuseum.Services.Enums.Enums;

namespace TeamMuseum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService) 
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ReturnResult> Get(int id)
        {
            ReturnResult returnResult;
            var result = await _appointmentService.Get(id);
            
            return returnResult = new ReturnResult()
            {
                IsSuccess = true,
                Status = ResultStatus.Success,
                Data = result,
                ErrorMessage = ""
            };
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ReturnResult> GetAll()
        {
            ReturnResult returnResult;
            var result = await _appointmentService.GetAll();

            return returnResult = new ReturnResult()
            {
                IsSuccess = true,
                Status = ResultStatus.Success,
                Data = result,
                ErrorMessage = ""
            };
        }

        [HttpGet]
        [Route("GetAll/{visitorId}")]
        public async Task<ReturnResult> GetAll(string visitorId)
        {
            ReturnResult returnResult;
            var result = await _appointmentService.GetAllVisitorAppointments(visitorId);

            return returnResult = new ReturnResult()
            {
                IsSuccess = true,
                Status = ResultStatus.Success,
                Data = result,
                ErrorMessage = ""
            };
        }

        [HttpPost]
        [Route("")]
        public async Task<ReturnResult> Create(AppointmentDto appointmentDto)
        {
            ReturnResult returnResult;
            try
            {
                var result = await _appointmentService.Insert(appointmentDto);
                if(result == 0)
                {
                    return returnResult = new ReturnResult()
                    {
                        Data = null,
                        ErrorMessage = "Somting went rong while creating an appointment!",
                        IsSuccess = false,
                        Status = ResultStatus.Error
                    };
                }
                return returnResult = new ReturnResult()
                {
                    IsSuccess = true,
                    Status = ResultStatus.Success,
                    Data = appointmentDto,
                    ErrorMessage = ""
                };
            }
            catch (Exception)
            {
                return returnResult = new ReturnResult()
                {
                    Data = null,
                    ErrorMessage = "Somting went rong while creating an appointment!",
                    IsSuccess = false,
                    Status = ResultStatus.Error
                };
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<ReturnResult> Update(AppointmentDto appointmentDto)
        {
            ReturnResult returnResult;
            try
            {
                var result = await _appointmentService.Update(appointmentDto);
                if (result == 0)
                {
                    return returnResult = new ReturnResult()
                    {
                        Data = null,
                        ErrorMessage = "Somting went rong while updating an appointment!",
                        IsSuccess = false,
                        Status = ResultStatus.Error
                    };
                }
                return returnResult = new ReturnResult()
                {
                    IsSuccess = true,
                    Status = ResultStatus.Success,
                    Data = appointmentDto,
                    ErrorMessage = ""
                };
            }
            catch (Exception)
            {
                return returnResult = new ReturnResult()
                {
                    Data = null,
                    ErrorMessage = "Somting went rong while updating an appointment!",
                    IsSuccess = false,
                    Status = ResultStatus.Error
                };
            }
        }

        [HttpDelete]
        [Route("")]
        public async Task<ReturnResult> Delete(int id)
        {
            ReturnResult returnResult;
            try
            {
                var appointmentToBeDeleted = await _appointmentService.Get(id);
                var result = await _appointmentService.Delete(appointmentToBeDeleted);
                if (result == 0)
                {
                    return returnResult = new ReturnResult()
                    {
                        Data = null,
                        ErrorMessage = "Somting went rong while deleting an appointment!",
                        IsSuccess = false,
                        Status = ResultStatus.Error
                    };
                }
                return returnResult = new ReturnResult()
                {
                    IsSuccess = true,
                    Status = ResultStatus.Success,
                    Data = id,
                    ErrorMessage = ""
                };
            }
            catch (Exception)
            {
                return returnResult = new ReturnResult()
                {
                    Data = null,
                    ErrorMessage = "Somting went rong while deleting an appointment!",
                    IsSuccess = false,
                    Status = ResultStatus.Error
                };
            }
        }
    }
}
