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
    public class Test_TwitterFeedService
    {
        [TestCategory("TwitterFeedsService")]
        [TestMethod]
        public async Task GetFeedsSuccessfully()
        {
            TwitterApplicationOnlyOAuthTokens token = new TwitterApplicationOnlyOAuthTokens()
            {
                OAuthConsumerKey = "SHQOPnu3HknPnVQ1C1CzXHo88",
                OAuthConsumerSecret = "jFRdYXi7bAczFZZ5oB28feBhkTc9ZLOnwOEJBJWmY4Nx1HOV4e"
            };
            var oathToken = TwitterApplicationOnlyAuthService.CreateInstance(token);
            var twitterService = new TwitterFeedsService();
            var twits = await twitterService.GetTimeline("Jon Skeet");
            Assert.AreEqual(twits.Count(), 20);
        }

        [TestCategory("TwitterFeedsService")]
        [TestMethod]
        public void GetNoFeedsInvalidData()
        {
            TwitterApplicationOnlyOAuthTokens token = new TwitterApplicationOnlyOAuthTokens()
            {
                OAuthConsumerKey = "SHQOPnu3HknPnVQ1C1CzXHo88",
                OAuthConsumerSecret = "jFRdYXi7bAczFZZ5oB28feBhkTc9ZLOnwOEJBJWmY4Nx1HOV4e"
            };
            var oathToken = TwitterApplicationOnlyAuthService.CreateInstance(token);
            var twitterService = new TwitterFeedsService();
            var twits = twitterService.GetTimeline("inv");
            Assert.AreEqual(twits.Result.Count(), 0);
        }
    }
}
