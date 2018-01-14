namespace TwitterFeederApp.Library.Parser
{
    using System.Collections.Generic;
    using Windows.Data.Json;

    /// <summary>
    /// JSON Parser which parses string into JSON object
    /// </summary>
    public class JSONParser
    {
        public static List<TwitterFeeds> ParseTwitteerFeeds(string stringToParse)
        {
            List<TwitterFeeds> feeds = new List<TwitterFeeds>();

            if (string.IsNullOrEmpty(stringToParse))
            {
                return feeds;
            }
            try
            {
                if (!JsonValue.TryParse(stringToParse, out JsonValue value))
                {
                    return feeds;
                }
                JsonArray root = value.GetArray();
                for (uint i = 0; i < root.Count; i++)
                {
                    TwitterFeeds feed = new TwitterFeeds();
                    var feeder = new TwitterFeeder();
                    feed.CreatedAt = root.GetObjectAt(i).GetNamedString("created_at");
                    feed.Id = root.GetObjectAt(i).GetNamedNumber("id").ToString();
                    feed.Text = root.GetObjectAt(i).GetNamedString("text");

                    var user = root.GetObjectAt(i).GetNamedObject("user");
                    feeder.Id = user.GetNamedString("id_str");
                    feeder.Name = user.GetNamedString("name");
                    feeder.ScreenName = user.GetNamedString("screen_name");
                    feeder.DisplayPictureUrl = user.GetNamedString("profile_image_url");
                    feed.Feeder = feeder;
                    feeds.Add(feed);
                };
            }
            finally
            {                
            }
            return feeds;
        }
    }
}
