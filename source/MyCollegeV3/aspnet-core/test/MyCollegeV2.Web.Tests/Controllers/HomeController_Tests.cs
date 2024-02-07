using System.Threading.Tasks;
using MyCollegeV2.Models.TokenAuth;
using MyCollegeV2.Web.Controllers;
using Shouldly;
using Xunit;

namespace MyCollegeV2.Web.Tests.Controllers
{
    public class HomeController_Tests: MyCollegeV2WebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}