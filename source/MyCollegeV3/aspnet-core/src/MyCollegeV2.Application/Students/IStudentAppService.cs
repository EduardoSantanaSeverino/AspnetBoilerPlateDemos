using Abp.Application.Services;
using MyCollegeV2.Students.Dto;

namespace MyCollegeV2.Students
{
    public interface IStudentAppService : IAsyncCrudAppService<StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, UpdateStudentDto>
    {
      
    }
}

