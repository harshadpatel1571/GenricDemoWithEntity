using Demo.Api.Dto;

namespace Demo.Api.Controllers;

[Route("api/student")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public StudentController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    [Route("save")]
    public async Task<ResponseDto> Save(StudentDto student)
    {
        var response = new ResponseDto();

        if (student != null)
        {
            try
            {
                await _unitOfWork.StudentService.Add(student);
                response.Status = true;
                response.Message = "Record Save Successfully.";
                response.Data = student;
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
    public async Task<ResponseDto> Update(StudentDto student)
    {
        var response = new ResponseDto();

        if (student != null)
        {
            try
            {
                await _unitOfWork.StudentService.Update(student);
                response.Status = true;
                response.Message = "Record Update Successfully.";
                response.Data = student;
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
        var listData = await _unitOfWork.StudentService.GetAll();

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
        var singleData = await _unitOfWork.StudentService.GetById(id);

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

    [HttpGet]
    [Route("searchByPhone")]
    public async Task<ResponseDto> SearchByPhone(string mobileNo)
    {
        var response = new ResponseDto();
        var listData = await _unitOfWork.StudentService.FindByMobile(mobileNo);

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
    [Route("getStudentWiseCourse")]
    public async Task<ResponseDto> GetStudentWiseCourse()
    {
        var response = new ResponseDto();
        var listData = await _unitOfWork.StudentService.GetStudentWiseCourseList();

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

    [HttpDelete]
    [Route("delete")]
    public async Task<ResponseDto> Delete(int id)
    {
        var response = new ResponseDto();

        if (id != 0)
        {
            try
            {
               await _unitOfWork.StudentService.Remove(id);

                response.Status = true;
                response.Message = "Recored Deleted Successfully";
                response.Data = null;
            }
            catch(Exception ex)
            {
                if(ex.InnerException.Message.Contains("REFERENCE constraint"))
                {
                    response.Status = false;
                    response.Message = "Recoured are use some where else can not delete.";
                    response.Data = null;
                }
                else
                {
                    response.Status = false;
                    response.Message = "Error !!";
                    response.Data = null;
                }
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
