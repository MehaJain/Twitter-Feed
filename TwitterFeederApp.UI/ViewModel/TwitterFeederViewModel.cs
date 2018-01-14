namespace TwitterFeederApp.UI.ViewModel
{
    using System.Collections.Generic;
    using System.Linq;
    using TwitterFeederApp.Library;
    using TwitterFeederApp.Library.Data_Contracts;
    using TwitterFeederApp.Library.Notifications;
    using TwitterFeederApp.UI.Commands;
    using TwitterFeederApp.Services;

    public class TwitterFeederViewModel: NotifierBase
    {
        #region Private Data Members

        private string error;
        private string searchTag;
        private string searchError;
        private IEnumerable<TwitterFeeds> dataSource;
        private bool resultsVisibility;
        private bool searchVisibility;
        private bool authenticationVisibility;
        private bool searchCollapsableVisibility;
        private string searchContent;
        private string authenticationContent;
        private TwitterApplicationOnlyOAuthTokens applicationOnlyToken = new TwitterApplicationOnlyOAuthTokens();
        private DelegateCommand handleSearchCommand;
        private DelegateCommand handleConnectCommand;
        private DelegateCommand connectCommand;
        private DelegateCommand searchCommand;

        #endregion

        #region Constructor
        
        public TwitterFeederViewModel()
        {
            this.searchVisibility = false;
            this.searchContent = "";
            this.searchCollapsableVisibility = false;
        }

        #endregion

        #region Properties

        public DelegateCommand HandleSearchCommand
        {
            get
            {
                if (handleSearchCommand == null)
                {
                    handleSearchCommand = new DelegateCommand(HandleSearch);
                }
                return handleSearchCommand;
            }
        }

        public DelegateCommand HandleConnectCommand
        {
            get
            {
                if (handleConnectCommand == null)
                {
                    handleConnectCommand = new DelegateCommand(HandleConnect);
                }
                return handleConnectCommand;
            }
        }

        public DelegateCommand ConnectCommand
        {
            get
            {
                if(connectCommand == null)
                {
                    connectCommand = new DelegateCommand(Connect);
                }
                return connectCommand;
            }
        }

        public DelegateCommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                {
                    searchCommand = new DelegateCommand(Search);
                }
                return searchCommand;
            }
        }

        public string AuthenticationContent
        {
            get
            {
                return this.authenticationContent;
            }

            set
            {
                this.authenticationContent = value;
                this.OnPropertyChanged(() => this.AuthenticationContent);
            }
        }

        public string SearchContent
        {
            get
            {
                return this.searchContent;
            }

            set
            {
                this.searchContent = value;
                this.OnPropertyChanged(() => this.SearchContent);
            }
        }

        public bool SearchCollapsableVisibility
        {
            get
            {
                return this.searchCollapsableVisibility;
            }

            set
            {
                this.searchCollapsableVisibility = value;
                this.OnPropertyChanged(() => this.SearchCollapsableVisibility);
            }
        }

        public bool AuthenticationVisibility
        {
            get
            {
                return this.authenticationVisibility;
            }

            set
            {
                this.authenticationVisibility = value;
                this.OnPropertyChanged(() => this.AuthenticationVisibility);
            }
        }

        public bool SearchVisibility
        {
            get
            {
                return this.searchVisibility;
            }

            set
            {
                this.searchVisibility = value;
                this.OnPropertyChanged(() => this.SearchVisibility);
            }
        }

        public bool ResultsVisibility
        {
            get
            {
                return this.resultsVisibility;
            }

            set
            {
                this.resultsVisibility = value;
                this.OnPropertyChanged(() => this.ResultsVisibility);
            }
        }

        public string Error
        {
            get
            {
                return this.error;
            }

            set
            {
                this.error = value;
                this.OnPropertyChanged(() => this.Error);
            }
        }

        public IEnumerable<TwitterFeeds> DataSource
        {
            get
            {
                return this.dataSource;
            }

            set
            {
                this.dataSource = value;
                this.OnPropertyChanged(() => this.DataSource);
            }
        }

        public string SearchTag
        {
            get
            {
                return this.searchTag;
            }

            set
            {
                this.searchTag = value;
                this.OnPropertyChanged(() => this.SearchTag);
                this.OnPropertyChanged(() => CanSearch);
            }
        }

        public string SearchError
        {
            get
            {
                return this.searchError;
            }

            set
            {
                this.searchError = value;
                this.OnPropertyChanged(() => this.searchError);
            }
        }

        public TwitterApplicationOnlyOAuthTokens ApplicationOnlyToken
        {
            get
            {
                return this.applicationOnlyToken;
            } // get

            set
            {
                this.applicationOnlyToken = value;
                this.OnPropertyChanged(() => this.applicationOnlyToken);
            } // set
        }

        public bool CanSearch
        {
            get
            {
                return !string.IsNullOrEmpty(this.searchTag) && this.searchTag.Length > 1;
            }
        }
        #endregion

        #region Methods
        
        public async void Connect()
        {
            if(!this.applicationOnlyToken.IsFieldEmpty)
            {
                return;
            }

            this.ResultsVisibility = false;
            this.Error = string.Empty;
            var value = await TwitterApplicationOnlyAuthService.CreateInstance(this.applicationOnlyToken);
            if(value.OAuthAccessToken == null)
            {
                this.Error = "         Application only aunthentication failed!";
                this.SearchCollapsableVisibility = false;
                this.SearchVisibility = false;
            }
            else
            {
                this.Error = string.Empty;
                this.SearchCollapsableVisibility = true;
                this.SearchVisibility = true;
                this.AuthenticationVisibility = false;
                this.AuthenticationContent = "";
                this.SearchContent = "";
            }
        }
        
        public async void Search()
        {
            this.SearchError = string.Empty;
            var collection = await new TwitterFeedsService().GetTimeline(this.searchTag, 30, TwitterApplicationOnlyAuthService.BasicToken.OAuthAccessToken);
            if(!collection.Any())
            {
                this.SearchError = "         No Timeline found for this screen name!";                                
            }
            else
            {
                this.SearchError = string.Empty;
            }
            this.DataSource = collection;
            this.ResultsVisibility = true;
        }

        private void HandleConnect()
        {
            if(this.authenticationVisibility)
            {
                this.AuthenticationContent = "";
                this.AuthenticationVisibility = false;
            }
            else
            {
                this.AuthenticationContent = "";
                this.AuthenticationVisibility = true;
            }
        }

        private void HandleSearch()
        {
            if(this.searchCollapsableVisibility)
            {
                this.SearchContent = "";
                this.SearchCollapsableVisibility = false;
            }
            else
            {
                this.SearchContent = "";
                this.SearchCollapsableVisibility = false;
            }
        }
        #endregion
    }
}
