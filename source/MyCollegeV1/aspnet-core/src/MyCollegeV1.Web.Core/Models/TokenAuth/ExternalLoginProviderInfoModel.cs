using Abp.AutoMapper;
using MyCollegeV1.Authentication.External;

namespace MyCollegeV1.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
