using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MyCollegeV2.Authorization;
using MyCollegeV2.Students.Dto;
using MyCollegeV2.Models;

namespace MyCollegeV2.Students
{

    // [AbpAuthorize(PermissionNames.Pages_Students)]
    public class StudentAppService : AsyncCrudAppService<Student, StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, UpdateStudentDto>, IStudentAppService
    {
        public StudentAppService
        (
            IRepository<Student, int> repository
        )
        : base(repository)
        {

        }

    }
}
