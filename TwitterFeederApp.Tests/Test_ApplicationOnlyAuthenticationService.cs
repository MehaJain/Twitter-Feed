using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterFeederApp.Library.Data_Contracts;
using TwitterFeederApp.Services;

namespace TwitterFeederApp.Tests
{
    [TestClass]
    public class Test_ApplicationOnlyAuthenticationService
    {
        [TestCategory("AuthenticationService")]
        [TestMethod]
        public void ApplicationOnlyAuthenticationServiceReturnsValidToken()
        {
            TwitterApplicationOnlyOAuthTokens token = new TwitterApplicationOnlyOAuthTokens()
            {
                OAuthConsumerKey = "SHQOPnu3HknPnVQ1C1CzXHo88",
                OAuthConsumerSecret = "jFRdYXi7bAczFZZ5oB28feBhkTc9ZLOnwOEJBJWmY4Nx1HOV4e"
            };
            var oathToken = TwitterApplicationOnlyAuthService.CreateInstance(token);
            Assert.IsTrue(oathToken.Result.OAuthAccessToken != null);
        }

        [TestCategory("AuthenticationService")]
        [TestMethod]
        public void ApplicationOnlyAuthenticationServiceReturnsInValidToken()
        {
            TwitterApplicationOnlyOAuthTokens token = new TwitterApplicationOnlyOAuthTokens()
            {
                OAuthConsumerKey = "SHQOPnuC1CzXHo88",
                OAuthConsumerSecret = "jFRdYTc9ZLOnwOEJBJWmY4Nx1HOV4e"
            };
            var oathToken = TwitterApplicationOnlyAuthService.CreateInstance(token);
            Assert.IsTrue(oathToken.Result.OAuthAccessToken == null);
        }        
    }
}
