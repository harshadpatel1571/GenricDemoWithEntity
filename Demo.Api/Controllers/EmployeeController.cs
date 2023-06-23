using Demo.Api.Dto;

namespace Demo.Api.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("save")]
        public async Task<ResponseDto> Save(EmployeeDto employee)
        {
            var response = new ResponseDto();

            if (employee != null)
            {
                try
                {
                    await _unitOfWork.EmployeeService.Add(employee);
                    response.Status = true;
                    response.Message = "Record Save Successfully.";
                    response.Data = employee;
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Message = "Error !!";
                    response.Data = null;
                }
            }
            else
            {
                response.Status = false;
                response.Message = "Model Property Required";
                response.Data = null;
            }

            return response;
        }

        [HttpPut]
        [Route("update")]
        public async Task<ResponseDto> Update(EmployeeDto employee)
        {
            var response = new ResponseDto();

            if (employee != null)
            {
                try
                {
                    await _unitOfWork.EmployeeService.Update(employee);
                    response.Status = true;
                    response.Message = "Record Update Successfully.";
                    response.Data = employee;
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Message = "Error !!";
                    response.Data = null;
                }
            }
            else
            {
                response.Status = false;
                response.Message = "Model Property Required";
                response.Data = null;
            }

            return response;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ResponseDto> Get()
        {
            var response = new ResponseDto();
            var listData = await _unitOfWork.EmployeeService.GetAll();

            if (listData.Count() > 0)
            {
                response.Status = true;
                response.Message = "Recored Found.";
                response.Data = listData;
            }
            else
            {
                response.Status = false;
                response.Message = "No Recored Found.";
                response.Data = null;
            }

            return response;
        }

        [HttpGet]
        [Route("getSingle")]
        public async Task<ResponseDto> GetSingle(int id)
        {
            var response = new ResponseDto();
            var singleData = await _unitOfWork.EmployeeService.GetById(id);

            if (singleData != null)
            {
                response.Status = true;
                response.Message = "Recored Found.";
                response.Data = singleData;
            }
            else
            {
                response.Status = false;
                response.Message = "No Recored Found.";
                response.Data = null;
            }

            return response;
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ResponseDto> Delete(int id)
        {
            var response = new ResponseDto();

            if (id != 0)
            {
                try
                {
                    await _unitOfWork.EmployeeService.Remove(id);

                    response.Status = true;
                    response.Message = "Recored Deleted Successfully";
                    response.Data = null;
                }
                catch
                {
                    response.Status = false;
                    response.Message = "Error !!";
                    response.Data = null;
                }
            }
            else
            {
                response.Status = false;
                response.Message = "Wrong Id Found";
                response.Data = null;
            }

            return response;

        }
    }
}
