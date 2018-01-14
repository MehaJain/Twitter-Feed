namespace TwitterFeederApp.Library
{    
    public class DirectTweet: TwitterBase
    {
        public decimal Id { get; set; }

        public decimal SenderId { get; set; }

        public string Text { get; set; }

        public decimal RecipientId { get; set; }
        
        public string SenderScreenName { get; set; }

        public string RecipientScreenName { get; set; }

        public TwitterFeeder Sender { get; set; }

        public TwitterFeeder Recipient { get; set; }

        public TweetsDetails Entities { get; set; }        
    }
}
