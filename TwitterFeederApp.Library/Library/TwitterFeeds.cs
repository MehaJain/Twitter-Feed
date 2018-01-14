namespace TwitterFeederApp.Library
{
    /// <summary>
    /// Twitter Timeline item.
    /// </summary>
    public class TwitterFeeds: TwitterBase
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public TwitterFeeder Feeder { get; set; }

        public TweetsDetails Tweets { get; set; }        
    }
}
