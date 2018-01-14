namespace TwitterFeederApp.Services
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using TwitterFeederApp.Library.Data_Contracts;
    using Windows.Data.Json;

    public class TwitterApplicationOnlyAuthService
    {
        #region Private Constructor

        private TwitterApplicationOnlyAuthService(TwitterApplicationOnlyOAuthTokens token)
        {
            if (string.IsNullOrEmpty(token.OAuthConsumerKey))
            {
                throw new ArgumentNullException(nameof(token.OAuthConsumerKey));
            }

            if (string.IsNullOrEmpty(token.OAuthConsumerSecret))
            {
                throw new ArgumentNullException(nameof(token.OAuthConsumerSecret));
            }

            BasicToken = new TwitterApplicationOnlyOAuthTokens()
            {
                OAuthConsumerKey = token.OAuthConsumerKey,
                OAuthConsumerSecret = token.OAuthConsumerSecret
            };
        }

        #endregion

        public static TwitterApplicationOnlyOAuthTokens BasicToken { get; set; }
        
        public static async Task<TwitterApplicationOnlyOAuthTokens> CreateInstance(TwitterApplicationOnlyOAuthTokens token)
        {
            new TwitterApplicationOnlyAuthService(token);
            BasicToken.OAuthAccessToken = await GetAccessToken();
            return BasicToken;
        }

        private static async Task<string> GetAccessToken()
        {
            try
            {
                var postBody = "grant_type=client_credentials";
                var client = new HttpClient();
                var oauth_url = "https://api.twitter.com/oauth2/token";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(
                        Encoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", Uri.EscapeDataString(BasicToken.OAuthConsumerKey),
                                          Uri.EscapeDataString(BasicToken.OAuthConsumerSecret)))));

                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Host", "api.twitter.com");

                var content = new StringContent(postBody);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                HttpResponseMessage response = client.PostAsync(oauth_url, content).Result;
                response.EnsureSuccessStatusCode();

                using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                using (var decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress))
                using (var streamReader = new StreamReader(decompressedStream))
                {
                    var json = streamReader.ReadToEnd();
                    JsonValue value = JsonValue.Parse(json);
                    return value.GetObject().GetNamedString("access_token");
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
