namespace TwitterFeederApp.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using TwitterFeederApp.Library.Parser;

    [TestClass]
    public class Test_JSONParser
    {
        [TestCategory("Library")]
        [TestMethod]
        public void ParsingOfEmptyStringShouldNotCrash()
        {
            var result = JSONParser.ParseTwitteerFeeds(string.Empty);
            Assert.AreEqual(result.Count, 0);
        }        
    }
}
