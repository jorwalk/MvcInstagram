using InstaSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcInstagram.Controllers;
using MvcInstagram.Helpers;

namespace MvcInstagram.Tests.Controllers
{
    [TestClass]
    public class InstagramControllerTest
    {
        public const string AccessToken = "184083663.ce1818b.b94e7d1a4af84cb9abcd1b9230d36727";
        public const int UserId = 184083663;
        public const string UserName = "jordanwa1ker";
        


        [TestMethod]
        public void GetPhotos()
        {
            InstagramController controller = new InstagramController();
            // Arrange
            var config = InstagramHelper.GetConfig();
            var authInfo = InstagramHelper.GetAuthInfo();
            var users = new InstaSharp.Endpoints.Users.Authenticated(config, authInfo);


            // Act
            var result = users.Feed("self");
           
            // Assert
            
        }
    }
}
