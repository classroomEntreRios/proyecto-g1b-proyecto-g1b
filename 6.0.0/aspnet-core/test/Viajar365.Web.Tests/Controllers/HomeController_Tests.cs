using System.Threading.Tasks;
using Viajar365.Models.TokenAuth;
using Viajar365.Web.Controllers;
using Shouldly;
using Xunit;

namespace Viajar365.Web.Tests.Controllers
{
    public class HomeController_Tests: Viajar365WebTestBase
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