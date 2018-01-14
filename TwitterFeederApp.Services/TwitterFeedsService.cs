namespace TwitterFeederApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TwitterFeederApp.Library;
    using TwitterFeederApp.Library.Parser;

    public class TwitterFeedsService
    {
        public async Task<IEnumerable<TwitterFeeds>> GetTimeline(string userName, int count = 20, string accessToken = null)
        {
            List<TwitterFeeds> feeds = new List<TwitterFeeds>();
            try
            {
                string apiUrl = string.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={1}&count={0}", count, userName.Replace(" ", ""));
                var json = string.Empty;
                var myClient = new HttpClient();
                var timelineHeaderFormat = "{0} {1}";
                myClient.DefaultRequestHeaders.Add("Authorization",
                                            string.Format(timelineHeaderFormat, "Bearer",
                                                          accessToken));

                myClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip");
                myClient.DefaultRequestHeaders.TryAddWithoutValidation("Host", "api.twitter.com");

                var timeLineResponse = await myClient.GetAsync(apiUrl);
                string jsonString = string.Empty;
                using (timeLineResponse)
                {
                    using (Stream responseStream = await timeLineResponse.Content.ReadAsStreamAsync())
                    using (var decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress))
                    using (var streamReader = new StreamReader(decompressedStream))
                    {                        
                        jsonString = streamReader.ReadToEnd();                        
                    }
                }
                return JSONParser.ParseTwitteerFeeds(jsonString);
            }
            catch (Exception)
            {
                return feeds;
            }
        }        
    }
}
