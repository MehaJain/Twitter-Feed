namespace TwitterFeederApp.Library.Data_Contracts
{
    using TwitterFeederApp.Library.Notifications;

    /// <summary>
    /// Twitter Application Only OAth tokens
    /// </summary>
    public class TwitterApplicationOnlyOAuthTokens : NotifierBase
    {
        #region Private Fields

        // stores the consumer key of OAuth token
        private string oAuthConsumerKey { get; set; }

        // stores the consumer secret key of OAth token
        private string oAuthConsumerSecret { get; set; }

        // stores the access-token
        private string oAuthAccessToken { get; set; }

        #endregion

        #region Properties
        
        public bool IsFieldEmpty
        {
            get
            {
                return (!string.IsNullOrEmpty(this.oAuthConsumerSecret) && !string.IsNullOrEmpty(this.oAuthConsumerKey));
            }            
        }

        /// <summary>
        /// Stores the OAth token consumer key
        /// </summary>
        public string OAuthConsumerKey
        {
            get
            {
                return this.oAuthConsumerKey;
            } // get

            set
            {
                this.oAuthConsumerKey = value;
                this.OnPropertyChanged(() => this.OAuthConsumerKey);
                this.OnPropertyChanged(() => IsFieldEmpty);
            } // set
        }

        /// <summary>
        /// Stores the OAth token consumer secret
        /// </summary>
        public string OAuthConsumerSecret
        {
            get
            {
                return this.oAuthConsumerSecret;
            } // get

            set
            {
                this.oAuthConsumerSecret = value;
                this.OnPropertyChanged(() => this.OAuthConsumerSecret);
                this.OnPropertyChanged(() => IsFieldEmpty);
            } // set
        }

        /// <summary>
        /// Stores the OAth access-token
        /// </summary>
        public string OAuthAccessToken
        {
            get
            {
                return this.oAuthAccessToken;
            } // get

            set
            {
                this.oAuthAccessToken = value;
                this.OnPropertyChanged(() => this.OAuthAccessToken);
                this.OnPropertyChanged(() => IsFieldEmpty);
            } // set
        }

        #endregion
    }
}