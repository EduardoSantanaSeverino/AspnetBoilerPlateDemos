using Abp.AutoMapper;
using MyCollegeV2.Authentication.External;

namespace MyCollegeV2.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
